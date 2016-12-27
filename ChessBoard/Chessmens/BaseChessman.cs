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
		public bool Moved { get; set; }

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

			return chessmen.Color == Color && chessmen.Type == Type && chessmen.Moved == Moved;
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

		protected Direction[] AnyDirections =
		{
			new Direction {Row = -1, Column = -1},
			new Direction {Row = -1, Column = 1},
			new Direction {Row = 1, Column = -1},
			new Direction {Row = 1, Column = 1},
			new Direction {Row = -1, Column = 0},
			new Direction {Row = 1, Column = 0},
			new Direction {Row = 0, Column = -1},
			new Direction {Row = 0, Column = 1}
		};

		protected bool IsCellInBounds(Cell cell)
		{
			return cell.Row >= 0 
				&& cell.Row <= 7 
				&& cell.Column >= 0 
				&& cell.Column <= 7;
		}

		protected List<Cell> GetAcceptableCellsForDirections(
			BoardCell[,] boardCells,
			Direction[] possibleDirections,
			Cell currentCell,
			int stepsCount = 8)
		{
			var acceptableCells = new List<Cell>();

			foreach (var direction in possibleDirections)
			{
				for (var movementSteps = 0; movementSteps < stepsCount; movementSteps++)
				{
					var nextRow = currentCell.Row + GetStepsCoutForMovement(direction.Row, movementSteps);
					var nextColumn = currentCell.Column + GetStepsCoutForMovement(direction.Column, movementSteps);

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
			List<Cell> cellsToRemove = new List<Cell>();

			foreach (var acceptableCell in acceptableCells)
				if(IsKingUnderShah(boardCells, acceptableCell, currentCell))
					cellsToRemove.Add(acceptableCell);

			foreach (var cellToRemove in cellsToRemove)
				acceptableCells.Remove(cellToRemove);
		}

		protected bool IsKingUnderShah(
			BoardCell[,] boardCells,
			Cell cellToCheck,
			Cell currentCell)
		{
			var testBoardCells = GetDeepCopyOfBoardCells(boardCells);

			TestMoveChessman(testBoardCells, currentCell, cellToCheck);

			var kingCell = FindKingCell(testBoardCells);

			return IsCellUnderShah(testBoardCells, kingCell);
		}

		protected bool IsCellUnderShah(
			BoardCell[,] boardCells,
			Cell cellToCheck)
		{
			var enemyAcceptableCells = FindEnemyAcceptableCells(boardCells);

			return enemyAcceptableCells.Any(enemyCell =>
				enemyCell.Row == cellToCheck.Row && enemyCell.Column == cellToCheck.Column);
		}

		protected bool IfEmptyOrEnemy(BoardCell[,] boardCells, int testRow, int testColumn)
		{
			return boardCells[testRow, testColumn].IsEmpty()
				   || boardCells[testRow, testColumn].Chessman.Color != Color;
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

		private void TestMoveChessman(
			BoardCell[,] chessboard,
			Cell oldCell,
			Cell newCell)
		{
			chessboard[newCell.Row, newCell.Column].Chessman = chessboard[oldCell.Row, oldCell.Column].Chessman;
			chessboard[oldCell.Row, oldCell.Column].Chessman = null;
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
