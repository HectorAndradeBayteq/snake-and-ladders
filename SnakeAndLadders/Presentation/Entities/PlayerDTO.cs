using Domain.Ports.Input.Interfaces;

namespace Presentation.Entities
{
    public class PlayerDTO: IPlayer
    {
        public PlayerDTO(string name)
        {
            Name = name;
            UserCommand = Constants.RollDiceCommand;
        }
        public string Name { get; set; }
        public string Id { get; } = string.Empty;
        public string UserCommand { get; set; }
    }
}
