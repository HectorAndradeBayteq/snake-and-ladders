using Domain.Ports.Output.Interfaces;

namespace Domain.Ports.Output
{
    public interface IGameConfigPort
    {
        public IDiceConfig GetDiceConfig();
        public IBoardConfig GetBoardConfig();
    }
}
