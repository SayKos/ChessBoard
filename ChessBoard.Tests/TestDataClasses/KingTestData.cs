using System.Collections.Generic;
using ChessBoard.Chessmens;

namespace ChessBoard.Tests.TestDataClasses
{
	class KingTestData : TestData
	{
		public static object[] GetAcceptableCellsTestCases()
		{
			var testsName = "Kning tests - ";

			return new object[]
			{
				new object[] { GetScenario_1(), new Cell(4, 3), GetCellsForScenario_1(), testsName + nameof(GetScenario_1) },
				new object[] { GetScenario_2(), new Cell(4, 3), GetCellsForScenario_2(), testsName + nameof(GetScenario_2) },
				new object[] { GetScenario_3(), new Cell(7, 0), GetCellsForScenario_3(), testsName + nameof(GetScenario_3) },
				new object[] { GetScenario_4(), new Cell(7, 4), GetCellsForScenario_4(), testsName + nameof(GetScenario_4) },
				new object[] { GetScenario_5(), new Cell(7, 4), GetCellsForScenario_5(), testsName + nameof(GetScenario_5) },
				new object[] { GetScenario_6(), new Cell(7, 4), GetCellsForScenario_6(), testsName + nameof(GetScenario_6) },
				new object[] { GetScenario_7(), new Cell(7, 4), GetCellsForScenario_7(), testsName + nameof(GetScenario_7) },
				new object[] { GetScenario_8(), new Cell(7, 4), GetCellsForScenario_8(), testsName + nameof(GetScenario_8) },
				new object[] { GetScenario_9(), new Cell(7, 4), GetCellsForScenario_9(), testsName + nameof(GetScenario_9) },
				new object[] { GetScenario_10(), new Cell(7, 4), GetCellsForScenario_10(), testsName + nameof(GetScenario_10) }
			};
		}

		//			  _________________________________
		//		0	  |   |   |   |   |BKI|   |   |   |
		//		 	  _________________________________
		//		1	  |   |   |   |   |BR |   |   |   |
		//			  _________________________________
		//		2	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		3	  |   |   | + | + |   |   |   |   |
		//			  _________________________________
		//		4	  |   |   | + |WKI|   |   |   |   |
		//			  _________________________________
		//		5	  |   |   | + | + |   |   |   |   |
		//			  _________________________________
		//		6	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		7	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//			
		//			
		//			   0   1   2   3   4   5   6   7   

		static ChessBoard GetScenario_1()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),
				new BoardCell(1, 4, new Rook(Color.Black)),

				new BoardCell(4, 3, new King(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.WhiteTurn);
		}

		static List<Cell> GetCellsForScenario_1()
		{
			return new List<Cell>
			{
				new Cell(5, 3), new Cell(5, 2), new Cell(4, 2), new Cell(3, 2), new Cell(3, 3)
			};
		}

		//			  _________________________________
		//		0	  |   |   |   |   |BKI|   |   |   |
		//		 	  _________________________________
		//		1	  |   |   |   |BR |   |   |   |   |
		//			  _________________________________
		//		2	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		3	  |   |   | + |   | + |   |   |   |
		//			  _________________________________
		//		4	  |   |   | + |WKI| + |   |   |   |
		//			  _________________________________
		//		5	  |   |   | + |   | + |   |   |   |
		//			  _________________________________
		//		6	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		7	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//			
		//			
		//			   0   1   2   3   4   5   6   7   

