using Newtonsoft.Json;

namespace ChessBoard
{
    public class ChessBoard
    {
		public BoardCell[,] Chessboard { get; }
	    public GameStatus Status = GameStatus.Normal;

		public ChessBoard()
		{
			Chessboard = ChessBoardBuilder.GetStartPositionChessBoard();
		}

		public string GetSerializedChessBoard()
	    {
		    return JsonConvert.SerializeObject(this);
		}
	}
}
