using ChessBoard.Chessmens;

namespace ChessBoard
{
	public class BoardCell : Cell
	{
		public BaseChessman Chessman { get; set; }

		public BoardCell() { }

		public BoardCell(int row, int column)
			: base(row, column)
		{ }

		public BoardCell(int row, int column, BaseChessman chessman)
			: base(row, column)
		{
			Chessman = chessman;
		}

		public bool IsEmpty()
		{
			return Chessman == null;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is BoardCell))
				return false;

			var cell = (BoardCell)obj;

			if (Chessman.GetType() != cell.Chessman.GetType())
				return false;

			return Chessman.Equals(cell.Chessman) && Row == cell.Row && Column == cell.Column;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode() ^ Chessman?.GetHashCode() ?? 0 ^ Row ^ Column;
		}
	}
}
