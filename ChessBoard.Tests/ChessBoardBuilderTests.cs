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

			Assert.IsTrue(Assertions.AreBoardsMatch(actualBoardCells, expectedChessboard.BoardCells),
				"StartPositionChessBoard should set initial positions for chessmens");
		}
	}
}
