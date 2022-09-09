using System.Collections.Generic;
using System.Linq;
using Domain.UseCases;
using NUnit.Framework;

namespace Test
{
    /// <summary>
    /// As a player
    /// I want to move my token based on the roll of a die
    /// So that there is an element of chance in the game
    /// </summary>
    internal class Us3PlayerMoveBasedOnRollDie
    {
        private Utils _utils;

        [SetUp]
        public void Setup()
        {
            _utils = new();
        }

        /// <summary>
        /// Given the game is started
        /// When the player rolls a die
        /// Then the result should be between 1-6 inclusive
        /// </summary>
        [Test]
        public void WhenPlayerRollsADieThenTheResultShouldBeBetweenOneToSix()
        {
            var game = new GameAdaptor(_utils.GetGameConfigPort().Object);
            var initialStatus = game.StartGame(_utils.GetOnePlayer());
            var currentStatus = game.HandlePlayerCommand(initialStatus.NextPlayer);
            Assert.True(currentStatus.LastDiceResult is >= 1 and <= 6);
        }

        /// <summary>
        /// Given the player rolls a 4
        /// When they move their token
        /// Then the token should move 4 spaces
        /// /// </summary>
        
        [Test]
        public void WhenTokenIsMovedThreeSpacesThenTheTokenIsOnSquareFour()
        {
            var simulationSequence = new List<int>() { 43, 4 };
            var game = new GameAdaptor(_utils.GetGameConfigPort(simulationSequence).Object);
            var initialStatus = game.StartGame(_utils.GetOnePlayer());
            var currentStatus = game.HandlePlayerCommand(initialStatus.NextPlayer);
            currentStatus = game.HandlePlayerCommand(currentStatus.NextPlayer);
            currentStatus.Positions.ToList().ForEach(
                position => Assert.True(position.Value.Id - 44 == 4));
        }
    }
}
