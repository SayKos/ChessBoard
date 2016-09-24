using ChessBoard.Chessmens;

namespace ChessBoard
{
	public static class ChessBoardBuilder
	{ 
		public static BoardCell[,] GetStartPositionChessBoard()
		{
			BoardCell[,] chessboard = new BoardCell[8, 8];
			int[] startRows = { 0, 1, 6, 7 };

			foreach (var row in startRows)
			{
				for (int collumn = 0; collumn <= 7; collumn++)
				{
					BaseChessman chessman = null;

					if (IsStartPawnRow(row))
						chessman = new Pawn();

					else if (IsStartRookCell(row, collumn))
						chessman = new Rook();

					else if (IsStartKnightCell(row, collumn))
						chessman = new Knight();

					else if (IsStartBishopCell(row, collumn))
						chessman = new Bishop();

					else if (IsStartQueenCell(row, collumn))
						chessman = new Queen();

					else if (IsStartKingCell(row, collumn))
						chessman = new King();

					SetColor(chessman, row);

					chessboard[row, collumn] = new BoardCell(row, collumn, chessman);
				}
			}

			return chessboard;
		}

		static void SetColor(BaseChessman chessman, int row)
		{
			chessman.Color = IsStartBlackRow(row) ? Color.Black : Color.White;
		}

		static bool IsStartBlackRow(int row)
		{
			return row == 1 || row == 0;
		}

		static bool IsStartPawnRow(int row)
		{
			return row == 1 || row == 6;
		}

		static bool IsStartRookCell(int row, int collumn)
		{
			return (row == 0 && collumn == 0)
				|| (row == 0 && collumn == 7)
				|| (row == 7 && collumn == 0)
				|| (row == 7 && collumn == 7);
		}

		static bool IsStartKnightCell(int row, int collumn)
		{
			return (row == 0 && collumn == 1)
				|| (row == 0 && collumn == 6)
				|| (row == 7 && collumn == 1)
				|| (row == 7 && collumn == 6);
		}

		static bool IsStartBishopCell(int row, int collumn)
		{
			return (row == 0 && collumn == 2)
				|| (row == 0 && collumn == 5)
				|| (row == 7 && collumn == 2)
				|| (row == 7 && collumn == 5);
		}

		static bool IsStartQueenCell(int row, int collumn)
		{
			return (row == 0 && collumn == 3)
				|| (row == 7 && collumn == 3);
		}

		static bool IsStartKingCell(int row, int collumn)
		{
			return (row == 0 && collumn == 4)
				|| (row == 7 && collumn == 4);
		}
	}
}
