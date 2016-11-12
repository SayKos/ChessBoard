using System;
using System.Collections.Generic;

namespace ChessBoard.Chessmens
{
	public class Queen : BaseChessman
	{
		public override ChessmenType Type => ChessmenType.Queen;

		public Queen()
		{ }

		public Queen(Color color) : base(color)
		{ }

		public override bool Equals(object obj)
		{
			if (!(obj is Queen))
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
				new Direction {Row = -1, Column = -1},
				new Direction {Row = -1, Column = 1},
				new Direction {Row = 1, Column = -1},
				new Direction {Row = 1, Column = 1},
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
