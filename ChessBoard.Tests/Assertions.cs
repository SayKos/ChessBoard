namespace ChessBoard.Tests
{
	public static class Assertions
	{
		public static bool AreBoardsMatch(BoardCell[,] expected, BoardCell[,] actual)
		{
			var areBoardsMatch = true;

			for (int row = 0; row <= 7; row++)
			{
				for (int column = 0; column <= 7; column++)
				{
					if (expected[row, column].Chessman == null && actual[row, column].Chessman == null)
						continue;

					if (expected[row, column] == null)
						return false;

					if (!expected[row, column].Equals(actual[row, column]))
						return false;
				}
			}

			return areBoardsMatch;
		}
	}
}
