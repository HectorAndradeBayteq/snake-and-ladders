using Domain.Ports.Input.Interfaces;
using Domain.Utils;

namespace Domain.Entities
{
    public class Player: IPlayer
    {
        private readonly Commands _commands = new();
        public Player()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Name { get; set; } = string.Empty;
        public string Id { get; }
        public string UserCommand {
            get => _commands.GetUserCommand(Command);
            set => Command = _commands.GetPlayerCommand(value);
        }

        public PlayerCommand Command { get; set; } = PlayerCommand.RollDice;
    }
}
