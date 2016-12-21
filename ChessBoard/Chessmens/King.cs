using System;
using System.Collections.Generic;

namespace ChessBoard.Chessmens
{
	public class King : BaseChessman
	{
		public override ChessmenType Type => ChessmenType.King;

		public King()
		{ }

		public King(Color color) : base(color)
		{ }

		public override bool Equals(object obj)
		{
			if (!(obj is King))
				return false;

			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override List<Cell> GetAcceptableCells(
			BoardCell[,] boardCells, 
			Cell currentCell,
			bool needToCheckShah = true)
		{
			throw new NotImplementedException();
		}
	}
}
