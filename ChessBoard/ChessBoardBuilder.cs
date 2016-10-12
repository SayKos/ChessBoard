using System.Linq;
using ChessBoard.Chessmens;

namespace ChessBoard
{
	public static class ChessBoardBuilder
	{
		public static BoardCell[,] GetStartPositionBoardCells()
		{
			BoardCell[,] chessboard = new BoardCell[8, 8];
			int[] startRows = { 0, 1, 6, 7 };

			for (int row = 0; row <= 7; row++)
			{
				for (int column = 0; column <= 7; column++)
				{
					if (!startRows.Any(x => x == row))
					{
						chessboard[row, column] = new BoardCell(row, column);
						continue;
					}

					var chessman = ChessmanFactory.TryToCreateChessman(row, column);

					SetColor(chessman, row);

					chessboard[row, column] = new BoardCell(row, column, chessman);
				}
			}

			return chessboard;
		}

		public static void GetNormilizedBoardCells(BoardCell[,] boardCells)
		{
			for (int row = 0; row <= 7; row++)
			{
				for (int column = 0; column <= 7; column++)
				{
					var chessman = boardCells[row, column].Chessman;

					if (chessman == null)
						continue;

					boardCells[row, column].Chessman = ChessmanFactory.TryToCreateChessman(chessman.Color, chessman.Type);
				}
			}
		}

		static void SetColor(BaseChessman chessman, int row)
		{
			chessman.Color = IsStartBlackRow(row) ? Color.Black : Color.White;
		}

		static bool IsStartBlackRow(int row)
		{
			return row == 1 || row == 0;
		}
	}
}
