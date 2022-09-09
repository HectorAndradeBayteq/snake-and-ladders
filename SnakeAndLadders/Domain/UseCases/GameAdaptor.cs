using Domain.Entities;
using Domain.Ports.Input;
using Domain.Ports.Input.Interfaces;
using Domain.Ports.Output;
using Domain.Utils;

namespace Domain.UseCases
{
    public class GameAdaptor: IGamePort<IPlayer, GameStatus>
    {
        private readonly IGameConfigPort _gameConfigPort;
        private Game _game;

        public GameAdaptor(IGameConfigPort gameConfigPort)
        {
            _gameConfigPort = gameConfigPort ?? throw new ArgumentNullException(nameof(gameConfigPort));
        }

        public GameStatus StartGame(List<IPlayer> players)
        {
            _game = new Game(PlayerBuilder.CreatePlayers(players), _gameConfigPort);
            return _game.GetStatus();
        }

        public GameStatus HandlePlayerCommand(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            return _game.HandlePlayerCommand(player);
        }
    }
}
