namespace ChessBoard.Chessmens
{
	public class BaseChessman
	{
		public Color Color { get; set; }

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

			return ((BaseChessman) obj).Color == Color;
		}

		public override int GetHashCode()
		{
			return (int)Color;
		}
	}
}
