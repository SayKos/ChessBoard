using System;
using System.Collections.Generic;
using System.IO;
using ChessBoard.Chessmens;

namespace ChessBoard.Tests
{
	class TestData
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

		public static ChessBoard GetChessBoardScenario_1_WhiteTurn()
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
		//		0	  |   |   |   |   |BKI|   |   |   |
		//		 	  _________________________________
		//		1	  |   |   |   |   |   |   |   |WP |
		//			  _________________________________
		//		2	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		3	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		4	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		5	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		6	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		7	  |   |   |   |   |WKI|   |   |   |
		//			  _________________________________
		//
		//
		//			   0   1   2   3   4   5   6   7   

		public static ChessBoard GetChessBoardScenario_2_WhiteTurn()
		{
			BoardCell[,] boardCells = new BoardCell[8, 8];

			SetEmptyCells(boardCells, 0, 7);

			boardCells[0, 4].Chessman = new King(Color.Black);
			boardCells[7, 4].Chessman = new King(Color.White);
			boardCells[1, 7].Chessman = new Pawn(Color.White);

			ChessBoard chessBoard = new ChessBoard(boardCells);
			chessBoard.Status = GameStatus.WhiteTurn;

			return chessBoard;
		}

		//			  _________________________________
		//		0	  |   |   |   |   |BKI|   |   |   |
		//		 	  _________________________________
		//		1	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		2	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		3	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		4	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		5	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		6	  |BP |   |   |   |   |   |   |   |
		//			  _________________________________
		//		7	  |   |   |   |   |WKI|   |   |   |
		//			  _________________________________
		//
		//
		//			   0   1   2   3   4   5   6   7   

		public static ChessBoard GetChessBoardScenario_3_BlackTurn()
		{
			BoardCell[,] boardCells = new BoardCell[8, 8];

			SetEmptyCells(boardCells, 0, 7);

			boardCells[0, 4].Chessman = new King(Color.Black);
			boardCells[7, 4].Chessman = new King(Color.White);
			boardCells[6, 0].Chessman = new Pawn(Color.Black);

			ChessBoard chessBoard = new ChessBoard(boardCells);
			chessBoard.Status = GameStatus.BlackTurn;

			return chessBoard;
		}

		//			  _________________________________
		//		0	  |WKI|   |   |   |   |   |   |   |
		//		 	  _________________________________
		//		1	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		2	  |   |   |BQ |   |   |   |   |   |
		//			  _________________________________
		//		3	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		4	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		5	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		6	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		7	  |   |   |   |   |   |   |   |BKI|
		//			  _________________________________
		//
		//
		//			   0   1   2   3   4   5   6   7   

		public static ChessBoard GetChessBoardScenario_4_ShahForWhite()
		{
			BoardCell[,] boardCells = new BoardCell[8, 8];

			SetEmptyCells(boardCells, 0, 7);

			boardCells[0, 0].Chessman = new King(Color.White);
			boardCells[2, 2].Chessman = new Queen(Color.Black);
			boardCells[7, 7].Chessman = new King(Color.Black);

			ChessBoard chessBoard = new ChessBoard(boardCells);
			chessBoard.Status = GameStatus.ShahForWhite;

			return chessBoard;
		}

		//			  _________________________________
		//		0	  |BKI|   |   |   |   |   |   |   |
		//		 	  _________________________________
		//		1	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		2	  |   |   |WQ |   |   |   |   |   |
		//			  _________________________________
		//		3	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		4	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		5	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		6	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		7	  |   |   |   |   |   |   |   |WKI|
		//			  _________________________________
		//
		//
		//			   0   1   2   3   4   5   6   7   

		public static ChessBoard GetChessBoardScenario_5_ShahForBlack()
		{
			BoardCell[,] boardCells = new BoardCell[8, 8];

			SetEmptyCells(boardCells, 0, 7);

			boardCells[0, 0].Chessman = new King(Color.Black);
			boardCells[2, 2].Chessman = new Queen(Color.White);
			boardCells[7, 7].Chessman = new King(Color.White);

			ChessBoard chessBoard = new ChessBoard(boardCells);
			chessBoard.Status = GameStatus.ShahForBlack;

			return chessBoard;
		}

		//			  _________________________________
		//		0	  |WKI|   |   |   |   |   |   |   |
		//		 	  _________________________________
		//		1	  |   |BQ |   |   |   |   |   |   |
		//			  _________________________________
		//		2	  |   |BKI|   |   |   |   |   |   |
		//			  _________________________________
		//		3	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		4	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		5	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		6	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		7	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//
		//
		//			   0   1   2   3   4   5   6   7   

		public static ChessBoard GetChessBoardScenario_6_CheckmateForWhite()
		{
			BoardCell[,] boardCells = new BoardCell[8, 8];

			SetEmptyCells(boardCells, 0, 7);

			boardCells[0, 0].Chessman = new King(Color.White);
			boardCells[1, 1].Chessman = new Queen(Color.Black);
			boardCells[2, 1].Chessman = new King(Color.Black);

			ChessBoard chessBoard = new ChessBoard(boardCells);
			chessBoard.Status = GameStatus.CheckmateForWhite;

			return chessBoard;
		}

