using System;
using BoardGames.TicTacToe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoardGameTester
{
    [TestClass]
    public class BasicTicTacToeTests
    {
        [TestMethod]
        public void SimpleXMove()
        {
            // Arrange
            TicTacToeRunner runner = new TicTacToeRunner();

            // Act
            PlacementResult result = runner.AttemptPlacePiece(new Location(0, 0));

            Console.Write(runner.PrintBoard());

            // Assert
            Assert.IsFalse(result.IsWon);
        }

        [TestMethod]
        public void CoupleMoves()
        {
            // Arrange
            TicTacToeRunner runner = new TicTacToeRunner();

            // Act
            runner.AttemptPlacePiece(new Location(1, 1));
            runner.AttemptPlacePiece(new Location(2, 0));
            runner.AttemptPlacePiece(new Location(0, 2));
            PlacementResult result = runner.AttemptPlacePiece(new Location(0, 0));

            // Assert
            Assert.IsFalse(result.IsWon);
        }

        [TestMethod]
        [DataRow(-1, 0)]
        [DataRow(0, -1)]
        [DataRow(3, 0)]
        [DataRow(0, 3)]
        public void InvalidLocation_HandledCorrectly(int x, int y)
        {
            // Arrange
            TicTacToeRunner runner = new TicTacToeRunner();
            Player currentPlayer = runner.GetCurrentPlayer();

            // Act
            PlacementResult result = runner.AttemptPlacePiece(new Location(x, y));

            // Assert
            Assert.IsFalse(result.IsWon);
            Assert.AreEqual(BoardPlacementResult.InvalidLocation, result.BoardPlacementResult);
            Assert.AreEqual(currentPlayer.ToString("g"), result.NextPlayer);
        }

        [TestMethod]
        public void OccupiedLocation_HandledCorrectly()
        {
            // Arrange
            TicTacToeRunner runner = new TicTacToeRunner();
            runner.AttemptPlacePiece(new Location(0, 0));
            Player currentPlayer = runner.GetCurrentPlayer();

            // Act
            PlacementResult result = runner.AttemptPlacePiece(new Location(0, 0));

            // Assert
            Assert.IsFalse(result.IsWon);
            Assert.AreEqual(BoardPlacementResult.LocationOccupied, result.BoardPlacementResult);
            Assert.AreEqual(currentPlayer.ToString("g"), result.NextPlayer);
        }

        [TestMethod]
        public void SimpleWin()
        {
            // Arrange
            TicTacToeRunner runner = new TicTacToeRunner();

            runner.AttemptPlacePiece(new Location(0, 0));
            runner.AttemptPlacePiece(new Location(1, 0));
            runner.AttemptPlacePiece(new Location(1, 1));
            runner.AttemptPlacePiece(new Location(2, 0));

            // Act
            PlacementResult result = runner.AttemptPlacePiece(new Location(2, 2));

            // Assert
            Assert.IsTrue(result.IsWon);
            Assert.AreEqual(BoardPlacementResult.Success, result.BoardPlacementResult);
        }

        [TestMethod]
        public void BoardFilled()
        {
            // Arrange
            TicTacToeRunner runner = new TicTacToeRunner();

            runner.AttemptPlacePiece(new Location(0, 0));
            runner.AttemptPlacePiece(new Location(1, 1));
            runner.AttemptPlacePiece(new Location(2, 1));
            runner.AttemptPlacePiece(new Location(2, 0));
            runner.AttemptPlacePiece(new Location(0, 2));
            runner.AttemptPlacePiece(new Location(1, 2));
            runner.AttemptPlacePiece(new Location(1, 0));
            runner.AttemptPlacePiece(new Location(0, 1));

            // Act
            PlacementResult result = runner.AttemptPlacePiece(new Location(2, 2));

            // Assert
            Assert.IsFalse(result.IsWon);
            Assert.AreEqual(BoardPlacementResult.BoardFilled, result.BoardPlacementResult);
        }

        [TestMethod]
        public void RowWinOne()
        {
            // Arrange
            TicTacToeRunner runner = new TicTacToeRunner();

            runner.AttemptPlacePiece(new Location(0, 0));
            runner.AttemptPlacePiece(new Location(1, 1));
            runner.AttemptPlacePiece(new Location(0, 1));
            runner.AttemptPlacePiece(new Location(2, 0));

            // Act
            PlacementResult result = runner.AttemptPlacePiece(new Location(0, 2));

            // Assert
            Assert.IsTrue(result.IsWon);
            Assert.AreEqual(BoardPlacementResult.Success, result.BoardPlacementResult);
        }

        [TestMethod]
        public void RowWinTwo()
        {
            // Arrange
            TicTacToeRunner runner = new TicTacToeRunner();

            runner.AttemptPlacePiece(new Location(2, 0));
            runner.AttemptPlacePiece(new Location(1, 1));
            runner.AttemptPlacePiece(new Location(2, 1));
            runner.AttemptPlacePiece(new Location(1, 0));

            // Act
            PlacementResult result = runner.AttemptPlacePiece(new Location(2, 2));

            // Assert
            Assert.IsTrue(result.IsWon);
            Assert.AreEqual(BoardPlacementResult.Success, result.BoardPlacementResult);
        }

        [TestMethod]
        public void ColWinOne()
        {
            // Arrange
            TicTacToeRunner runner = new TicTacToeRunner();

            runner.AttemptPlacePiece(new Location(0, 0));
            runner.AttemptPlacePiece(new Location(1, 1));
            runner.AttemptPlacePiece(new Location(1, 0));
            runner.AttemptPlacePiece(new Location(2, 1));

            // Act
            PlacementResult result = runner.AttemptPlacePiece(new Location(2, 0));

            // Assert
            Assert.IsTrue(result.IsWon);
            Assert.AreEqual(BoardPlacementResult.Success, result.BoardPlacementResult);
        }

        [TestMethod]
        public void ColWinTwo()
        {
            // Arrange
            TicTacToeRunner runner = new TicTacToeRunner();

            runner.AttemptPlacePiece(new Location(0, 1));
            runner.AttemptPlacePiece(new Location(1, 0));
            runner.AttemptPlacePiece(new Location(1, 1));
            runner.AttemptPlacePiece(new Location(1, 2));

            // Act
            PlacementResult result = runner.AttemptPlacePiece(new Location(2, 1));

            // Assert
            Assert.IsTrue(result.IsWon);
            Assert.AreEqual(BoardPlacementResult.Success, result.BoardPlacementResult);
        }

        [TestMethod]
        public void PosDiagWin()
        {
            // Arrange
            TicTacToeRunner runner = new TicTacToeRunner();

            runner.AttemptPlacePiece(new Location(0, 0));
            runner.AttemptPlacePiece(new Location(0, 1));
            runner.AttemptPlacePiece(new Location(1, 1));
            runner.AttemptPlacePiece(new Location(2, 1));

            // Act
            PlacementResult result = runner.AttemptPlacePiece(new Location(2, 2));

            // Assert
            Assert.IsTrue(result.IsWon);
            Assert.AreEqual(BoardPlacementResult.Success, result.BoardPlacementResult);
        }

        [TestMethod]
        public void NegDiagWin()
        {
            // Arrange
            TicTacToeRunner runner = new TicTacToeRunner();

            runner.AttemptPlacePiece(new Location(2, 0));
            runner.AttemptPlacePiece(new Location(1, 0));
            runner.AttemptPlacePiece(new Location(1, 1));
            runner.AttemptPlacePiece(new Location(1, 2));

            // Act
            PlacementResult result = runner.AttemptPlacePiece(new Location(0, 2));

            // Assert
            Assert.IsTrue(result.IsWon);
            Assert.AreEqual(BoardPlacementResult.Success, result.BoardPlacementResult);
        }

        [TestMethod]
        public void NextPlayerIsCorrect()
        {
            // Arrange
            TicTacToeRunner runner = new TicTacToeRunner();
            Player startingPlayer = runner.GetCurrentPlayer();

            runner.AttemptPlacePiece(new Location(2, 0));
            runner.AttemptPlacePiece(new Location(1, 0));
            runner.AttemptPlacePiece(new Location(1, 1));
            // Act
            PlacementResult result = runner.AttemptPlacePiece(new Location(0, 2));

            // Assert
            Assert.IsFalse(result.IsWon);
            Assert.AreEqual(BoardPlacementResult.Success, result.BoardPlacementResult);
            Assert.AreEqual(startingPlayer, runner.GetCurrentPlayer());
        }
    }
}
