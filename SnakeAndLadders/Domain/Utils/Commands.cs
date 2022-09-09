namespace Domain.Utils
{
    public class Commands
    {
        private readonly Dictionary<string, PlayerCommand> _commandsDictionary;
        public Commands()
        {
            _commandsDictionary = new Dictionary<string, PlayerCommand>()
            {
                {"play", PlayerCommand.RollDice},
                {"exit", PlayerCommand.Exit},
                {"state", PlayerCommand.GetState},
                {string.Empty, PlayerCommand.Unkwow}
            };
        }
        public PlayerCommand GetPlayerCommand(string command)
        {
            return _commandsDictionary.ContainsKey(command) ? 
                _commandsDictionary[command] : PlayerCommand.RollDice;
        }

        public string GetUserCommand(PlayerCommand playerCommand)
        {
            return _commandsDictionary.ContainsValue(playerCommand)
                ? _commandsDictionary.First(pair => pair.Value == playerCommand).Key
                : string.Empty;
        }
    }
}
