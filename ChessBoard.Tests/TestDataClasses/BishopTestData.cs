using System.Collections.Generic;
using ChessBoard.Chessmens;

namespace ChessBoard.Tests.TestDataClasses
{
	class BishopTestData : TestData
	{
		public static object[] GetAcceptableCellsTestCases()
		{
			var testsName = "Bishop tests - ";

			return new object[]
			{
				new object[] { GetScenario_1(), new Cell(7, 0), GetCellsForScenario_1(), testsName + nameof(GetScenario_1) },
				new object[] { GetScenario_2(), new Cell(4, 3), GetCellsForScenario_2(), testsName + nameof(GetScenario_2) },
				new object[] { GetScenario_3(), new Cell(4, 2), GetCellsForScenario_3(), testsName + nameof(GetScenario_3) },

				// todo: uncomment when shah will be done
				//new object[] { GetScenario_4(), new Cell(2, 3), GetCellsForScenario_4(), testsName + nameof(GetScenario_4) },
				//new object[] { GetScenario_5(), new Cell(3, 2), GetCellsForScenario_5(), testsName + nameof(GetScenario_5) }
			};
		}

		//			  _________________________________
		//		0	  |   |   |   |   |BKI|   |   | + |
		//		 	  _________________________________
		//		1	  |   |   |   |   |   |   | + |   |
		//			  _________________________________
		//		2	  |   |   |   |   |   | + |   |   |
		//			  _________________________________
		//		3	  |   |   |   |   | + |   |   |   |
		//			  _________________________________
		//		4	  |   |   |   | + |   |   |   |   |
		//			  _________________________________
		//		5	  |   |   | + |   |   |   |   |   |
		//			  _________________________________
		//		6	  |   | + |   |   |   |   |   |   |
		//			  _________________________________
		//		7	  |WB |   |   |   |WKI|   |   |   |
		//			  _________________________________
		//			
		//			
		//			   0   1   2   3   4   5   6   7   

		static ChessBoard GetScenario_1()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),

				new BoardCell(7, 4, new King(Color.White)),
				new BoardCell(7, 0, new Bishop(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.WhiteTurn);
		}

		static List<Cell> GetCellsForScenario_1()
		{
			return new List<Cell>
			{
				new Cell(6, 1), new Cell(5, 2), new Cell(4, 3), new Cell(3, 4), new Cell(2, 5), new Cell(1, 6),
				new Cell(0, 7)
			};
		}

		//			  _________________________________
		//		0	  |   |   |   |   |BKI|   |   | + |
		//		 	  _________________________________
		//		1	  | + |   |   |   |   |   | + |   |
		//			  _________________________________
		//		2	  |   | + |   |   |   | + |   |   |
		//			  _________________________________
		//		3	  |   |   | + |   | + |   |   |   |
		//			  _________________________________
		//		4	  |   |   |   |WB |   |   |   |   |
		//			  _________________________________
		//		5	  |   |   | + |   | + |   |   |   |
		//			  _________________________________
		//		6	  |   | + |   |   |   | + |   |   |
		//			  _________________________________
		//		7	  | + |   |   |   |WKI|   | + |   |
		//			  _________________________________
		//			
		//			
		//			   0   1   2   3   4   5   6   7   

		static ChessBoard GetScenario_2()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),

				new BoardCell(7, 4, new King(Color.White)),
				new BoardCell(4, 3, new Bishop(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.WhiteTurn);
		}

		static List<Cell> GetCellsForScenario_2()
		{
			return new List<Cell>
			{
				new Cell(3, 2), new Cell(2, 1), new Cell(1, 0),
				new Cell(3, 4), new Cell(2, 5), new Cell(1, 6), new Cell(0, 7),
				new Cell(5, 2), new Cell(6, 1), new Cell(7, 0),
				new Cell(5, 4), new Cell(6, 5), new Cell(7, 6)
			};
		}

		//			  _________________________________
		//		0	  |   |   |   |   |BKI|   | + |   |
		//		 	  _________________________________
		//		1	  |   |   |   |   |   | + |   |   |
		//			  _________________________________
		//		2	  |BQ+|   |   |   | + |   |   |   |
		//			  _________________________________
		//		3	  |   | + |   | + |   |   |   |   |
		//			  _________________________________
		//		4	  |   |   |WB |   |   |   |   |   |
		//			  _________________________________
		//		5	  |   | + |   | + |   |   |   |   |
		//			  _________________________________
		//		6	  | + |   |   |   |WQ |   |   |   |
		//			  _________________________________
		//		7	  |   |   |   |   |WKI|   |   |   |
		//			  _________________________________
		//			
		//			
		//			   0   1   2   3   4   5   6   7   

		static ChessBoard GetScenario_3()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),
				new BoardCell(2, 0, new Queen(Color.Black)),

				new BoardCell(7, 4, new King(Color.White)),
				new BoardCell(6, 4, new Queen(Color.White)),
				new BoardCell(4, 2, new Bishop(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.WhiteTurn);
		}

		static List<Cell> GetCellsForScenario_3()
		{
			return new List<Cell>
			{
				new Cell(2, 0), new Cell(3, 1),
				new Cell(3, 3), new Cell(2, 4), new Cell(1, 5), new Cell(0, 6),
				new Cell(5, 3),
				new Cell(5, 1), new Cell(6, 0)
			};
		}

		//			  _________________________________
		//		0	  |   |   |   |   |BKI|   |   |   |
		//		 	  _________________________________
		//		1	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		2	  |   |   |   |WB |   |   |   |   |
		//			  _________________________________
		//		3	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		4	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		5	  |   |   |   |   |   |   |BQ+|   |
		//			  _________________________________
		//		6	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		7	  |   |   |   |   |WKI|   |   |   |
		//			  _________________________________
		//			
		//			
		//			   0   1   2   3   4   5   6   7   

		static ChessBoard GetScenario_4()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),
				new BoardCell(5, 6, new Queen(Color.Black)),

				new BoardCell(7, 4, new King(Color.White)),
				new BoardCell(2, 3, new Bishop(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.ShahForWhite);
		}

		static List<Cell> GetCellsForScenario_4()
		{
			return new List<Cell>
			{
				new Cell(5, 6)
			};
		}

		//			  _________________________________
		//		0	  |   |   |   |   |BKI|   |   |   |
		//		 	  _________________________________
		//		1	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		2	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		3	  |   |   |WB |   |   |   |   |   |
		//			  _________________________________
		//		4	  |   |   |   |   |BQ |   |   |   |
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

		static ChessBoard GetScenario_5()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),
				new BoardCell(4, 4, new Queen(Color.Black)),

				new BoardCell(7, 4, new King(Color.White)),
				new BoardCell(3, 2, new Bishop(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.ShahForWhite);
		}

		static List<Cell> GetCellsForScenario_5()
		{
			return new List<Cell>();
		}
	}
}
