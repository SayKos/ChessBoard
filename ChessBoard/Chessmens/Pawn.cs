namespace ChessBoard.Chessmens
{
	public class Pawn : BaseChessman
	{
		public override ChessmenType Type => ChessmenType.Pawn;

		public Pawn()
		{ }

		public Pawn(Color color) : base(color)
		{ }

		public bool IsLastRow(int row)
		{
			if (Color == Color.White && row == 0)
				return true;

			if (Color == Color.Black && row == 7)
				return true;

			return false;
		}

		public void SetNewType(ChessmenType newType)
		{
			Type = newType;
		}

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
