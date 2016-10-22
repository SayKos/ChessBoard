using System;
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
			ChessBoardBuilder.GetNormilizedBoardCells(deserialisedChessBoard.BoardCells);

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

		public void MoveChessman(BaseChessman chessman, Cell oldPosition, Cell newPosition, ChessmenType? newType = null)
		{
			FailIfArgumnetsAreNull(chessman, oldPosition, newPosition);
			FailIfWrongStatus(chessman);

			// todo: check if cell is acceptable for the chessman - throw exception if not (and add test for this)

			if (chessman.Type == ChessmenType.Pawn && ((Pawn)chessman).IsLastRow(newPosition.Row))
				chessman = ChessmanFactory.TryToConvertChessman(chessman, newType);

			BoardCells[oldPosition.Row, oldPosition.Column].Chessman = null;
			BoardCells[newPosition.Row, newPosition.Column].Chessman = chessman;

			// todo: switch turn if correct status
		}

		void FailIfArgumnetsAreNull(BaseChessman chessman, Cell oldPosition, Cell newPosition)
		{
			if(chessman == null || oldPosition == null || newPosition == null)
				throw new ArgumentException("chessman, oldPosition and newPosition should not by null.");
		}

		void FailIfWrongStatus(BaseChessman chessman)
		{
			if(IsGameOver())
				throw new ArgumentException("Game over. It is not possible to move any chessman.");

			if ((chessman.Color == Color.White && IsMovementAvailableForColor(Color.Black))
				|| (chessman.Color == Color.Black && IsMovementAvailableForColor(Color.White)))
				throw new ArgumentException("Inconsistent game status and chessman color.");
		}

		bool IsGameOver()
		{
			return Status == GameStatus.CheckmateForWhite 
				|| Status == GameStatus.CheckmateForBlack 
				|| Status == GameStatus.StalemateForWhite
				|| Status == GameStatus.StalemateForBlack;
		}

		bool IsMovementAvailableForColor(Color color)
		{
			if (color == Color.White)
				return Status == GameStatus.ShahForWhite || Status == GameStatus.WhiteTurn;

			return Status == GameStatus.ShahForBlack || Status == GameStatus.BlackTurn;
		}
	}
}
