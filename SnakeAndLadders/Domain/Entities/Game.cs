using Domain.Ports.Input.Interfaces;
using Domain.Ports.Output;
using Domain.Utils;

namespace Domain.Entities
{
    internal class Game
    {
        private IPlayer _currentPlayer;
        private readonly List<IPlayer> _players;
        private readonly Board _board;
        private readonly Dice _dice;
        private readonly Dictionary<IPlayer, Square> _positions = new();
        private readonly Commands _commands = new();

        public Game(List<IPlayer> players, IGameConfigPort gameConfigPort)
        {
            _currentPlayer = players.ToList().First();
            _dice = gameConfigPort.GetDiceConfig().SimulationSequence != null ?
                new Dice(gameConfigPort.GetDiceConfig().SimulationSequence) :
                new Dice(gameConfigPort.GetDiceConfig().FirstFaceValue, gameConfigPort.GetDiceConfig().QuantityOfFaces);
            _board = new Board(gameConfigPort.GetBoardConfig().SquaresRelations, gameConfigPort.GetBoardConfig().TotalSquares);
            _players = players;

            players.ForEach(player => _positions.Add(player, _board.Squares.First()));
        }

        public GameStatus HandlePlayerCommand(IPlayer player)
        {
            if (IsPlayerTurn(player))
                return GetStatus(GameStatusType.NoIsPlayerTurn, player);

            _currentPlayer = player;
            var gameStatus = GetStatus();

            switch (_commands.GetPlayerCommand(player.UserCommand))
            {
                case PlayerCommand.RollDice:
                    var diceResult = _dice.Roll();
                    SetPlayerPosition(_currentPlayer, diceResult);                    
                    gameStatus = PlayerHasWon(_currentPlayer) ?
                        GetStatus(GameStatusType.PlayerHasWon, _currentPlayer, diceResult) :
                        GetStatus(GameStatusType.TurnOver, _currentPlayer, diceResult);
                    _currentPlayer = PlayerHasWon(_currentPlayer) ? _currentPlayer : GetNextPlayer();
                    break;
                case PlayerCommand.GetState:
                    gameStatus = GetStatus(player: _currentPlayer);
                    break;
            }

            return gameStatus;
        }

        private bool IsPlayerTurn(IPlayer player)
        {
            return player.Id != _currentPlayer.Id;
        }

        private bool PlayerHasWon(IPlayer player)
        {
            return _positions[player].Id == _board.Squares.Last().Id;
        }

        private void SetPlayerPosition(IPlayer player, int steps)
        {
            _positions[player] = _board.GetNextSquare(_positions[player], steps);
        }

        public GameStatus GetStatus(
            GameStatusType? statusType = GameStatusType.State, 
            IPlayer? player = null,
            int lastDiceResult = 0)
        {
            switch (statusType)
            {
                case GameStatusType.NoIsPlayerTurn:
                    return new GameStatus(
                    positions: _positions,
                    nextPlayer: _currentPlayer,
                    stateMessage: "You must wait your turn " + player?.Name);

                case GameStatusType.PlayerHasWon:
                    return new GameStatus(
                    positions: _positions,
                    nextPlayer: _currentPlayer,
                    stateMessage: "Current player has won",
                    lastDiceResult: lastDiceResult);

                case GameStatusType.TurnOver:
                    return new GameStatus(
                    positions: _positions,
                    nextPlayer: GetNextPlayer(),
                    stateMessage: "Turn is over. Waiting for the next play...",
                    lastDiceResult: lastDiceResult);

                default:
                    return new GameStatus(
                    positions: _positions,
                    nextPlayer: _currentPlayer,
                    stateMessage: "Current state of the game. Waiting for play " + _currentPlayer.Name);
            }

        }

        private IPlayer GetNextPlayer()
        {
            if (_currentPlayer == null)
                throw new InvalidOperationException("No current player");
            return _currentPlayer.Id == _players.Last().Id ? 
                _players.First() : _players[_players.IndexOf(_currentPlayer) + 1];
        }

    } 
}
