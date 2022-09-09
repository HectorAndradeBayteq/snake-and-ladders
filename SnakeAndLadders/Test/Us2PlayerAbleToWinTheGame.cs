using System.Collections.Generic;
using System.Linq;
using Domain.UseCases;
using NUnit.Framework;


namespace Test
{
    /// <summary>
    /// As a player
    /// I want to be able to win the game
    /// So that I can gloat to everyone around
    /// </summary>
    internal class Us2PlayerAbleToWinTheGame
    {
        private Utils _utils;

        [SetUp]
        public void Setup()
        {
            _utils = new();
        }

        /// <summary>
        /// Given the token is on square 97
        /// When the token is moved 3 spaces
        /// Then the token is on square 100
        /// And the player has won the game
        /// </summary>
        [Test]
        public void WhenTokenIsMovedNinetySevenSpacesAndThenMovedThreeSpacesThenThePlayerWinTheGame()
        {
            var simulationSequence = new List<int>() { 96, 3 };
            var game = new GameAdaptor(_utils.GetGameConfigPort(simulationSequence).Object);
            var initialStatus = game.StartGame(_utils.GetOnePlayer());
            var currentStatus = game.HandlePlayerCommand(initialStatus.NextPlayer);
            currentStatus = game.HandlePlayerCommand(currentStatus.NextPlayer);
            currentStatus.Positions.ToList().ForEach(
                position => Assert.AreEqual(100, position.Value.Id));
            Assert.AreEqual("Current player has won", currentStatus.StateMessage);
        }

        /// <summary>
        /// Given the token is on square 97
        /// When the token is moved 4 spaces
        /// Then the token is on square 97
        /// And the player has not won the game
        /// </summary>
        [Test]
        public void WhenTokenIsMovedNinetySevenSpacesAndThenMovedFourSpacesThenThePlayerNotWinTheGame()
        {
            var simulationSequence = new List<int>() { 96, 4 };
            var game = new GameAdaptor(_utils.GetGameConfigPort(simulationSequence).Object);
            var initialStatus = game.StartGame(_utils.GetOnePlayer());
            var currentStatus = game.HandlePlayerCommand(initialStatus.NextPlayer);
            currentStatus = game.HandlePlayerCommand(currentStatus.NextPlayer);
            currentStatus.Positions.ToList().ForEach(
                position => Assert.AreEqual(97, position.Value.Id));
            Assert.AreEqual("Turn over. Waiting for the next play...", currentStatus.StateMessage);
        }
    }
}
