using NUnit.Framework;

namespace ChessBoard.Tests
{
	[TestFixture]
	public class ChessBoardTests
	{
		[Test]
		public void TestSetStartPosition()
		{
			ChessBoard actualBoard = new ChessBoard();
			actualBoard.SetStartPosition();

			var expectedChessBoard = TestData.GetStartPositionChessBoard();

			Assert.IsTrue(Assertions.AreBoardsMatch(expectedChessBoard.BoardCells, actualBoard.BoardCells),
				"Empty constructor shoud set initial positions for chessmens");

			Assert.AreEqual(GameStatus.Normal, actualBoard.Status, "Empty constructor shoud set Normal game status");
		}

		[Test, TestCaseSource(nameof(GetTestChessBoards))]
		public void TestConstructorWithDeserialisation(ChessBoard initialChessBoard, ChessBoard expectedChessBoard)
		{
			string actualSerializedChessBoard = initialChessBoard.GetSerializedChessBoard();
			ChessBoard actualBoard = new ChessBoard(actualSerializedChessBoard);

			Assert.IsTrue(Assertions.AreBoardsMatch(expectedChessBoard.BoardCells, actualBoard.BoardCells),
				"Constructor with deserialisation shoud set correct positions for chessmens and their types");

			Assert.AreEqual(expectedChessBoard.Status, actualBoard.Status,
				"Statuses should be equal");
		}

		[Test]
		public void TestGetSerializedChessBoard()
		{
			ChessBoard board = new ChessBoard();
			board.SetStartPosition();

			string actualSerializedChessBoard = board.GetSerializedChessBoard();
			string expectedSerializedChessBoard = TestData.GetSerializedChessBoardWithStartPosition();

			Assert.AreEqual(expectedSerializedChessBoard, actualSerializedChessBoard);
		}

		[Test]
		public void TestMoveChessman()
		{
			// todo: check throw exception if cell is not acceptable for the chessman

			ChessBoard board = new ChessBoard();
			board.SetStartPosition();

			var pawn = board.BoardCells[6, 4].Chessman;
			var oldCellForPawn = new Cell(6, 4);
			var newCellForPawn = new Cell(4, 4);

			board.MoveChessman(pawn, oldCellForPawn, newCellForPawn);

			Assert.IsTrue(board.BoardCells[6, 4].IsEmpty(), "Old cell shoul be empty after movement");
			Assert.AreEqual(board.BoardCells[4, 4].Chessman, pawn, "New position should have correct chessman");
		}

		static object[] GetTestChessBoards()
		{
			object[] result = new object[2];

			ChessBoard initialBoard = new ChessBoard();
			initialBoard.SetStartPosition();

			result[0] = new object[]
			{
				initialBoard,
				TestData.GetStartPositionChessBoard()
			};

			result[1] = new object[]
			{
				TestData.GetChessBoardScenarioOneStatusNormal(),
				TestData.GetChessBoardScenarioOneStatusNormal()
			};

			return result;
		}
	}
}
