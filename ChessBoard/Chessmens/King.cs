using System;
using System.Collections.Generic;
using System.Linq;

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

			// is under atack

			var rookStartColumns = new int[] {0, 7};
			foreach (var rookStartColumn in rookStartColumns)
			{
				var castlingCell = GetCastlingCell(boardCells, currentCell, rookStartColumn);
				if (castlingCell != null)
					acceptableCells.Add(castlingCell);
			}

			return acceptableCells;
		}

		private Cell GetCastlingCell(
			BoardCell[,] boardCells,
			Cell currentCell,
			int startColumn)
		{
			Rook rook = boardCells[StartRow, startColumn].Chessman as Rook;

			if (rook == null)
				return null;

			if (rook.Moved)
				return null;

			if(!AreAllCellsBetweenRookAndKingEmpty(boardCells, startColumn))
				return null;

			if (AnyCellsBetweenRookAndKingIsUnderShah(boardCells, currentCell, startColumn))
				return null;

			return new Cell(StartRow, startColumn);
		}

		private bool AreAllCellsBetweenRookAndKingEmpty(
			BoardCell[,] boardCells,
			int rookStartColumn)
		{
			var isLeftCastling = rookStartColumn == 0;

			var start = isLeftCastling ? rookStartColumn : StartColumn;
			var stop = isLeftCastling ? StartColumn : rookStartColumn;

			for (var collumn = start + 1; collumn < stop; collumn++)
				if (boardCells[StartRow, collumn].Chessman != null)
					return false;

			return true;
		}

		private bool AnyCellsBetweenRookAndKingIsUnderShah(
			BoardCell[,] boardCells,
			Cell currentCell,
			int rookStartColumn)
		{
			var isLeftCastling = rookStartColumn == 0;

			var start = isLeftCastling ? rookStartColumn : StartColumn;
			var stop = isLeftCastling ? StartColumn : rookStartColumn;

			for (var collumn = start + 1; collumn < stop; collumn++)
			{
				var testCell = new Cell(StartRow, collumn);

				if (IsCellUnderShah(boardCells, testCell, currentCell))
					return true;
			}

			return false;
		}
	}
}
