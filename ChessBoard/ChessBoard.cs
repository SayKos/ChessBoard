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
			Status = GameStatus.Normal;
		}

		public string GetSerializedChessBoard()
		{
			return JsonConvert.SerializeObject(this);
		}

		public void MoveChessman(BaseChessman chessman, Cell oldPosition, Cell newPosition, ChessmenType? newType = null)
		{
			// todo: check if cell is acceptable for the chessman

			if (chessman.Type == ChessmenType.Pawn &&  ((Pawn)chessman).IsLastRow(newPosition.Row))
				chessman = ChessmanFactory.TryToConvertChessman(chessman, newType);

			BoardCells[oldPosition.Row, oldPosition.Column].Chessman = null;
			BoardCells[newPosition.Row, newPosition.Column].Chessman = chessman;
		}
	}
}
