using System.Collections.Generic;
using ChessBoard.Chessmens;

namespace ChessBoard.Tests.TestDataClasses
{
	class PawnTestData : TestData
	{
		public static object[] GetAcceptableCellsTestCases()
		{
			var testsName = "Pawn tests - ";

			return new object[]
			{
				new object[] { GetScenario_1(), new Cell(6, 3), GetCellsForScenario_1(), testsName + nameof(GetScenario_1) },
				new object[] { GetScenario_2(), new Cell(1, 3), GetCellsForScenario_2(), testsName + nameof(GetScenario_2) },
				new object[] { GetScenario_3(), new Cell(5, 3), GetCellsForScenario_3(), testsName + nameof(GetScenario_3) },
				new object[] { GetScenario_4(), new Cell(2, 3), GetCellsForScenario_4(), testsName + nameof(GetScenario_4) },
				new object[] { GetScenario_5(), new Cell(5, 3), GetCellsForScenario_5(), testsName + nameof(GetScenario_5) },
				new object[] { GetScenario_6(), new Cell(5, 3), GetCellsForScenario_6(), testsName + nameof(GetScenario_6) },
				new object[] { GetScenario_7(), new Cell(5, 3), GetCellsForScenario_7(), testsName + nameof(GetScenario_7) },
				new object[] { GetScenario_8(), new Cell(2, 3), GetCellsForScenario_8(), testsName + nameof(GetScenario_8) },
				new object[] { GetScenario_9(), new Cell(2, 3), GetCellsForScenario_9(), testsName + nameof(GetScenario_9) },
				new object[] { GetScenario_10(), new Cell(2, 3), GetCellsForScenario_10(), testsName + nameof(GetScenario_10) },
				new object[] { GetScenario_11(), new Cell(5, 3), GetCellsForScenario_11(), testsName + nameof(GetScenario_11) },
				new object[] { GetScenario_12(), new Cell(4, 3), GetCellsForScenario_12(), testsName + nameof(GetScenario_12) },
				new object[] { GetScenario_13(), new Cell(5, 3), GetCellsForScenario_13(), testsName + nameof(GetScenario_13) },
				new object[] { GetScenario_14(), new Cell(4, 3), GetCellsForScenario_14(), testsName + nameof(GetScenario_14) },
				
				// todo: uncomment when shah will be done
				//new object[] { GetScenario_15(), new Cell(5, 2), GetCellsForScenario_15(), nameof(GetScenario_15) },
				//new object[] { GetScenario_16(), new Cell(5, 2), GetCellsForScenario_16(), nameof(GetScenario_16) },
				//new object[] { GetScenario_17(), new Cell(2, 2), GetCellsForScenario_17(), nameof(GetScenario_17) },
				//new object[] { GetScenario_18(), new Cell(2, 2), GetCellsForScenario_18(), nameof(GetScenario_18) },
				//new object[] { GetScenario_19(), new Cell(6, 2), GetCellsForScenario_19(), nameof(GetScenario_19) },
				//new object[] { GetScenario_20(), new Cell(1, 2), GetCellsForScenario_20(), nameof(GetScenario_20) }
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
		//		4	  |   |   |   | + |   |   |   |   |
		//			  _________________________________
		//		5	  |   |   |   | + |   |   |   |   |
		//			  _________________________________
		//		6	  |   |   |   |WP |   |   |   |   |
		//			  _________________________________
		//		7	  |   |   |   |   |WKI|   |   |   |
		//			  _________________________________
		//			
		//			
		//			   0   1   2   3   4   5   6   7   

		static ChessBoard GetScenario_1()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),

				new BoardCell(6, 3, new Pawn(Color.White)),
				new BoardCell(7, 4, new King(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.WhiteTurn);
		}

		static List<Cell> GetCellsForScenario_1()
		{
			return new List<Cell>
			{
				new Cell(5, 3),
				new Cell(4, 3)
			};
		}

		//			  _________________________________
		//		0	  |   |   |   |   |BKI|   |   |   |
		//		 	  _________________________________
		//		1	  |   |   |   |BP |   |   |   |   |
		//			  _________________________________
		//		2	  |   |   |   | + |   |   |   |   |
		//			  _________________________________
		//		3	  |   |   |   | + |   |   |   |   |
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

		static ChessBoard GetScenario_2()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),
				new BoardCell(1, 3, new Pawn(Color.Black)),
				new BoardCell(7, 4, new King(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.BlackTurn);
		}

