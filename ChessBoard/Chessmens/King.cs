using System.Collections.Generic;

namespace ChessBoard.Chessmens
{
	public class King : BaseChessman
	{
		public override ChessmenType Type => ChessmenType.King;
		private int StartRow => Color == Color.White ? 7 : 0;
		private int StartColumn = 4;

		public King()
		{ }

		public King(Color color) : base(color)
		{ }

		public override bool Equals(object obj)
		{
			if (!(obj is King))
				return false;

			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override List<Cell> GetAcceptableCells(
			BoardCell[,] boardCells, 
			Cell currentCell,
			bool needToCheckShah = true)
		{
			var acceptableCells = GetAcceptableCellsForDirections(boardCells, AnyDirections, currentCell, 1);

			acceptableCells.AddRange(GetCastlingAcceptableCells(boardCells, currentCell));

			if (needToCheckShah)
				AdjustAcceptableCellsInCaseShah(boardCells, acceptableCells, currentCell);

			return acceptableCells;
		}

		private List<Cell> GetCastlingAcceptableCells(
			BoardCell[,] boardCells,
			Cell currentCell)
		{
			var acceptableCells = new List<Cell>();

			if (Moved)
				return acceptableCells;

			if(IsCellUnderShah(boardCells, currentCell))
				return acceptableCells;

			var rookStartColumns = new int[] {0, 7};
			foreach (var rookStartColumn in rookStartColumns)
			{
				var castlingCell = GetCastlingCell(boardCells, rookStartColumn);
				if (castlingCell != null)
					acceptableCells.Add(castlingCell);
			}

			return acceptableCells;
		}

		private Cell GetCastlingCell(
			BoardCell[,] boardCells,
			int rookStartColumn)
		{
			Rook rook = boardCells[StartRow, rookStartColumn].Chessman as Rook;

			if (rook == null)
				return null;

			if (rook.Moved)
				return null;

			if (!CellsBetweenRookAndKingAreEmpty(boardCells, rookStartColumn))
				return null;

			var isLeftCastling = rookStartColumn == 0;

			if (!KingCellsAreNotUnderShahWhileCastling(boardCells, isLeftCastling))
				return null;

			return new Cell(StartRow, GetNewKingColumn(isLeftCastling));
		}

		private bool CellsBetweenRookAndKingAreEmpty(
			BoardCell[,] boardCells,
			int rookStartColumn)
		{
			var isLeftCastling = rookStartColumn == 0;

			var start = isLeftCastling ? rookStartColumn : StartColumn;
			var stop = isLeftCastling ? StartColumn : rookStartColumn;

			for (var collumn = start + 1; collumn < stop; collumn++)
			{
				if (boardCells[StartRow, collumn].Chessman != null)
					return false;
			}

			return true;
		}

		private bool KingCellsAreNotUnderShahWhileCastling(
			BoardCell[,] boardCells,
			bool isLeftCastling)
		{
			var newKingColumn = GetNewKingColumn(isLeftCastling);

			var start = isLeftCastling ? newKingColumn : StartColumn;
			var stop = isLeftCastling ? StartColumn : newKingColumn;

			for (var collumn = start; collumn < stop; collumn++)
			{
				if (IsCellUnderShah(boardCells, new Cell(StartRow, collumn)))
					return false;
			}

			return true;
		}

		private int GetNewKingColumn(bool isLeftCastling)
		{
			return isLeftCastling ? 2 : 6;
		}
	}
}
