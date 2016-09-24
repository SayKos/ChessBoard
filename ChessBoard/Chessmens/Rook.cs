namespace ChessBoard.Chessmens
{
	public class Rook : BaseChessman
	{
		public Rook()
		{ }

		public Rook(Color color) : base(color)
		{ }

		public override bool Equals(object obj)
		{
			if (!(obj is Rook))
				return false;

			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode() ^ "Rook".GetHashCode();
		}
	}
}
