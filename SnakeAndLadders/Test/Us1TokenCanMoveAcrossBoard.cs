using System.Collections.Generic;
using System.Linq;
using Domain.Ports.Output;
using Domain.UseCases;
using Moq;
using NUnit.Framework;

namespace Test
{
    /// <summary>
    /// US 1 - Token Can Move Across the Board
    /// </summary>
    public class Us1TokenCanMoveAcrossBoard
    {
        private Mock<IGameConfigPort> _gameConfigPort;
        private Utils _utils;

        [SetUp]
        public void Setup()
        {
            _utils = new();
            _gameConfigPort = _utils.GetGameConfigPort();
        }

        /// <summary>
        /// Given the game is started
        /// When the token is placed on the board
        /// Then the token is on square 1
        /// </summary>
        [Test]
        public void WhenTokenIsPlacedOnTheBoardThenTheTokenIsOnSquareOne()
        {
            var game = new GameAdaptor(_gameConfigPort.Object);
            var status = game.StartGame(_utils.GetThreePlayers());
            status.Positions.ToList().ForEach(
                position => Assert.AreEqual(1, position.Value.Id));
        }

        /// <summary>
        /// Given the token is on square 1
        /// When the token is moved 3 spaces
        /// Then the token is on square 4
        /// </summary>
        [Test]
        public void WhenTokenIsMovedThreeSpacesThenTheTokenIsOnSquareFour()
        {
            var simulationSequence = new List<int>() { 3 };
            var game = new GameAdaptor(_utils.GetGameConfigPort(simulationSequence).Object);
            var initialStatus = game.StartGame(_utils.GetOnePlayer());

            var currentStatus = game.HandlePlayerCommand(initialStatus.NextPlayer);
            currentStatus.Positions.ToList().ForEach(
                position => Assert.AreEqual(4, position.Value.Id));
        }

        /// <summary>
        /// Given the token is on square 1
        /// When the token is moved 3 spaces
        /// And then it is moved 4 spaces
        /// Then the token is on square 8
        /// </summary>
        [Test]
        public void WhenTokenIsMovedThreeSpacesAndThenMovedFourSpacesThenTheTokenIsOnSquareEight()
        {
            var simulationSequence = new List<int>() { 3, 4 };
            var game = new GameAdaptor(_utils.GetGameConfigPort(simulationSequence).Object);
            var initialStatus = game.StartGame(_utils.GetOnePlayer());
            var currentStatus = game.HandlePlayerCommand(initialStatus.NextPlayer);

            currentStatus.Positions.ToList().ForEach(
                position => Assert.AreEqual(4, position.Value.Id));
            currentStatus = game.HandlePlayerCommand(initialStatus.NextPlayer);

            currentStatus.Positions.ToList().ForEach(
                // Note: According to current rules, square 8 is linked to square 31 by a ladder,
                // then if a player arrive to square 8, this will be moved to square 31.
                position => Assert.AreEqual(31, position.Value.Id));
        }

    }
}
