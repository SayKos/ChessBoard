﻿using System.Collections.Generic;

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

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override List<Cell> GetAcceptableCells(
			BoardCell[,] boardCells, 
			Cell currentCell,
			bool needToCheckShah = true)
		{
			acceptableCells = new List<Cell>();

			AddFrontCellsIfPossible(boardCells, currentCell);
			AddPositionsIfCanKillEnemy(boardCells, currentCell);

			if(needToCheckShah)
				AdjustAcceptableCellsInCaseShah(boardCells, acceptableCells, currentCell);

			return acceptableCells;
		}

		void AddFrontCellsIfPossible(BoardCell[,] boardCells, Cell currentCell)
		{
			var count = acceptableCells.Count;

			AddNextFrontCellIfPossible(boardCells, currentCell, 1);

			if (NeedToCheckNextFrontCell(currentCell.Row) && acceptableCells.Count > count)
				AddNextFrontCellIfPossible(boardCells, currentCell, 2);
		}

		bool NeedToCheckNextFrontCell(int currentRow)
		{
			int startRowPosition = Color == Color.White ? 6 : 1;
			return currentRow == startRowPosition;
		}

		void AddNextFrontCellIfPossible(BoardCell[,] boardCells, Cell currentCell, int nextRowCount)
		{
			var currentRow = currentCell.Row;
			var currentColumn = currentCell.Column;
			var nextRow = GetNextRowToTest(nextRowCount, currentRow);
			var cell = new Cell(nextRow, currentColumn);

			if (IsCellEmptyAndInBounds(boardCells, cell))
				acceptableCells.Add(cell);
		}

		int GetNextRowToTest(int nextRowCount, int currentRow)
		{
			return Color == Color.White ? currentRow - nextRowCount : currentRow + nextRowCount;
		}

		bool IsCellEmptyAndInBounds(BoardCell[,] boardCells, Cell cell)
		{
			return IsCellInBounds(cell) && boardCells[cell.Row, cell.Column].IsEmpty();
		}

		void AddPositionsIfCanKillEnemy(BoardCell[,] chessboard, Cell currentCell)
		{
			var nextRow = GetNextRowToTest(1, currentCell.Row);

			var testCollumn = currentCell.Column - 1;
			AddIfEnemyExistAndIfInBounds(chessboard, nextRow, testCollumn);

			testCollumn = currentCell.Column + 1;
			AddIfEnemyExistAndIfInBounds(chessboard, nextRow, testCollumn);
		}

		void AddIfEnemyExistAndIfInBounds(BoardCell[,] board, int row, int collumn)
		{
			var cell = new Cell(row, collumn);

			if (!IsCellInBounds(cell))
				return;

			if (!board[row, collumn].IsEmpty() && board[row, collumn].Chessman.Color != Color)
				acceptableCells.Add(cell);
		}
	}
}
