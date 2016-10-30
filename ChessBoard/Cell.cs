namespace ChessBoard
{
	public class Cell
	{
		public int Row { get; set; }
		public int Column { get; set; }

		public Cell() { }

		public Cell(int row, int column)
		{
			Row = row;
			Column = column;
		}

		public override bool Equals(object obj)
		{
			var cell = obj as Cell;

			if (cell == null)
				return false;

			return Row == cell.Row && Column == cell.Column;
		}

		public override int GetHashCode()
		{
			return Row.GetHashCode() ^ Column.GetHashCode();
		}

		public override string ToString()
		{
			return $"Row: {Row}, Column: {Column}";
		}
	}
}
