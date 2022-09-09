using Data;
using Domain.Entities;
using Domain.Ports.Output;
using Moq;
using System.Collections.Generic;
using Domain.Ports.Input.Interfaces;

namespace Test
{
    internal class Utils
    {
        public List<IPlayer> GetThreePlayers()
        {
            return new List<IPlayer>() {
                new Player() { Name = "A" },
                new Player() { Name = "B" },
                new Player() { Name = "C" }
            };
        }

        public List<IPlayer> GetOnePlayer()
        {
            return new List<IPlayer>() {
                new Player() { Name = "A" }
            };
        }

        public Mock<IGameConfigPort> GetGameConfigPort(int diceStart = 1 , int diceFaces = 6)
        {
            var gameConfigPort = CreateGameConfigPort();
            gameConfigPort.Setup(config => config.GetDiceConfig()).Returns(new DiceConfig(diceStart, diceFaces));
            return gameConfigPort;
        }

        public Mock<IGameConfigPort> GetGameConfigPort(IEnumerable<int> simulationSequence)
        {
            var gameConfigPort = CreateGameConfigPort();
            gameConfigPort.Setup(config => config.GetDiceConfig()).Returns(new DiceSimulatedConfig(simulationSequence));
            return gameConfigPort;
        }

        private static Mock<IGameConfigPort> CreateGameConfigPort()
        {
            var gameConfigPort = new Mock<IGameConfigPort>();
            gameConfigPort.Setup(config => config.GetBoardConfig().TotalSquares).Returns(100);
            gameConfigPort.Setup(config => config.GetBoardConfig().SquaresRelations).Returns(
            new Dictionary<int, int?>() {
              { 99,80 },
              { 95,75 },
              { 92,88 },
              { 89,68 },
              { 87,94 },
              { 78,98 },
              { 74,53 },
              { 71,91 },
              { 64,60 },
              { 62,19 },
              { 51,67 },
              { 49,11 },
              { 46,25 },
              { 36,44 },
              { 28,84 },
              { 21,42 },
              { 16,6  },
              { 15,26 },
              {  8,31 },
              {  7,14 },
              {  2,38 }
            });
            return gameConfigPort;
        }


    }
}
