using System;
using System.Collections.Generic;

namespace ChessBoard.Chessmens
{
	public class Knight : BaseChessman
	{
		public override ChessmenType Type => ChessmenType.Knight;

		public Knight()
		{ }

		public Knight(Color color) : base(color)
		{ }

		public override bool Equals(object obj)
		{
			if (!(obj is Knight))
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
			var acceptableCells = new List<Cell>();

			Movement[] possibleMovements =
			{
				new Movement { Row = -1 , Column = -2 },
				new Movement { Row = -1 , Column = 2 },
				new Movement { Row = 1 , Column = -2 },
				new Movement { Row = 1 , Column = 2 },
				new Movement { Row = -2 , Column = -1 },
				new Movement { Row = -2 , Column = 1 },
				new Movement { Row = 2 , Column = -1 },
				new Movement { Row = 2 , Column = 1 },
			};

			foreach (var possibleMovement in possibleMovements)
			{
				var testRow = currentCell.Row + possibleMovement.Row;
				var testColumn = currentCell.Column + possibleMovement.Column;
				var cell = new Cell(testRow, testColumn);

				if(!IsCellInBounds(cell))
					continue;

				if (IfEmptyOrEnemy(boardCells, testRow, testColumn))
					acceptableCells.Add(cell);
			}

			if (needToCheckShah)
				AdjustAcceptableCellsInCaseShah(boardCells, acceptableCells, currentCell);

			return acceptableCells;
		}

		private bool IfEmptyOrEnemy(BoardCell[,] boardCells, int testRow, int testColumn)
		{
			return boardCells[testRow, testColumn].IsEmpty()
			       || boardCells[testRow, testColumn].Chessman.Color != Color;
		}
	}
}
