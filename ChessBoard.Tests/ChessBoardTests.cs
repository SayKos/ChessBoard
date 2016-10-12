using System;
using ChessBoard.Chessmens;
using NUnit.Framework;

namespace ChessBoard.Tests
{
	[TestFixture]
	public class ChessBoardTests
	{
		[Test]
		public void TestSetStartPosition()
		{
			var actualBoard = TestData.CreateNewChessBoard();
			var expectedChessBoard = TestData.GetStartPositionChessBoard();

			Assertions.AreBoardsMatch(expectedChessBoard.BoardCells, actualBoard.BoardCells);

			Assert.AreEqual(GameStatus.WhiteTurn, actualBoard.Status, "Empty constructor shoud set Normal game status");
		}

		[Test, TestCaseSource(nameof(GetTestChessBoards))]
		public void TestConstructorWithDeserialisation(ChessBoard initialChessBoard, ChessBoard expectedChessBoard)
		{
			string actualSerializedChessBoard = initialChessBoard.GetSerializedChessBoard();
			ChessBoard actualBoard = new ChessBoard(actualSerializedChessBoard);

			Assertions.AreBoardsMatch(expectedChessBoard.BoardCells, actualBoard.BoardCells);

			Assert.AreEqual(expectedChessBoard.Status, actualBoard.Status,
				"Statuses should be equal");
		}

		static object[] GetTestChessBoards()
		{
			return new object[]
			{
				new object[] { TestData.CreateNewChessBoard(), TestData.GetStartPositionChessBoard() },
				new object[] { TestData.GetChessBoardScenarioOneStatusNormal(), TestData.GetChessBoardScenarioOneStatusNormal() }
			};
		}

		[Test]
		public void TestGetSerializedChessBoard()
		{
			ChessBoard board = TestData.CreateNewChessBoard();

			string actualSerializedChessBoard = board.GetSerializedChessBoard();
			string expectedSerializedChessBoard = TestData.GetSerializedChessBoardWithStartPosition();

			Assert.AreEqual(expectedSerializedChessBoard, actualSerializedChessBoard);
		}

		[Test, TestCaseSource(nameof(GetTestMovements))]
		public void TestMoveChessman(ChessBoard board, Cell oldCell, Cell newCell)
		{
			var chessman = board.BoardCells[oldCell.Row, oldCell.Column].Chessman;

			board.MoveChessman(chessman, oldCell, newCell);

			Assert.IsTrue(board.BoardCells[oldCell.Row, oldCell.Column].IsEmpty(), "Old cell shoul be empty after movement");
			Assert.AreEqual(board.BoardCells[newCell.Row, newCell.Column].Chessman, chessman, "New position should have correct chessman");
		}

		static object[] GetTestMovements()
		{
			return new object[]
			{
				new object[] { TestData.CreateNewChessBoard(), new Cell(6, 4), new Cell(4, 4) },
				new object[] { TestData.CreateNewChessBoard(), new Cell(0, 1), new Cell(2, 2) },
				new object[] { TestData.GetChessBoardScenarioOneStatusNormal(), new Cell(2, 3), new Cell(1, 4) }
			};
		}

		[Test, TestCaseSource(nameof(GetTestFailParamsForMovements))]
		public void TestMoveChessmanFailWhenChessmanIsNUll(BaseChessman chessman, Cell oldPosition, Cell newPosition)
		{
			ChessBoard board = TestData.CreateNewChessBoard();

			Assert.Throws(typeof(ArgumentException), () => board.MoveChessman(chessman, oldPosition, newPosition));
		}

		static object[] GetTestFailParamsForMovements()
		{
			return new object[]
			{
				new object[] { null, new Cell(), new Cell() },
				new object[] { new Pawn(), null, new Cell() },
				new object[] { new Pawn(), new Cell(), null }
			};
		}

		// todo: add test for pawn: for last row and white - ok - changed type
		// todo: add test for pawn: for last row and black - ok - changed type
	}
}
