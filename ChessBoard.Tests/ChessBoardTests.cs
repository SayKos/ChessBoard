using ChessBoard.Chessmens;
using NUnit.Framework;

namespace ChessBoard.Tests
{
	[TestFixture]
	public class ChessBoardTests
    {
		[Test]
		public void TestEmptyConstructor()
		{
			Bishop b = new Bishop(Color.Black);

			ChessBoard board = new ChessBoard();
			var expectedChessboard = TestData.GetStartPositionChessBoard();

			Assert.IsTrue(Assertions.AreBoardsMatch(expectedChessboard, board.Chessboard),
				"Empty constructor shoud set initial positions for chessmens");
		}

		[Test]
	    public void TestGetSerializedChessBoard()
	    {
		    ChessBoard board = new ChessBoard();

		    string s = board.GetSerializedChessBoard();

			Assert.AreEqual("", "");
	    }
    }
}
