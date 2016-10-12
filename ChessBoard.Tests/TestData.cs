using System;
using System.IO;
using ChessBoard.Chessmens;

namespace ChessBoard.Tests
{
	static class TestData
	{
		public static ChessBoard CreateNewChessBoard()
		{
			ChessBoard startBoard = new ChessBoard();
			startBoard.SetStartPosition();

			return startBoard;
		}

		//			  _________________________________
		//		0	  |   |BR |   |   |BKI|BB |   |BR |
		//		 	  _________________________________
		//		1	  |BP |   |   |BQ |BP |BP |BP |   |
		//			  _________________________________
		//		2	  |   |   |   |WP |   |	  |   |   |
		//			  _________________________________
		//		3	  |WR |	  |   |   |   |	  |   |   |
		//			  _________________________________
		//		4	  |   |WP |   |WP |BKN|   |   |BP |
		//			  _________________________________
		//		5	  |   |   |   |   |   |WKN|   |	  |
		//			  _________________________________
		//		6	  |   |WP |WP |   |   |WP |WP |WP |
		//			  _________________________________
		//		7	  |   |   |WB |   |   |WQ |WKI|   |
		//			  _________________________________
		//			
		//			
		//			   0   1   2   3   4   5   6   7  

		public static ChessBoard GetChessBoardScenarioOneStatusNormal()
		{
			BoardCell[,] boardCells = new BoardCell[8, 8];

			SetEmptyCells(boardCells, 0, 7);

			boardCells[0, 1].Chessman = new Rook(Color.Black);
			boardCells[0, 4].Chessman = new King(Color.Black);
			boardCells[0, 5].Chessman = new Bishop(Color.Black);
			boardCells[0, 7].Chessman = new Rook(Color.Black);

			boardCells[1, 0].Chessman = new Pawn(Color.Black);
			boardCells[1, 3].Chessman = new Queen(Color.Black);
			boardCells[1, 4].Chessman = new Pawn(Color.Black);
			boardCells[1, 5].Chessman = new Pawn(Color.Black);
			boardCells[1, 6].Chessman = new Pawn(Color.Black);

			boardCells[2, 3].Chessman = new Pawn(Color.White);

			boardCells[3, 0].Chessman = new Rook(Color.White);

			boardCells[4, 1].Chessman = new Pawn(Color.White);
			boardCells[4, 3].Chessman = new Pawn(Color.White);
			boardCells[4, 5].Chessman = new Knight(Color.Black);
			boardCells[4, 7].Chessman = new Pawn(Color.Black);

			boardCells[5, 6].Chessman = new Knight(Color.White);

			boardCells[6, 1].Chessman = new Pawn(Color.White);
			boardCells[6, 2].Chessman = new Pawn(Color.White);
			boardCells[6, 5].Chessman = new Pawn(Color.White);
			boardCells[6, 6].Chessman = new Pawn(Color.White);
			boardCells[6, 7].Chessman = new Pawn(Color.White);

			boardCells[7, 1].Chessman = new Bishop(Color.White);
			boardCells[7, 5].Chessman = new Queen(Color.White);
			boardCells[7, 6].Chessman = new King(Color.White);

			ChessBoard chessBoard = new ChessBoard(boardCells);
			chessBoard.Status = GameStatus.WhiteTurn;

			return chessBoard;
		}

		//			  _________________________________
		//		0	  |BR |BKN|BB |BQ |BKI|BB |BKN|BR |
		//		 	  _________________________________
		//		1	  |BP |BP |BP |BP |BP |BP |BP |BP |
		//			  _________________________________
		//		2	  |   |   |   |   |   |	  |   |   |
		//			  _________________________________
		//		3	  |   |   |   |   |   |	  |   |   |
		//			  _________________________________
		//		4	  |   |   |   |   |   |	  |   |   |
		//			  _________________________________
		//		5	  |   |   |   |   |   |	  |   |   |
		//			  _________________________________
		//		6	  |WP |WP |WP |WP |WP |WP |WP |WP |
		//			  _________________________________
		//		7	  |WR |WKN|WB |WQ |WKI|WB |WKN|WR |
		//			  _________________________________
		//			
		//			
		//			   0   1   2   3   4   5   6   7  

		public static ChessBoard GetStartPositionChessBoard()
		{
			var boardCells = new BoardCell[8, 8];

			SetStartPositionsForMainChessmens(boardCells, Color.Black);
			SetStartPositionsForMainChessmens(boardCells, Color.White);

			SetStartPositionsForPawns(boardCells, Color.Black);
			SetStartPositionsForPawns(boardCells, Color.White);

			SetEmptyCells(boardCells, 2, 5);

			ChessBoard chessBoard = new ChessBoard(boardCells);
			chessBoard.Status = GameStatus.WhiteTurn;

			return chessBoard;
		}

		static void SetStartPositionsForMainChessmens(BoardCell[,] boardCells, Color color)
		{
			var row = color == Color.Black ? 0 : 7;

			boardCells[row, 0] = new BoardCell(row, 0, new Rook(color));
			boardCells[row, 1] = new BoardCell(row, 1, new Knight(color));
			boardCells[row, 2] = new BoardCell(row, 2, new Bishop(color));
			boardCells[row, 3] = new BoardCell(row, 3, new Queen(color));
			boardCells[row, 4] = new BoardCell(row, 4, new King(color));
			boardCells[row, 5] = new BoardCell(row, 5, new Bishop(color));
			boardCells[row, 6] = new BoardCell(row, 6, new Knight(color));
			boardCells[row, 7] = new BoardCell(row, 7, new Rook(color));
		}

		static void SetStartPositionsForPawns(BoardCell[,] boardCells, Color color)
		{
			var row = color == Color.Black ? 1 : 6;

			for (int column = 0; column <= 7; column++)
				boardCells[row, column] = new BoardCell(row, column, new Pawn(color));
		}

		static void SetEmptyCells(BoardCell[,] boardCells, int startRowIndex, int endRowIndex)
		{
			for (int row = startRowIndex; row <= endRowIndex; row++)
				for (int column = 0; column <= 7; column++)
					boardCells[row, column] = new BoardCell(row, column);
		}

		public static string GetSerializedChessBoardWithStartPosition()
		{
			string json = string.Empty;

			using (StreamReader r = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"/StartPositions.json"))
			{
				json = r.ReadToEnd();
			}

			return GetJsonWithoutSymbolsAddedForReadability(json);
		}

		static string GetJsonWithoutSymbolsAddedForReadability(string json)
		{
			return json.Replace("\r\n", "").Replace("\\", "");
		}
	}
}
