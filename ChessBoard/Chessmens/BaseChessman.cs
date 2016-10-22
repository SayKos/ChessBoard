using System;

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

		public virtual Cell[] GetAcceptableCells()
		{
			throw new NotImplementedException();
		}
	}
}
