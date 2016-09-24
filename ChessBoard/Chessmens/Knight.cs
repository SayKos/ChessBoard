namespace ChessBoard.Chessmens
{
	public class Knight : BaseChessman
	{
		public override ChessmenType Type => ChessmenType.Knight;

		public Knight()
		{ }

		public Knight(Color color) : base(color)
		{ }

		public override bool Equals(object obj)
		{
			if (!(obj is Knight))
				return false;

			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode() ^ Type.GetHashCode();
		}
	}
}
