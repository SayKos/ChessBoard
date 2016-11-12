using System.Collections.Generic;

namespace ChessBoard.Chessmens
{
	public class Pawn : BaseChessman
	{
		public override ChessmenType Type => ChessmenType.Pawn;
		List<Cell> acceptableCells;

		public Pawn()
		{ }

		public Pawn(Color color) : base(color)
		{ }

		public bool IsLastRow(int row)
		{
			if (Color == Color.White && row == 0)
				return true;

			return Color == Color.Black && row == 7;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Pawn))
				return false;

			return base.Equals(obj);
		}

		public override List<Cell> GetAcceptableCells(BoardCell[,] boardCells, Cell currentCell)
		{
			acceptableCells = new List<Cell>();

			AddFrontCellsIfPossible(boardCells, currentCell);
			AddPositionsIfCanKillEnemy(boardCells, currentCell);

			// todo: Adjust Acceptable Cells In Case Shah

			return acceptableCells;
		}

		private void AddFrontCellsIfPossible(BoardCell[,] boardCells, Cell currentCell)
		{
			var count = acceptableCells.Count;

			AddNextFrontCellIfPossible(boardCells, currentCell, 1);

			if (NeedToCheckNextFrontCell(currentCell.Row) && acceptableCells.Count > count)
				AddNextFrontCellIfPossible(boardCells, currentCell, 2);
		}

		private bool NeedToCheckNextFrontCell(int currentRow)
		{
			int startRowPosition = Color == Color.White ? 6 : 1;
			return currentRow == startRowPosition;
		}

		private void AddNextFrontCellIfPossible(BoardCell[,] boardCells, Cell currentCell, int nextRowCount)
		{
			var currentRow = currentCell.Row;
			var currentColumn = currentCell.Column;
			var nextRow = GetNextRowToTest(nextRowCount, currentRow);
			var cell = new Cell(nextRow, currentColumn);

			if (IsCellEmptyAndInBounds(boardCells, cell))
				acceptableCells.Add(cell);
		}

		private int GetNextRowToTest(int nextRowCount, int currentRow)
		{
			return Color == Color.White ? currentRow - nextRowCount : currentRow + nextRowCount;
		}

		private bool IsCellEmptyAndInBounds(BoardCell[,] boardCells, Cell cell)
		{
			return IsCellInBounds(cell) && boardCells[cell.Row, cell.Column].IsEmpty();
		}

		private void AddPositionsIfCanKillEnemy(BoardCell[,] chessboard, Cell currentCell)
		{
			var nextRow = GetNextRowToTest(1, currentCell.Row);

			var testCollumn = currentCell.Column - 1;
			AddIfEnemyExistAndIfInBounds(chessboard, nextRow, testCollumn);

			testCollumn = currentCell.Column + 1;
			AddIfEnemyExistAndIfInBounds(chessboard, nextRow, testCollumn);
		}

		private void AddIfEnemyExistAndIfInBounds(BoardCell[,] board, int row, int collumn)
		{
			if (!IsCellInBounds(new Cell(row, collumn)))
				return;

			if (!board[row, collumn].IsEmpty() && board[row, collumn].Chessman.Color != Color)
				acceptableCells.Add(new Cell(row, collumn));
		}
	}
}
