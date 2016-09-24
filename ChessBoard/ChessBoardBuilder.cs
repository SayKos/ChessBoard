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
				for (int column = 0; column <= 7; column++)
				{
					BaseChessman chessman = null;

					if (IsStartPawnRow(row))
						chessman = new Pawn();

					else if (IsStartRookCell(row, column))
						chessman = new Rook();

					else if (IsStartKnightCell(row, column))
						chessman = new Knight();

					else if (IsStartBishopCell(row, column))
						chessman = new Bishop();

					else if (IsStartQueenCell(row, column))
						chessman = new Queen();

					else if (IsStartKingCell(row, column))
						chessman = new King();

					SetColor(chessman, row);

					chessboard[row, column] = new BoardCell(row, column, chessman);
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

		static bool IsStartRookCell(int row, int column)
		{
			return (row == 0 && column == 0)
				|| (row == 0 && column == 7)
				|| (row == 7 && column == 0)
				|| (row == 7 && column == 7);
		}

		static bool IsStartKnightCell(int row, int column)
		{
			return (row == 0 && column == 1)
				|| (row == 0 && column == 6)
				|| (row == 7 && column == 1)
				|| (row == 7 && column == 6);
		}

		static bool IsStartBishopCell(int row, int column)
		{
			return (row == 0 && column == 2)
				|| (row == 0 && column == 5)
				|| (row == 7 && column == 2)
				|| (row == 7 && column == 5);
		}

		static bool IsStartQueenCell(int row, int column)
		{
			return (row == 0 && column == 3)
				|| (row == 7 && column == 3);
		}

		static bool IsStartKingCell(int row, int column)
		{
			return (row == 0 && column == 4)
				|| (row == 7 && column == 4);
		}
	}
}
