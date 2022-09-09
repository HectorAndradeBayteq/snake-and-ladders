using Domain.Entities;
using Domain.Ports.Input.Interfaces;

namespace Domain.Utils
{
    public class PlayerBuilder
    {
        private static IPlayer CreatePlayer(IPlayer externalPlayer)
        {
            return new Player() { Name = externalPlayer.Name, UserCommand = externalPlayer.UserCommand };
        }

        public static List<IPlayer> CreatePlayers(List<IPlayer> externalPlayers)
        {
            return externalPlayers.Select(CreatePlayer).ToList();
        }

    }
}
