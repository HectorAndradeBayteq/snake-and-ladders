using Domain.Ports.Input.Interfaces;

namespace Domain.Entities
{
    public class GameStatus
    {
        public GameStatus(Dictionary<IPlayer, Square> positions, IPlayer nextPlayer, string stateMessage, int lastDiceResult = 0)
        {
            Positions = positions;
            NextPlayer = nextPlayer;
            StateMessage = stateMessage;
            LastDiceResult = lastDiceResult;
        }
        public Dictionary<IPlayer, Square> Positions { get; }
        public IPlayer NextPlayer { get; }

        public string StateMessage { get; }

        public int LastDiceResult { get; }
    }
}
