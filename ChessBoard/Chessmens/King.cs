using System;
using System.Collections.Generic;

namespace ChessBoard.Chessmens
{
	public class King : BaseChessman
	{
		public override ChessmenType Type => ChessmenType.King;
		int StartRow => Color == Color.White ? 7 : 0;
		int StartColumn = 4;

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

			AdjustCellsInCaseNearEnemyKing(boardCells, acceptableCells, currentCell);

			return acceptableCells;
		}

		void AdjustCellsInCaseNearEnemyKing(
			BoardCell[,] boardCells, 
			List<Cell> acceptableCells, 
			Cell currentCell)
		{
			var currentKingBoardCell = boardCells[currentCell.Row, currentCell.Column];
			var enemyColor = currentKingBoardCell.Chessman.Color == Color.White ? Color.Black : Color.White;
			var enemyKingBoardCell = FindKing(boardCells, enemyColor);
			var enemyKingCell = new Cell(enemyKingBoardCell.Row, enemyKingBoardCell.Column);

			acceptableCells.RemoveAll(cell => cell.IsNextTo(enemyKingCell));
		}

		public static BoardCell FindKing(BoardCell[,] boardCells, Color currentColor)
		{
			for (var row = 0; row < 8; row++)
			{
				for (var collumn = 0; collumn < 8; collumn++)
				{
					var chessman = boardCells[row, collumn].Chessman;

					if (chessman is King && chessman.Color == currentColor)
						return new BoardCell(row, collumn, chessman as King);
				}
			}

			throw new ArgumentException("King was not found.");
		}

		List<Cell> GetCastlingAcceptableCells(
			BoardCell[,] boardCells,
			Cell currentCell)
		{
			var acceptableCells = new List<Cell>();

			if (Moved)
				return acceptableCells;

			if(IsCellUnderShah(boardCells, currentCell, Color))
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

		Cell GetCastlingCell(
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

		bool CellsBetweenRookAndKingAreEmpty(
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

		bool KingCellsAreNotUnderShahWhileCastling(
			BoardCell[,] boardCells,
			bool isLeftCastling)
		{
			var newKingColumn = GetNewKingColumn(isLeftCastling);

			var start = isLeftCastling ? newKingColumn : StartColumn;
			var stop = isLeftCastling ? StartColumn : newKingColumn;

			for (var collumn = start; collumn < stop; collumn++)
				if (IsCellUnderShah(boardCells, new Cell(StartRow, collumn), Color))
					return false;

			return true;
		}

		int GetNewKingColumn(bool isLeftCastling)
		{
			return isLeftCastling ? 2 : 6;
		}
	}
}
