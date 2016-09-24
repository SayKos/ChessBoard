using NUnit.Framework;

namespace ChessBoard.Tests
{
	[TestFixture]
	class ChessBoardBuilderTests
	{
		[Test]
		public void StartPositionChessBoardTest()
		{
			var actualChessboard = ChessBoardBuilder.GetStartPositionChessBoard();
			var expectedChessboard = TestData.GetStartPositionChessBoard();

			Assert.IsTrue(Assertions.AreBoardsMatch(expectedChessboard, actualChessboard), 
				"StartPositionChessBoard should set initial positions for chessmens");
		}
	}
}
