using NUnit.Framework;

namespace ChessBoard.Tests
{
	public static class Assertions
	{
		public static void AreBoardsMatch(BoardCell[,] expected, BoardCell[,] actual)
		{
			for (int row = 0; row <= 7; row++)
			{
				for (int column = 0; column <= 7; column++)
				{
					if (expected[row, column].Chessman == null && actual[row, column].Chessman == null)
						continue;

					if (expected[row, column] == null || actual[row, column] == null)
					{
						Assert.Fail("BoardCell can not be null");
					}

					if (!expected[row, column].Equals(actual[row, column]))
					{
						Assert.Fail("Cells and their properties should be equal");
					}
				}
			}

			Assert.Pass();
		}
	}
}
