using System;
using System.Collections.Generic;
using System.Linq;
using ChessBoard.Chessmens;
using Newtonsoft.Json;

namespace ChessBoard
{
	public class ChessBoard
	{
		public BoardCell[,] BoardCells { get; set; }
		public GameStatus Status;

		public ChessBoard() { }

		public ChessBoard(BoardCell[,] boardCells)
		{
			BoardCells = boardCells;
		}

		public ChessBoard(string serializedChessboard)
		{
			ChessBoard deserialisedChessBoard = JsonConvert.DeserializeObject<ChessBoard>(serializedChessboard);
			ChessBoardBuilder.NormilizedBoardCells(deserialisedChessBoard.BoardCells);

			BoardCells = deserialisedChessBoard.BoardCells;
			Status = deserialisedChessBoard.Status;
		}

		public void SetStartPosition()
		{
			BoardCells = ChessBoardBuilder.GetStartPositionBoardCells();
			Status = GameStatus.WhiteTurn;
		}

		public string GetSerializedChessBoard()
		{
			return JsonConvert.SerializeObject(this);
		}

		public void MoveChessman(
			Cell oldPosition,
			Cell newPosition,
			ChessmenType? newType = null)
		{
			FailIfArgumnetsAreNull(oldPosition, newPosition);

			var chessman = BoardCells[oldPosition.Row, oldPosition.Column].Chessman;

			FailIfWrongColorAndStatus(chessman.Color);
			FailIfWrongNewPosition(oldPosition, newPosition);

			MakeCastlingIfPossible(chessman, oldPosition, newPosition);
			ChangeTypeInCasePawnAndPossible(ref chessman, newPosition, newType);

			BoardCells[oldPosition.Row, oldPosition.Column].Chessman = null;
			BoardCells[newPosition.Row, newPosition.Column].Chessman = chessman;

			chessman.Moved = true;

			// todo: switch turn if correct status
		}

		public List<Cell> GetAcceptableCells(Cell cell)
		{
			if (cell == null)
				throw new ArgumentException(nameof(cell));

			var chessman = BoardCells[cell.Row, cell.Column].Chessman;

			return chessman.GetAcceptableCells(BoardCells, cell);
		}

		public void GiveUp(Color color)
		{
			Status = color == Color.White ? GameStatus.BlackWin : GameStatus.WhiteWin;
		}

		void MakeCastlingIfPossible(
			BaseChessman chessman,
			Cell oldPosition,
			Cell newPosition)
		{
			if (chessman.Type != ChessmenType.King || !(chessman is King))
				return;

			var isCastling = Math.Abs(oldPosition.Column - newPosition.Column) == 2;

			if(!isCastling)
				return;

			var isLeftCastling = oldPosition.Column > newPosition.Column;
			var oldRookColumn = isLeftCastling ? 0 : 7;
			var newRookColumn = isLeftCastling ? 3 : 5;

			var rook = new Rook(chessman.Color);

			BoardCells[oldPosition.Row, oldRookColumn].Chessman = null;
			BoardCells[oldPosition.Row, newRookColumn].Chessman = rook;
		}

		static void ChangeTypeInCasePawnAndPossible(
			ref BaseChessman chessman,
			Cell newPosition,
			ChessmenType? newType)
		{
			if (chessman.Type != ChessmenType.Pawn || !((Pawn)chessman).IsLastRow(newPosition.Row))
				return;

			if (!newType.HasValue)
				throw new ArgumentException("New type should be set");

			if (newType == ChessmenType.Pawn || newType == ChessmenType.King)
				throw new ArgumentException("New type can not be Pawn or King");

			chessman = ChessmanFactory.TryToCreateChessman(chessman.Color, newType.Value);
		}

		void FailIfWrongNewPosition(Cell oldPosition, Cell newPosition)
		{
			var acceptableCells = GetAcceptableCells(oldPosition);

			if(!acceptableCells.Any(cell => cell.Equals(newPosition)))
				throw new ArgumentException("New position for the chessman is not acceptable");
		}

		static void FailIfArgumnetsAreNull(Cell oldPosition, Cell newPosition)
		{
			if(oldPosition == null || newPosition == null)
				throw new ArgumentException("oldPosition and newPosition should not by null.");
		}

		void FailIfWrongColorAndStatus(Color color)
		{
			if(IsGameOver())
				throw new ArgumentException("Game over. It is not possible to move any chessman.");

			if ((color == Color.White && IsMovementAvailableForColor(Color.Black))
				|| (color == Color.Black && IsMovementAvailableForColor(Color.White)))
				throw new ArgumentException("Inconsistent game status and chessman color.");
		}

		bool IsGameOver()
		{
			return Status == GameStatus.WhiteWin 
				|| Status == GameStatus.BlackWin 
				|| Status == GameStatus.StalemateOrDraw;
		}

		bool IsMovementAvailableForColor(Color color)
		{
			if (color == Color.White)
				return Status == GameStatus.ShahForWhite || Status == GameStatus.WhiteTurn;

			return Status == GameStatus.ShahForBlack || Status == GameStatus.BlackTurn;
		}
	}
}
