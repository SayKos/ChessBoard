namespace ChessBoard.Chessmens
{
	public class Bishop : BaseChessman
	{
		public override ChessmenType Type => ChessmenType.Bishop;

		public Bishop()
		{ }

		public Bishop(Color color) : base(color)
		{ }

		public override bool Equals(object obj)
		{
			if (!(obj is Bishop))
				return false;

			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode() ^ Type.GetHashCode();
		}
	}
}
