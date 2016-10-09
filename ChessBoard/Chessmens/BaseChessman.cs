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

		protected bool IsCellInBound(int row, int collumn)
		{
			if (row < 0 || row > 7 || collumn < 0 || collumn > 7)
				return false;

			return true;
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
	}
}