		//			  _________________________________
		//		0	  |BKI|   |   |   |   |   |   |   |
		//		 	  _________________________________
		//		1	  |   |WQ |   |   |   |   |   |   |
		//			  _________________________________
		//		2	  |   |WKI|   |   |   |   |   |   |
		//			  _________________________________
		//		3	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		4	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		5	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		6	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		7	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//
		//
		//			   0   1   2   3   4   5   6   7   

		public static ChessBoard GetChessBoardScenario_7_CheckmateForBlack()
		{
			BoardCell[,] boardCells = new BoardCell[8, 8];

			SetEmptyCells(boardCells, 0, 7);

			boardCells[0, 0].Chessman = new King(Color.Black);
			boardCells[1, 1].Chessman = new Queen(Color.White);
			boardCells[2, 1].Chessman = new King(Color.White);

			ChessBoard chessBoard = new ChessBoard(boardCells);
			chessBoard.Status = GameStatus.CheckmateForBlack;

			return chessBoard;
		}

		//			  _________________________________
		//		0	  |BKI|   |   |   |   |   |   |   |
		//		 	  _________________________________
		//		1	  |   |   |WQ |   |   |   |   |   |
		//			  _________________________________
		//		2	  |   |WKI|   |   |   |   |   |   |
		//			  _________________________________
		//		3	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		4	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		5	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		6	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		7	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//
		//
		//			   0   1   2   3   4   5   6   7   

		public static ChessBoard GetChessBoardScenario_8_StalemateForBlack()
		{
			BoardCell[,] boardCells = new BoardCell[8, 8];

			SetEmptyCells(boardCells, 0, 7);

			boardCells[0, 0].Chessman = new King(Color.Black);
			boardCells[1, 2].Chessman = new Queen(Color.White);
			boardCells[2, 1].Chessman = new King(Color.White);

			ChessBoard chessBoard = new ChessBoard(boardCells);
			chessBoard.Status = GameStatus.StalemateForBlack;

			return chessBoard;
		}

		//			  _________________________________
		//		0	  |WKI|   |   |   |   |   |   |   |
		//		 	  _________________________________
		//		1	  |   |   |BQ |   |   |   |   |   |
		//			  _________________________________
		//		2	  |   |BKI|   |   |   |   |   |   |
		//			  _________________________________
		//		3	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		4	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		5	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		6	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		7	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//
		//
		//			   0   1   2   3   4   5   6   7   

		public static ChessBoard GetChessBoardScenario_9_StalemateForWhite()
		{
			BoardCell[,] boardCells = new BoardCell[8, 8];

			SetEmptyCells(boardCells, 0, 7);

			boardCells[0, 0].Chessman = new King(Color.White);
			boardCells[1, 2].Chessman = new Queen(Color.Black);
			boardCells[2, 1].Chessman = new King(Color.Black);

			ChessBoard chessBoard = new ChessBoard(boardCells);
			chessBoard.Status = GameStatus.StalemateForBlack;

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

		public static void SetEmptyCells(BoardCell[,] boardCells, int startRowIndex, int endRowIndex)
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

		public static IEnumerable<object> GetPawnStartPositionsAndExpectedTypes()
		{
			int[] pawnRows = new[] { 1, 6 };

			for (int rowIndex = 0; rowIndex < pawnRows.Length; rowIndex++)
				for (int column = 0; column <= 7; column++)
					yield return new object[] { pawnRows[rowIndex], column, typeof(Pawn), ChessmenType.Pawn };
		}

		public static IEnumerable<object> GetRookStartPositionsAndExpectedTypes()
		{
			Cell[] rookCells = { new Cell(0, 0), new Cell(0, 7), new Cell(7, 0), new Cell(7, 7) };

			foreach (var rookCell in rookCells)
				yield return new object[] { rookCell.Row, rookCell.Column, typeof(Rook), ChessmenType.Rook };
		}

		public static IEnumerable<object> GetKnightStartPositionsAndExpectedTypes()
		{
			Cell[] rookCells = { new Cell(0, 1), new Cell(0, 6), new Cell(7, 1), new Cell(7, 6) };

			foreach (var rookCell in rookCells)
				yield return new object[] { rookCell.Row, rookCell.Column, typeof(Knight), ChessmenType.Knight };
		}

		public static IEnumerable<object> GetBishopStartPositionsAndExpectedTypes()
		{
			Cell[] rookCells = { new Cell(0, 2), new Cell(0, 5), new Cell(7, 2), new Cell(7, 5) };

			foreach (var rookCell in rookCells)
				yield return new object[] { rookCell.Row, rookCell.Column, typeof(Bishop), ChessmenType.Bishop };
		}

		public static IEnumerable<object> GetQueenStartPositionsAndExpectedTypes()
		{
			Cell[] rookCells = { new Cell(0, 3), new Cell(7, 3)};

			foreach (var rookCell in rookCells)
				yield return new object[] { rookCell.Row, rookCell.Column, typeof(Queen), ChessmenType.Queen };
		}

		public static IEnumerable<object> GetKingStartPositionsAndExpectedTypes()
		{
			Cell[] rookCells = { new Cell(0, 4), new Cell(7, 4) };

			foreach (var rookCell in rookCells)
				yield return new object[] { rookCell.Row, rookCell.Column, typeof(King), ChessmenType.King };
		}
	}
}
