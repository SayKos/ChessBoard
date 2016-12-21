using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

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

		public virtual List<Cell> GetAcceptableCells(
			BoardCell[,] boardCells, 
			Cell currentCell, 
			bool needToCheckShah = true)
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

		protected void AdjustAcceptableCellsInCaseShah(
			BoardCell[,] boardCells, 
			List<Cell> acceptableCells,
			Cell currentCell)
		{
			Cell kingCell = FindKingCell(boardCells);

			List<Cell> cellsToRemove = new List<Cell>();

			foreach (var acceptableCell in acceptableCells)
			{
				BoardCell[,] testBoardCells = GetDeepCopyOfBoardCells(boardCells);

				TestMoveChessman(testBoardCells, currentCell.Row, currentCell.Column, acceptableCell.Row, acceptableCell.Column);

				List<Cell> enemyAcceptableCells = FindEnemyAcceptableCells(testBoardCells);

				if (enemyAcceptableCells.Any(enemyCell => 
					enemyCell.Row == kingCell.Row && enemyCell.Column == kingCell.Column))
				{
					cellsToRemove.Add(acceptableCell);
				}
			}

			foreach (var cellToRemove in cellsToRemove)
				acceptableCells.Remove(cellToRemove);
		}

		private Cell FindKingCell(BoardCell[,] boardCells)
		{
			for (int row = 0; row < 8; row++)
			{
				for (int column = 0; column < 8; column++)
				{
					BaseChessman chessman = boardCells[row, column].Chessman;

					if (chessman is King && chessman.Color == Color)
						return new Cell(row, column);
				}
			}

			throw new ArgumentException("King has not found.");
		}

		private List<Cell> FindEnemyAcceptableCells(BoardCell[,] boardCells)
		{
			var enemyAcceptableCells = new List<Cell>();

			for (var row = 0; row < 8; row++)
			{
				for (var column = 0; column < 8; column++)
				{
					BaseChessman chessman = boardCells[row, column].Chessman;

					if(chessman == null || chessman.Color == Color || chessman is King)
						continue;

					var cell = new Cell(row, column);
					enemyAcceptableCells.AddRange(chessman.GetAcceptableCells(boardCells, cell, false));
				}
			}

			return enemyAcceptableCells;
		}

		private void TestMoveChessman(BoardCell[,] chessboard, int oldRow, int oldColumn, int newRow, int newColumn)
		{
			chessboard[newRow, newColumn].Chessman = chessboard[oldRow, oldColumn].Chessman;
			chessboard[oldRow, oldColumn].Chessman = null;
		}

		private BoardCell[,] GetDeepCopyOfBoardCells(BoardCell[,] boardCells)
		{
			var serializedChessboard = JsonConvert.SerializeObject(boardCells);
			var deserializedBoarCells = JsonConvert.DeserializeObject<BoardCell[,]>(serializedChessboard);

			ChessBoardBuilder.NormilizedBoardCells(deserializedBoarCells);

			return deserializedBoarCells;
		}

		private int GetStepsCoutForMovement(int direction, int movementSteps)
		{
			if (direction == 0)
				return 0;

			return direction + (direction == -1 ? movementSteps * -1 : movementSteps);
		}
	}
}