		static ChessBoard GetScenario_2()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),
				new BoardCell(1, 3, new Rook(Color.Black)),

				new BoardCell(4, 3, new King(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.ShahForWhite);
		}

		static List<Cell> GetCellsForScenario_2()
		{
			return new List<Cell>
			{
				new Cell(5, 2), new Cell(4, 2), new Cell(3, 2),
				new Cell(5, 4), new Cell(4, 4), new Cell(3, 4)
			};
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
		//		6	  |BKN| + |   |   |   |   |   |   |
		//			  _________________________________
		//		7	  |WKI|WQ |   |   |   |   |   |   |
		//			  _________________________________
		//			
		//			
		//			   0   1   2   3   4   5   6   7   

		static ChessBoard GetScenario_3()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),
				new BoardCell(6, 0, new Knight(Color.Black)),

				new BoardCell(7, 0, new King(Color.White)),
				new BoardCell(7, 1, new Queen(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.WhiteTurn);
		}

		static List<Cell> GetCellsForScenario_3()
		{
			return new List<Cell>
			{
				new Cell(6, 0), new Cell(6, 1)
			};
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
		//		6	  |   |   |   | + | + | + |   |   |
		//			  _________________________________
		//		7	  |WR+|   |   | + |WKI| + |   |WR+|
		//			  _________________________________
		//			
		//			
		//			   0   1   2   3   4   5   6   7   

		static ChessBoard GetScenario_4()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),

				new BoardCell(7, 4, new King(Color.White)),
				new BoardCell(7, 0, new Rook(Color.White)),
				new BoardCell(7, 7, new Rook(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.WhiteTurn);
		}

		static List<Cell> GetCellsForScenario_4()
		{
			return new List<Cell>
			{
				new Cell(7, 0), new Cell(7, 7),
				new Cell(7, 3), new Cell(6, 3), new Cell(6, 4), new Cell(6, 5), new Cell(7, 5)
			};
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
		//		6	  |   |   |   | + | + | + |   |   |
		//			  _________________________________
		//		7	  |WR |   |   | + |WKI| + |   |WR |
		//			  _________________________________
		//			
		//			
		//			   0   1   2   3   4   5   6   7   

		static ChessBoard GetScenario_5()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),

				new BoardCell(7, 4, new King(Color.White)),
				new BoardCell(7, 0, new Rook(Color.White) { Moved = true }),
				new BoardCell(7, 7, new Rook(Color.White) { Moved = true })
			};

			return SetupChessBoard(boardCells, GameStatus.WhiteTurn);
		}

		static List<Cell> GetCellsForScenario_5()
		{
			return new List<Cell>
			{
				new Cell(7, 3), new Cell(6, 3), new Cell(6, 4), new Cell(6, 5), new Cell(7, 5)
			};
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
		//		6	  |   |   |   | + | + | + |   |   |
		//			  _________________________________
		//		7	  |WR |   |   | + |WKI| + |   |WR |
		//			  _________________________________
		//			
		//			
		//			   0   1   2   3   4   5   6   7   

		static ChessBoard GetScenario_6()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),

				new BoardCell(7, 4, new King(Color.White) { Moved = true }),
				new BoardCell(7, 0, new Rook(Color.White)),
				new BoardCell(7, 7, new Rook(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.WhiteTurn);
		}

		static List<Cell> GetCellsForScenario_6()
		{
			return new List<Cell>
			{
				new Cell(7, 3), new Cell(6, 3), new Cell(6, 4), new Cell(6, 5), new Cell(7, 5)
			};
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
		//		5	  |   |   |   |BKN|   |   |   |   |
		//			  _________________________________
		//		6	  |   |   |   | + | + |   |   |   |
		//			  _________________________________
		//		7	  |WR |   |   | + |WKI| + |   |WR |
		//			  _________________________________
		//			
		//			
		//			   0   1   2   3   4   5   6   7   

		static ChessBoard GetScenario_7()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),
				new BoardCell(5, 3, new Knight(Color.Black)),

				new BoardCell(7, 4, new King(Color.White)),
				new BoardCell(7, 0, new Rook(Color.White)),
				new BoardCell(7, 7, new Rook(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.ShahForWhite);
		}

		static List<Cell> GetCellsForScenario_7()
		{
			return new List<Cell>
			{
				new Cell(7, 3), new Cell(6, 3), new Cell(6, 4), new Cell(7, 5)
			};
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
		//		5	  |   |   |BR |   |   |BR |   |   |
		//			  _________________________________
		//		6	  |   |   |   | + | + |   |   |   |
		//			  _________________________________
		//		7	  |WR |   |   | + |WKI|   |   |WR |
		//			  _________________________________
		//			
		//			
		//			   0   1   2   3   4   5   6   7   

		static ChessBoard GetScenario_8()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),
				new BoardCell(5, 2, new Rook(Color.Black)),
				new BoardCell(5, 5, new Rook(Color.Black)),

				new BoardCell(7, 4, new King(Color.White)),
				new BoardCell(7, 0, new Rook(Color.White)),
				new BoardCell(7, 7, new Rook(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.WhiteTurn);
		}

		static List<Cell> GetCellsForScenario_8()
		{
			return new List<Cell>
			{
				new Cell(7, 3), new Cell(6, 3), new Cell(6, 4)
			};
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
		//		6	  |   |   |   |   | + | + |   |   |
		//			  _________________________________
		//		7	  |WR |   |BB | + |WKI| + |WB |WR |
		//			  _________________________________
		//			
		//			
		//			   0   1   2   3   4   5   6   7   

		static ChessBoard GetScenario_9()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),
				new BoardCell(7, 2, new Bishop(Color.Black)),

				new BoardCell(7, 4, new King(Color.White)),
				new BoardCell(7, 0, new Rook(Color.White)),
				new BoardCell(7, 7, new Rook(Color.White)),
				new BoardCell(7, 6, new Bishop(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.WhiteTurn);
		}

		static List<Cell> GetCellsForScenario_9()
		{
			return new List<Cell>
			{
				new Cell(7, 3), new Cell(6, 4), new Cell(6, 5), new Cell(7, 5)
			};
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
		//		5	  |   |   |   |  |   |   |   |   |
		//			  _________________________________
		//		6	  |   |   |   | + | + | + |   |   |
		//			  _________________________________
		//		7	  |   |   |   | + |WKI| + |   |WKN|
		//			  _________________________________
		//			
		//			
		//			   0   1   2   3   4   5   6   7   

		static ChessBoard GetScenario_10()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),

				new BoardCell(7, 4, new King(Color.White)),
				new BoardCell(7, 7, new Knight(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.ShahForWhite);
		}

		static List<Cell> GetCellsForScenario_10()
		{
			return new List<Cell>
			{
				new Cell(7, 3), new Cell(6, 3), new Cell(6, 4), new Cell(6, 5), new Cell(7, 5)
			};
		}
	}
}
