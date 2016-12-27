using System;
using System.Collections.Generic;
using System.Linq;
using ChessBoard.Chessmens;
using ChessBoard.Tests.TestDataClasses;
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

			Assert.AreEqual(expectedChessBoard.Status, actualBoard.Status, "Statuses should be equal");
		}

		static object[] GetTestChessBoards()
		{
			return new object[]
			{
				new object[] { TestData.CreateNewChessBoard(), TestData.GetStartPositionChessBoard() },
				new object[] { TestData.GetChessBoardScenario_1_WhiteTurn(), TestData.GetChessBoardScenario_1_WhiteTurn() }
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
			var oldChessman = board.BoardCells[oldCell.Row, oldCell.Column].Chessman;

			board.MoveChessman(oldCell, newCell);

			var newChessman = board.BoardCells[newCell.Row, newCell.Column].Chessman;

			Assert.IsTrue(board.BoardCells[oldCell.Row, oldCell.Column].IsEmpty(), "Old cell shoul be empty after movement");
			Assert.AreEqual(oldChessman, newChessman, "New position should have correct chessman");
		}

		static object[] GetTestMovements()
		{
			return new object[]
			{
				new object[] { TestData.CreateNewChessBoard(), new Cell(6, 4), new Cell(4, 4) },
				new object[] { TestData.CreateNewChessBoard(), new Cell(7, 1), new Cell(5, 2) },
				new object[] { TestData.GetChessBoardScenario_1_WhiteTurn(), new Cell(2, 3), new Cell(1, 4) }
			};
		}

		[Test]
		public void TestMoveChessmanFailWhenOldPositionIsNUll()
		{
			ChessBoard board = TestData.CreateNewChessBoard();

			Assert.Throws(typeof(ArgumentException), () => board.MoveChessman(null, new Cell()));
		}

		[Test]
		public void TestMoveChessmanFailWhenNewPositionIsNUll()
		{
			ChessBoard board = TestData.CreateNewChessBoard();

			Assert.Throws(typeof(ArgumentException), () => board.MoveChessman(new Cell(), null));
		}

		[Test, TestCaseSource(nameof(GetTestPawnMovementsOnLastRow))]
		public void TestMoveChessmanWhenWhitePawnShouldBeConverted(
			ChessBoard chessBoard, 
			Cell oldPosition, 
			Cell newPosition,
			ChessmenType newChessmanType,
			Type type)
		{
			chessBoard.MoveChessman(oldPosition, newPosition, newChessmanType);

			var newChessman = chessBoard.BoardCells[newPosition.Row, newPosition.Column].Chessman;

			Assert.AreEqual(type, newChessman.GetType(), "Types should be aqual");
			Assert.AreEqual(newChessmanType, newChessman.Type, "Chessman types should be aqual");
		}

		static object[] GetTestPawnMovementsOnLastRow()
		{
			return new object[]
			{
				new object[] { TestData.GetChessBoardScenario_2_WhiteTurn(), new Cell(1, 7), new Cell(0, 7),
					ChessmenType.Queen, typeof(Queen) },
				new object[] { TestData.GetChessBoardScenario_2_WhiteTurn(), new Cell(1, 7), new Cell(0, 7),
					ChessmenType.Bishop, typeof(Bishop) },
				new object[] { TestData.GetChessBoardScenario_2_WhiteTurn(), new Cell(1, 7), new Cell(0, 7),
					ChessmenType.Rook, typeof(Rook) },
				new object[] { TestData.GetChessBoardScenario_2_WhiteTurn(), new Cell(1, 7), new Cell(0, 7),
					ChessmenType.Knight, typeof(Knight) },
				new object[] { TestData.GetChessBoardScenario_3_BlackTurn(), new Cell(6, 0), new Cell(7, 0),
					ChessmenType.Queen, typeof(Queen) }
			};
		}

		[Test, TestCaseSource(nameof(GetWrongNewTypesForPawn))]
		public void TestMoveChessmanFailWhenPawnConvertedToWrongType(ChessmenType chessmanType)
		{
			var chessBoard = TestData.GetChessBoardScenario_2_WhiteTurn();

			Cell oldPosition = new Cell(1, 7);
			Cell newPosition = new Cell(0, 7);

			Assert.Throws(typeof(ArgumentException), () => 
				chessBoard.MoveChessman(oldPosition, newPosition, chessmanType));
		}

		static object[] GetWrongNewTypesForPawn()
		{
			return new object[]
			{
				new object[] { ChessmenType.Pawn },
				new object[] { ChessmenType.King }
			};
		}

		[Test]
		public void TestMoveChessmanFailWhenPawnOnLastRowButWithoutNewType()
		{
			var chessBoard = TestData.GetChessBoardScenario_2_WhiteTurn();

			Cell oldPosition = new Cell(1, 7);
			Cell newPosition = new Cell(0, 7);
			ChessmenType? chessmanType = null;

			Assert.Throws(typeof(ArgumentException), () => 
				chessBoard.MoveChessman(oldPosition, newPosition, chessmanType));
		}

		[Test, TestCaseSource(nameof(GetTestFailMovementsWithWrongColors))]
		public void TestMoveChessmanFailWhenInconsistentGameStatusAndChessmanColor(
			ChessBoard chessBoard, 
			Cell oldPosition, 
			Cell newPosition)
		{
			Assert.Throws(typeof(ArgumentException), () => 
				chessBoard.MoveChessman(oldPosition, newPosition));
		}

		static object[] GetTestFailMovementsWithWrongColors()
		{
			return new object[]
			{
				new object[] { TestData.GetChessBoardScenario_2_WhiteTurn(), new Cell(0, 4), new Cell(1, 4) },
				new object[] { TestData.GetChessBoardScenario_3_BlackTurn(), new Cell(7, 4), new Cell(6, 4) },
				new object[] { TestData.GetChessBoardScenario_4_ShahForWhite(), new Cell(7, 7), new Cell(6, 7) },
				new object[] { TestData.GetChessBoardScenario_5_ShahForBlack(), new Cell(7, 7), new Cell(6, 7) },
				new object[] { TestData.GetChessBoardScenario_6_CheckmateForWhite(), new Cell(2, 1), new Cell(3, 1) },
				new object[] { TestData.GetChessBoardScenario_7_CheckmateForBlack(), new Cell(2, 1), new Cell(3, 1) },
				new object[] { TestData.GetChessBoardScenario_8_StalemateForBlack(), new Cell(2, 1), new Cell(3, 1) },
				new object[] { TestData.GetChessBoardScenario_9_StalemateForWhite(), new Cell(2, 1), new Cell(3, 1) }
			};
		}

		[Test]
		public void TestMoveChessmanFailWhenNewPositionIsNotAcceptable()
		{
			var board = TestData.CreateNewChessBoard();
			var oldPosition = new Cell(6, 0);
			var newPosition = new Cell(0, 7);

			Assert.Throws(typeof(ArgumentException), () =>
				board.MoveChessman(oldPosition, newPosition));
		}

		[Test, TestCaseSource(nameof(GetTestCasesForAcceptableCells))]
		public void TestGetAcceptableCells(
			ChessBoard chessBoard, 
			Cell cellToTest, 
			List<Cell> expectedCells, 
			string caseName)
		{
			var actualCells = chessBoard.GetAcceptableCells(cellToTest);
			Assert.IsTrue(AreActualCellsEqualToExpected(actualCells, expectedCells));
		}

		static object[] GetTestCasesForAcceptableCells()
		{
			return PawnTestData.GetAcceptableCellsTestCases()
				.Concat(RookTestData.GetAcceptableCellsTestCases())
				.Concat(BishopTestData.GetAcceptableCellsTestCases())
				.Concat(QueenTestData.GetAcceptableCellsTestCases())
				.Concat(KnightTestData.GetAcceptableCellsTestCases())
				.Concat(KingTestData.GetAcceptableCellsTestCases())
				.ToArray();
		}

		static bool AreActualCellsEqualToExpected(List<Cell> actualCells, List<Cell> expectedCells)
		{
			var firstNotSecond = actualCells.Except(expectedCells).ToList();
			var secondNotFirst = expectedCells.Except(actualCells).ToList();

			return !firstNotSecond.Any() && !secondNotFirst.Any();
		}

		[Test]
		public void TestGetAcceptableCellsFailWhenCellIsNull()
		{
			var board = TestData.CreateNewChessBoard();

			Assert.Throws(typeof(ArgumentException), () =>
				board.GetAcceptableCells(null));
		}

		[Test]
		public void SetMovedAfterMoveChessman()
		{
			var board = TestData.CreateNewChessBoard();
			var oldPosition = new Cell(6, 0);
			var newPosition = new Cell(5, 0);

			board.MoveChessman(oldPosition, newPosition);

			var pawn = board.BoardCells[newPosition.Row, newPosition.Column].Chessman;

			Assert.IsTrue(pawn.Moved);
		}

		[Test]
		public void TestStatusAfterWhiteGiveUp()
		{
			var board = TestData.CreateNewChessBoard();
			board.GiveUp(Color.White);

			Assert.That(board.Status, Is.EqualTo(GameStatus.BlackWin));
		}

		[Test]
		public void TestStatusAfterBlackGiveUp()
		{
			var board = TestData.GetChessBoardScenario_3_BlackTurn();
			board.GiveUp(Color.Black);

			Assert.That(board.Status, Is.EqualTo(GameStatus.WhiteWin));
		}

		// todo: check switching turn after moving (check all statuses)
	}
}
