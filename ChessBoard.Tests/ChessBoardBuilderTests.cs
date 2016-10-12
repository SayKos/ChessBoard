using Newtonsoft.Json;
using NUnit.Framework;

namespace ChessBoard.Tests
{
	[TestFixture]
	class ChessBoardBuilderTests
	{
		[Test]
		public void StartPositionChessBoardTest()
		{
			var actualBoardCells = ChessBoardBuilder.GetStartPositionBoardCells();
			var expectedChessboard = TestData.GetStartPositionChessBoard();

			Assertions.AreBoardsMatch(actualBoardCells, expectedChessboard.BoardCells);
		}

		[Test]
		public void GetNormilizedBoardCellsTest()
		{
			ChessBoard initialChessBoard = TestData.GetStartPositionChessBoard();
			string serializedChessboard = initialChessBoard.GetSerializedChessBoard();

			ChessBoard deserialisedChessBoard = JsonConvert.DeserializeObject<ChessBoard>(serializedChessboard);

			ChessBoardBuilder.GetNormilizedBoardCells(deserialisedChessBoard.BoardCells);

			Assertions.AreBoardsMatch(initialChessBoard.BoardCells, deserialisedChessBoard.BoardCells);
		}
	}
}
