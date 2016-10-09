using System;
using ChessBoard.Chessmens;

namespace ChessBoard
{
	public static class ChessmanFactory
	{
		public static BaseChessman TryToConvertChessman(BaseChessman chessman, ChessmenType? newType)
		{
			if (!newType.HasValue)
				throw new ArgumentException("New type should be set if it's pawn and last row");

			return TryToCreateChessman(chessman.Color, newType.Value);
		}

		public static BaseChessman TryToCreateChessman(Color color, ChessmenType type)
		{
			switch (type)
			{
				case ChessmenType.Pawn: return new Pawn(color);
				case ChessmenType.Rook: return new Rook(color);
				case ChessmenType.Knight: return new Knight(color);
				case ChessmenType.Bishop: return new Bishop(color);
				case ChessmenType.Queen: return new Queen(color);
				case ChessmenType.King: return new King(color);
			}

			throw new ArgumentException("Wrong ChessmenType. It is not possible to set correct chessman.");
		}

		public static BaseChessman TryToCreateChessman(int row, int column)
		{
			if (IsStartPawnRow(row))
				return new Pawn();

			if (IsStartRookCell(row, column))
				return new Rook();

			if (IsStartKnightCell(row, column))
				return new Knight();

			if (IsStartBishopCell(row, column))
				return new Bishop();

			if (IsStartQueenCell(row, column))
				return new Queen();

			if (IsStartKingCell(row, column))
				return new King();

			throw new ArgumentException("Wrong row or column. It is not possible to set correct chessman.");
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