		static List<Cell> GetCellsForScenario_2()
		{
			return new List<Cell>
			{
				new Cell(2, 3),
				new Cell(3, 3)
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
		//		4	  |   |   |   | + |   |   |   |   |
		//			  _________________________________
		//		5	  |   |   |   |WP |   |   |   |   |
		//			  _________________________________
		//		6	  |   |   |   |   |   |   |   |   |
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
				new BoardCell(5, 3, new Pawn(Color.White)),
				new BoardCell(7, 4, new King(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.WhiteTurn);
		}

		static List<Cell> GetCellsForScenario_3()
		{
			return new List<Cell>
			{
				new Cell(4, 3)
			};
		}

		//			  _________________________________
		//		0	  |   |   |   |   |BKI|   |   |   |
		//		 	  _________________________________
		//		1	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		2	  |   |   |   |BP |   |   |   |   |
		//			  _________________________________
		//		3	  |   |   |   | + |   |   |   |   |
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

		static ChessBoard GetScenario_4()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),
				new BoardCell(2, 3, new Pawn(Color.Black)),
				new BoardCell(7, 4, new King(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.BlackTurn);
		}

		static List<Cell> GetCellsForScenario_4()
		{
			return new List<Cell>
			{
				new Cell(3, 3)
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
		//		4	  |   |   |   | + |BP+|   |   |   |
		//			  _________________________________
		//		5	  |   |   |   |WP |   |   |   |   |
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
				new BoardCell(5, 3, new Pawn(Color.White)),
				new BoardCell(4, 4, new Pawn(Color.Black)),
				new BoardCell(7, 4, new King(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.WhiteTurn);
		}

		static List<Cell> GetCellsForScenario_5()
		{
			return new List<Cell>
			{
				new Cell(4, 3),
				new Cell(4, 4)
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
		//		4	  |   |   |BP+| + |   |   |   |   |
		//			  _________________________________
		//		5	  |   |   |   |WP |   |   |   |   |
		//			  _________________________________
		//		6	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		7	  |   |   |   |   |WKI|   |   |   |
		//			  _________________________________
		//			
		//			
		//			   0   1   2   3   4   5   6   7   

		static ChessBoard GetScenario_6()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),
				new BoardCell(5, 3, new Pawn(Color.White)),
				new BoardCell(4, 2, new Pawn(Color.Black)),
				new BoardCell(7, 4, new King(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.WhiteTurn);
		}

		static List<Cell> GetCellsForScenario_6()
		{
			return new List<Cell>
			{
				new Cell(4, 3),
				new Cell(4, 2)
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
		//		4	  |   |   |BP+| + |BP+|   |   |   |
		//			  _________________________________
		//		5	  |   |   |   |WP |   |   |   |   |
		//			  _________________________________
		//		6	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		7	  |   |   |   |   |WKI|   |   |   |
		//			  _________________________________
		//			
		//			
		//			   0   1   2   3   4   5   6   7   

		static ChessBoard GetScenario_7()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),
				new BoardCell(5, 3, new Pawn(Color.White)),
				new BoardCell(4, 2, new Pawn(Color.Black)),
				new BoardCell(4, 4, new Pawn(Color.Black)),
				new BoardCell(7, 4, new King(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.WhiteTurn);
		}

		static List<Cell> GetCellsForScenario_7()
		{
			return new List<Cell>
			{
				new Cell(4, 3),
				new Cell(4, 2),
				new Cell(4, 4)
			};
		}

		//			  _________________________________
		//		0	  |   |   |   |   |BKI|   |   |   |
		//		 	  _________________________________
		//		1	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		2	  |   |   |   |BP |   |   |   |   |
		//			  _________________________________
		//		3	  |   |   |   | + |WP+|   |   |   |
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

		static ChessBoard GetScenario_8()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),
				new BoardCell(2, 3, new Pawn(Color.Black)),
				new BoardCell(3, 4, new Pawn(Color.White)),
				new BoardCell(7, 4, new King(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.BlackTurn);
		}

		static List<Cell> GetCellsForScenario_8()
		{
			return new List<Cell>
			{
				new Cell(3, 3),
				new Cell(3, 4)
			};
		}

		//			  _________________________________
		//		0	  |   |   |   |   |BKI|   |   |   |
		//		 	  _________________________________
		//		1	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		2	  |   |   |   |BP |   |   |   |   |
		//			  _________________________________
		//		3	  |   |   |WP+| + |   |   |   |   |
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

		static ChessBoard GetScenario_9()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),
				new BoardCell(2, 3, new Pawn(Color.Black)),
				new BoardCell(3, 2, new Pawn(Color.White)),
				new BoardCell(7, 4, new King(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.BlackTurn);
		}

		static List<Cell> GetCellsForScenario_9()
		{
			return new List<Cell>
			{
				new Cell(3, 3),
				new Cell(3, 2)
			};
		}

		//			  _________________________________
		//		0	  |   |   |   |   |BKI|   |   |   |
		//		 	  _________________________________
		//		1	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		2	  |   |   |   |BP |   |   |   |   |
		//			  _________________________________
		//		3	  |   |   |WP+| + |WP+|   |   |   |
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

		static ChessBoard GetScenario_10()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),
				new BoardCell(2, 3, new Pawn(Color.Black)),
				new BoardCell(3, 4, new Pawn(Color.White)),
				new BoardCell(3, 2, new Pawn(Color.White)),
				new BoardCell(7, 4, new King(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.BlackTurn);
		}

		static List<Cell> GetCellsForScenario_10()
		{
			return new List<Cell>
			{
				new Cell(3, 3),
				new Cell(3, 2),
				new Cell(3, 4)
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
		//		4	  |   |   |   |BP |   |   |   |   |
		//			  _________________________________
		//		5	  |   |   |   |WP |   |   |   |   |
		//			  _________________________________
		//		6	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		7	  |   |   |   |   |WKI|   |   |   |
		//			  _________________________________
		//			
		//			
		//			   0   1   2   3   4   5   6   7   

		static ChessBoard GetScenario_11()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),
				new BoardCell(5, 3, new Pawn(Color.White)),
				new BoardCell(4, 3, new Pawn(Color.Black)),
				new BoardCell(7, 4, new King(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.WhiteTurn);
		}

		static List<Cell> GetCellsForScenario_11()
		{
			return new List<Cell>();
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
		//		4	  |   |   |   |BP |   |   |   |   |
		//			  _________________________________
		//		5	  |   |   |   |WP |   |   |   |   |
		//			  _________________________________
		//		6	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		7	  |   |   |   |   |WKI|   |   |   |
		//			  _________________________________
		//			
		//			
		//			   0   1   2   3   4   5   6   7   

		static ChessBoard GetScenario_12()
		{
			ChessBoard chessBoard = GetScenario_11();
			chessBoard.Status = GameStatus.BlackTurn;

			return chessBoard;
		}

		static List<Cell> GetCellsForScenario_12()
		{
			return new List<Cell>();
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
		//		4	  |   |   |BP+|BP |   |   |   |   |
		//			  _________________________________
		//		5	  |   |   |   |WP |   |   |   |   |
		//			  _________________________________
		//		6	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		7	  |   |   |   |   |WKI|   |   |   |
		//			  _________________________________
		//			
		//			
		//			   0   1   2   3   4   5   6   7   

		static ChessBoard GetScenario_13()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),
				new BoardCell(5, 3, new Pawn(Color.White)),
				new BoardCell(4, 2, new Pawn(Color.Black)),
				new BoardCell(4, 3, new Pawn(Color.Black)),
				new BoardCell(7, 4, new King(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.WhiteTurn);
		}

		static List<Cell> GetCellsForScenario_13()
		{
			return new List<Cell>
			{
				new Cell(4, 2)
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
		//		4	  |   |   |   |BP |   |   |   |   |
		//			  _________________________________
		//		5	  |   |   |   |WP |WP+|   |   |   |
		//			  _________________________________
		//		6	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		7	  |   |   |   |   |WKI|   |   |   |
		//			  _________________________________
		//			
		//			
		//			   0   1   2   3   4   5   6   7   

		static ChessBoard GetScenario_14()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),
				new BoardCell(5, 3, new Pawn(Color.White)),
				new BoardCell(4, 3, new Pawn(Color.Black)),
				new BoardCell(5, 4, new Pawn(Color.White)),
				new BoardCell(7, 4, new King(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.BlackTurn);
		}

		static List<Cell> GetCellsForScenario_14()
		{
			return new List<Cell>
			{
				new Cell(5, 4)
			};
		}

		//			  _________________________________
		//		0	  |   |   |   |   |BKI|   |   |   |
		//		 	  _________________________________
		//		1	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		2	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		3	  |BQ |   |   |   |   |   |   |   |
		//			  _________________________________
		//		4	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		5	  |   |   |WP |   |   |   |   |   |
		//			  _________________________________
		//		6	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		7	  |   |   |   |   |WKI|   |   |   |
		//			  _________________________________
		//			
		//			
		//			   0   1   2   3   4   5   6   7   

		static ChessBoard GetScenario_15()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),
				new BoardCell(5, 2, new Pawn(Color.White)),
				new BoardCell(3, 0, new Queen(Color.Black)),
				new BoardCell(7, 4, new King(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.WhiteTurn);
		}

		static List<Cell> GetCellsForScenario_15()
		{
			return new List<Cell>();
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
		//		4	  |   |BQ+|   |   |   |   |   |   |
		//			  _________________________________
		//		5	  |   |   |WP |   |   |   |   |   |
		//			  _________________________________
		//		6	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		7	  |   |   |   |   |WKI|   |   |   |
		//			  _________________________________
		//			
		//			
		//			   0   1   2   3   4   5   6   7   

		static ChessBoard GetScenario_16()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),
				new BoardCell(5, 2, new Pawn(Color.White)),
				new BoardCell(4, 1, new Queen(Color.Black)),
				new BoardCell(7, 4, new King(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.WhiteTurn);
		}

		static List<Cell> GetCellsForScenario_16()
		{
			return new List<Cell>
			{
				new Cell(4, 1)
			};
		}

		//			  _________________________________
		//		0	  |   |   |   |   |BKI|   |   |   |
		//		 	  _________________________________
		//		1	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		2	  |   |   |BP |   |   |   |   |   |
		//			  _________________________________
		//		3	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		4	  |WQ |   |   |   |   |   |   |   |
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

		static ChessBoard GetScenario_17()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),
				new BoardCell(2, 2, new Pawn(Color.Black)),
				new BoardCell(4, 0, new Queen(Color.White)),
				new BoardCell(7, 4, new King(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.BlackTurn);
		}

		static List<Cell> GetCellsForScenario_17()
		{
			return new List<Cell>();
		}

		//			  _________________________________
		//		0	  |   |   |   |   |BKI|   |   |   |
		//		 	  _________________________________
		//		1	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		2	  |   |   |BP |   |   |   |   |   |
		//			  _________________________________
		//		3	  |   |WQ+|   |   |   |   |   |   |
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

		static ChessBoard GetScenario_18()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),
				new BoardCell(2, 2, new Pawn(Color.Black)),
				new BoardCell(3, 1, new Queen(Color.White)),
				new BoardCell(7, 4, new King(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.BlackTurn);
		}

		static List<Cell> GetCellsForScenario_18()
		{
			return new List<Cell>
			{
				new Cell(3, 1)
			};
		}

		//			  _________________________________
		//		0	  |   |   |   |   |BKI|   |   |   |
		//		 	  _________________________________
		//		1	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		2	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		3	  |BQ |   |   |   |   |   |   |   |
		//			  _________________________________
		//		4	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		5	  |   |   | + |   |   |   |   |   |
		//			  _________________________________
		//		6	  |   |   |WP |   |   |   |   |   |
		//			  _________________________________
		//		7	  |   |   |   |   |WKI|   |   |   |
		//			  _________________________________
		//			
		//			
		//			   0   1   2   3   4   5   6   7   

		static ChessBoard GetScenario_19()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),
				new BoardCell(6, 2, new Pawn(Color.White)),
				new BoardCell(3, 0, new Queen(Color.Black)),
				new BoardCell(7, 4, new King(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.ShahForWhite);
		}

		static List<Cell> GetCellsForScenario_19()
		{
			return new List<Cell>
			{
				new Cell(5, 2)
			};
		}

		//			  _________________________________
		//		0	  |   |   |   |   |BKI|   |   |   |
		//		 	  _________________________________
		//		1	  |   |   |BP |   |   |   |   |   |
		//			  _________________________________
		//		2	  |   |   | + |   |   |   |   |   |
		//			  _________________________________
		//		3	  |   |   |   |   |   |   |   |   |
		//			  _________________________________
		//		4	  |WQ |   |   |   |   |   |   |   |
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

		static ChessBoard GetScenario_20()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),
				new BoardCell(1, 2, new Pawn(Color.Black)),
				new BoardCell(4, 0, new Queen(Color.White)),
				new BoardCell(7, 4, new King(Color.White))
			};

			return SetupChessBoard(boardCells, GameStatus.ShahForBlack);
		}

		static List<Cell> GetCellsForScenario_20()
		{
			return new List<Cell>
			{
				new Cell(2, 2)
			};
		}
	}
}
