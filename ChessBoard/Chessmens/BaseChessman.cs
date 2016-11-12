using System;
using System.Collections.Generic;

namespace ChessBoard.Chessmens
{
	public class BaseChessman
	{
		public Color Color { get; set; }
		public virtual ChessmenType Type { get; set; }

		public BaseChessman()
		{ }

		public BaseChessman(Color color)
		{
			Color = color;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;

			var chessmen = (BaseChessman)obj;

			return chessmen.Color == Color && chessmen.Type == Type;
		}

		public override int GetHashCode()
		{
			int hash = 17;
			hash = hash * 23 + (int)Color;
			hash = hash * 23 + (int)Type;
			return hash;
		}

		public virtual List<Cell> GetAcceptableCells(BoardCell[,] boardCells, Cell currentCell)
		{
			throw new NotImplementedException();
		}

		protected bool IsCellInBounds(Cell cell)
		{
			return cell.Row >= 0 
				&& cell.Row <= 7 
				&& cell.Column >= 0 
				&& cell.Column <= 7;
		}

		protected List<Cell> GetAcceptableCellsForLongMovements(
			BoardCell[,] boardCells,
			Direction[] possibleDirections,
			Cell currentCell)
		{
			var acceptableCells = new List<Cell>();

			foreach (var direction in possibleDirections)
			{
				for (var movementSteps = 0; movementSteps <= 7; movementSteps++)
				{
					int nextRow = currentCell.Row + GetStepsCoutForMovement(direction.Row, movementSteps);
					int nextColumn = currentCell.Column + GetStepsCoutForMovement(direction.Column, movementSteps);

					if (!IsCellInBounds(new Cell(nextRow, nextColumn)))
						break;

					var currentBoardCell = boardCells[nextRow, nextColumn];
					var currentChessman = currentBoardCell.Chessman;
					var cell = new Cell(currentBoardCell.Row, currentBoardCell.Column);

					if (currentChessman != null)
					{
						if (currentChessman.Color != Color)
							acceptableCells.Add(cell);

						break;
					}

					acceptableCells.Add(cell);
				}
			}

			return acceptableCells;
		}

		private int GetStepsCoutForMovement(int direction, int movementSteps)
		{
			if (direction == 0)
				return 0;

			return direction + (direction == -1 ? movementSteps * -1 : movementSteps);
		}
	}
}
