using System.Collections.Generic;

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

		public override List<Cell> GetAcceptableCells(BoardCell[,] boardCells, Cell currentCell)
		{
			List<Cell> acceptableCells = new List<Cell>();

			acceptableCells.AddRange(GetFrontCells(boardCells, currentCell));

			return acceptableCells;
		}

		private List<Cell> GetFrontCells(BoardCell[,] boardCells, Cell currentCell)
		{
			List<Cell> acceptableCells = new List<Cell>();

			acceptableCells.Add(GetNextFrontCellIfPossible(boardCells, currentCell, 1));

			if (NeedToCheckNextFrontCell(currentCell.Row, acceptableCells.Count))
				acceptableCells.Add(GetNextFrontCellIfPossible(boardCells, currentCell, 2));

			return acceptableCells;
		}

		private bool NeedToCheckNextFrontCell(int currentRow, int addedCellsCount)
		{
			int startRowPosition = Color == Color.White ? 6 : 1;
			return currentRow == startRowPosition && addedCellsCount > 0;
		}

		private Cell GetNextFrontCellIfPossible(BoardCell[,] boardCells, Cell currentCell, int nextRowCount)
		{
			var currentRow = currentCell.Row;
			var currentColumn = currentCell.Column;
			var nextRow = Color == Color.White ? currentRow - nextRowCount : currentRow + nextRowCount;
			var cell = new Cell(nextRow, currentColumn);

			return IsCellEmptyAndInBounds(boardCells, cell) ? cell : null;
		}

		private bool IsCellEmptyAndInBounds(BoardCell[,] boardCells, Cell cell)
		{
			return IsCellInBounds(cell) && boardCells[cell.Row, cell.Column].IsEmpty();
		}
	}
}
