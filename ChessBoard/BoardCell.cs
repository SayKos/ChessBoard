using ChessBoard.Chessmens;

namespace ChessBoard
{
	public class BoardCell
	{
		public int Row { get; set; }
		public int Column { get; set; }
		public BaseChessman Chessman { get; set; }

		public BoardCell(int row, int column, BaseChessman chessman)
		{
			Row = row;
			Column = column;
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

			var cell = (BoardCell) obj;

			return Chessman.Equals(cell.Chessman) && Row == cell.Row && Column == cell.Column;
		}

		public override int GetHashCode()
		{
			return Chessman.GetHashCode() ^ Row ^ Column;
		}
	}
}
