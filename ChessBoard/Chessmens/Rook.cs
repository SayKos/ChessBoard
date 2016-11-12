using System;
using System.Collections.Generic;

namespace ChessBoard.Chessmens
{
	public class Rook : BaseChessman
	{
		public override ChessmenType Type => ChessmenType.Rook;

		public Rook()
		{ }

		public Rook(Color color) : base(color)
		{ }

		public override bool Equals(object obj)
		{
			if (!(obj is Rook))
				return false;

			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override List<Cell> GetAcceptableCells(BoardCell[,] boardCells, Cell currentCell)
		{
			Direction[] possibleDirections =
			{
				new Direction {Row = -1, Column = 0},
				new Direction {Row = 1, Column = 0},
				new Direction {Row = 0, Column = -1},
				new Direction {Row = 0, Column = 1}
			};

			var acceptableCells = GetAcceptableCellsForLongMovements(boardCells, possibleDirections, currentCell);

			// todo: Adjust Acceptable Cells In Case Shah

			return acceptableCells;
		}
	}
}
