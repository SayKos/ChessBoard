namespace ChessBoard.Chessmens
{
	public class King: BaseChessman
	{
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
			return base.GetHashCode() ^ "Rook".GetHashCode();
		}
	}
}
