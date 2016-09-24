using System;
using System.IO;
using ChessBoard.Chessmens;

namespace ChessBoard.Tests
{
	static class TestData
	{
		// 0   BR  BKN BB  BQ  BKI BB  BKN BR
		// 1   BP  BP  BP  BP  BP  BP  BP  BP
		// 2  
		// 3  
		// 4  
		// 5  
		// 6   WP  WP  WP  WP  WP  WP  WP  WP
		// 7   WR  WKN WB  WQ  WKI WB  WKN WR
		//
		//     0   1   2   3   4   5   6   7
		public static BoardCell[,] GetStartPositionChessBoard()
		{
			var chessboard = new BoardCell[8, 8];

			SetStartPositionsForMainChessmens(chessboard, Color.Black);
			SetStartPositionsForMainChessmens(chessboard, Color.White);

			SetStartPositionsForPawns(chessboard, Color.Black);
			SetStartPositionsForPawns(chessboard, Color.White);

			return chessboard;
		}

		static void SetStartPositionsForMainChessmens(BoardCell[,] chessboard, Color color)
		{
			var row = color == Color.Black ? 0 : 7;

			chessboard[row, 0] = new BoardCell(row, 0, new Rook(color));
			chessboard[row, 1] = new BoardCell(row, 1, new Knight(color));
			chessboard[row, 2] = new BoardCell(row, 2, new Bishop(color));
			chessboard[row, 3] = new BoardCell(row, 3, new Queen(color));
			chessboard[row, 4] = new BoardCell(row, 4, new King(color));
			chessboard[row, 5] = new BoardCell(row, 5, new Bishop(color));
			chessboard[row, 6] = new BoardCell(row, 6, new Knight(color));
			chessboard[row, 7] = new BoardCell(row, 7, new Rook(color));
		}

		static void SetStartPositionsForPawns(BoardCell[,] chessboard, Color color)
		{
			var row = color == Color.Black ? 1 : 6;

			for (int column = 0; column <= 7; column++)
				chessboard[row, column] = new BoardCell(row, column, new Pawn(color));
		}

		public static string GetSerializedChessBoardWithStartPosition()
		{
			string json = string.Empty;

			using (StreamReader r = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"/StartPositions.json"))
			{
				json = r.ReadToEnd()
					.Replace("\r\n", "")
					.Replace("\\", "");
			}

			return GetJsonWithoutSymbolsAddedForReadability(json);
		}

		static string GetJsonWithoutSymbolsAddedForReadability(string json)
		{
			return json.Replace("\r\n", "").Replace("\\", "");
		}
	}
}
