using System;
using System.Collections.Generic;
using System.IO;
using ChessBoard.Chessmens;

namespace ChessBoard.Tests.TestDataClasses
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
			var boardCells = new[]
			{
				new BoardCell(0, 1, new Rook(Color.Black)),
				new BoardCell(0, 4, new King(Color.Black)),
				new BoardCell(0, 5, new Bishop(Color.Black)),
				new BoardCell(0, 7, new Rook(Color.Black)),
				new BoardCell(1, 0, new Pawn(Color.Black)),
				new BoardCell(1, 3, new Queen(Color.Black)),
				new BoardCell(1, 4, new Pawn(Color.Black)),
				new BoardCell(1, 5, new Pawn(Color.Black)),
				new BoardCell(1, 6, new Pawn(Color.Black)),
				new BoardCell(2, 3, new Pawn(Color.White)),
				new BoardCell(3, 0, new Rook(Color.White)),
				new BoardCell(4, 1, new Pawn(Color.White)),
				new BoardCell(4, 3, new Pawn(Color.White)),
				new BoardCell(4, 5, new Knight(Color.Black)),
				new BoardCell(4, 7, new Pawn(Color.Black)),
				new BoardCell(5, 6, new Knight(Color.White)),
				new BoardCell(6, 1, new Pawn(Color.White)),
				new BoardCell(6, 2, new Pawn(Color.White)),
				new BoardCell(6, 5, new Pawn(Color.White)),
				new BoardCell(6, 6, new Pawn(Color.White)),
				new BoardCell(6, 7, new Pawn(Color.White)),
				new BoardCell(7, 1, new Bishop(Color.White)),
				new BoardCell(7, 5, new Queen(Color.White)),
				new BoardCell(7, 6, new King(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.WhiteTurn);
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
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),
				new BoardCell(7, 4, new King(Color.White)),
				new BoardCell(1, 7, new Pawn(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.WhiteTurn);
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
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),
				new BoardCell(7, 4, new King(Color.White)),
				new BoardCell(6, 0, new Pawn(Color.Black))
			};

			return SetupChessBoard(boardCells, GameStatus.BlackTurn);
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
			var boardCells = new[]
			{
				new BoardCell(0, 0, new King(Color.White)),
				new BoardCell(2, 2, new Queen(Color.Black)),
				new BoardCell(7, 7, new King(Color.Black))
			};

			return SetupChessBoard(boardCells, GameStatus.ShahForWhite);
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
			var boardCells = new[]
			{
				new BoardCell(0, 0, new King(Color.Black)),
				new BoardCell(2, 2, new Queen(Color.White)),
				new BoardCell(7, 7, new King(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.ShahForBlack);
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
			var boardCells = new[]
			{
				new BoardCell(0, 0, new King(Color.White)),
				new BoardCell(1, 1, new Queen(Color.Black)),
				new BoardCell(2, 1, new King(Color.Black))
			};

			return SetupChessBoard(boardCells, GameStatus.WhiteWin);
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
			var boardCells = new[]
			{
				new BoardCell(0, 0, new King(Color.Black)),
				new BoardCell(1, 1, new Queen(Color.White)),
				new BoardCell(2, 1, new King(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.BlackWin);
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
			var boardCells = new[]
			{
				new BoardCell(0, 0, new King(Color.Black)),
				new BoardCell(1, 2, new Queen(Color.White)),
				new BoardCell(2, 1, new King(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.StalemateForBlack);
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
			var boardCells = new[]
			{
				new BoardCell(0, 0, new King(Color.White)),

				new BoardCell(1, 2, new Queen(Color.Black)),
				new BoardCell(2, 1, new King(Color.Black))
			};

			return SetupChessBoard(boardCells, GameStatus.StalemateForWhite);
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
		//		6	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		7	  |   |   |   |   |WKI|   |   |WR |
		//			  _________________________________
		//
		//
		//			   0   1   2   3   4   5   6   7   


		public static ChessBoard GetChessBoardScenario_10_BeforeWhiteRightCastling()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),

				new BoardCell(7, 4, new King(Color.White)),
				new BoardCell(7, 7, new Rook(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.WhiteTurn);
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

		protected static ChessBoard SetupChessBoard(BoardCell[] boardCellsToSet, GameStatus status)
		{
			var boardCells = new BoardCell[8, 8];
			SetEmptyCells(boardCells, 0, 7);

			foreach (var boardCell in boardCellsToSet)
				boardCells[boardCell.Row, boardCell.Column] = boardCell;

			ChessBoard chessBoard = new ChessBoard(boardCells)
			{
				Status = status
			};

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
			Cell[] rookCells = { new Cell(0, 3), new Cell(7, 3) };

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
