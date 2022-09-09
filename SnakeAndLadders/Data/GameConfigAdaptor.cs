using Domain.Ports.Output;
using Domain.Ports.Output.Interfaces;

namespace Data
{
    public class GameConfigAdaptor : IGameConfigPort
    {
        private readonly GameConfig _gameConfig = new();

        public IDiceConfig GetDiceConfig()
        {
            return _gameConfig.DiceConfig;
        }

        public IBoardConfig GetBoardConfig()
        {
            return _gameConfig.BoardConfig;
        }
    }
}