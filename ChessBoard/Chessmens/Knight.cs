namespace ChessBoard.Chessmens
{
	public class Knight: BaseChessman
	{
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
			return base.GetHashCode() ^ "Rook".GetHashCode();
		}
	}
}
