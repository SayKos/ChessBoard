using System;
using System.Collections.Generic;

namespace ChessBoard.Chessmens
{
	public class BaseChessman
	{
		public Color Color { get; set; }
		public virtual ChessmenType Type { get; set; }

		public BaseChessman()
		{ }

		public BaseChessman(Color color)
		{
			Color = color;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;

			var chessmen = (BaseChessman)obj;

			return chessmen.Color == Color && chessmen.Type == Type;
		}

		public override int GetHashCode()
		{
			return (int)Color;
		}

		public virtual List<Cell> GetAcceptableCells(BoardCell[,] boardCells, Cell currentCell)
		{
			throw new NotImplementedException();
		}

		protected bool IsCellInBounds(Cell cell)
		{
			return cell.Row >= 0 
				&& cell.Row <= 7 
				&& cell.Column >= 0 
				&& cell.Column <= 7;
		}
	}
}
