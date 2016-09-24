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
			return base.GetHashCode() ^ Type.GetHashCode();
		}
	}
}
