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
	}
}
