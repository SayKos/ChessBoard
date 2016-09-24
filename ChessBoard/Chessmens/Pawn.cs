namespace ChessBoard.Chessmens
{
	public class Pawn: BaseChessman
	{
		public override ChessmenType Type => ChessmenType.Pawn;

		public Pawn()
		{ }

		public Pawn(Color color) : base(color)
		{ }

		public override bool Equals(object obj)
		{
			if (!(obj is Pawn))
				return false;

			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode() ^ Type.GetHashCode();
		}
	}
}
