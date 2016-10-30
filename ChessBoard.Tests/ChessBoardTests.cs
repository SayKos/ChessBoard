using System;
using System.Collections.Generic;
using System.Linq;
using ChessBoard.Chessmens;
using NUnit.Framework;
using NUnit.Framework.Internal;

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
				new object[] { TestData.CreateNewChessBoard(), new Cell(7, 1), new Cell(5, 2) },
				new object[] { TestData.GetChessBoardScenario_1_WhiteTurn(), new Cell(2, 3), new Cell(1, 4) }
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

		[Test, TestCaseSource(nameof(GetTestPawnMovementsOnLastRow))]
		public void TestMoveChessmanWhenWhitePawnShouldBeConverted(
			ChessBoard chessBoard, 
			Cell oldPosition, 
			Cell newPosition,
			ChessmenType newChessmanType,
			Type type)
		{
			var pawn = chessBoard.BoardCells[oldPosition.Row, oldPosition.Column].Chessman;

			chessBoard.MoveChessman(pawn, oldPosition, newPosition, newChessmanType);

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

			var pawn = chessBoard.BoardCells[oldPosition.Row, oldPosition.Column].Chessman;

			Assert.Throws(typeof(ArgumentException), () => 
				chessBoard.MoveChessman(pawn, oldPosition, newPosition, chessmanType));
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

			var pawn = chessBoard.BoardCells[oldPosition.Row, oldPosition.Column].Chessman;

			Assert.Throws(typeof(ArgumentException), () => chessBoard.MoveChessman(pawn, oldPosition, newPosition, chessmanType));
		}

		[Test, TestCaseSource(nameof(GetTestFailMovementsWithWrongColors))]
		public void TestMoveChessmanFailWhenInconsistentGameStatusAndChessmanColor(ChessBoard chessBoard, Cell oldPosition, Cell newPosition)
		{
			var chessman = chessBoard.BoardCells[oldPosition.Row, oldPosition.Column].Chessman;

			Assert.Throws(typeof(ArgumentException), () => chessBoard.MoveChessman(chessman, oldPosition, newPosition));
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

		[Test, TestCaseSource(nameof(GetTestCasesForAcceptableCellsForPawn))]
		public void TestGetAcceptableCellsForPawn(
			ChessBoard chessBoard, 
			Cell cellOfPawnToTest, 
			List<Cell> expectedCells, 
			string caseName)
		{
			var actualCells = chessBoard.GetAcceptableCells(cellOfPawnToTest);
			Assert.IsTrue(AreActualCellsEqualToExpected(actualCells, expectedCells));
		}

		static object[] GetTestCasesForAcceptableCellsForPawn()
		{
			return PawnTestData.GetTestCasesForAcceptableCellsForPawn();
		}

		static bool AreActualCellsEqualToExpected(List<Cell> actualCells, List<Cell> expectedCells)
		{
			return actualCells.Count == expectedCells.Count 
				&& new HashSet<Cell>(actualCells).SetEquals(expectedCells);
		}

		// todo: check switching turn after moving (check all statuses)
	}
}
