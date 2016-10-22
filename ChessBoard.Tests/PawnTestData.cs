using ChessBoard.Chessmens;

namespace ChessBoard.Tests
{
	class PawnTestData : TestData
	{
		public static object[] GetTestCasesForAcceptableCellsForPawn()
		{
			return new object[]
			{
				new object[] { GetScenario_1(), new Cell(6, 3), GetCellsForScenario_1() },
				new object[] { GetScenario_2(), new Cell(1, 3), GetCellsForScenario_2() },
				new object[] { GetScenario_3(), new Cell(5, 3), GetCellsForScenario_3() },
				new object[] { GetScenario_4(), new Cell(2, 3), GetCellsForScenario_4() },
				new object[] { GetScenario_5(), new Cell(5, 3), GetCellsForScenario_5() },
				new object[] { GetScenario_6(), new Cell(5, 3), GetCellsForScenario_6() },
				new object[] { GetScenario_7(), new Cell(5, 3), GetCellsForScenario_7() },
				new object[] { GetScenario_8(), new Cell(2, 3), GetCellsForScenario_8() },
				new object[] { GetScenario_9(), new Cell(2, 3), GetCellsForScenario_9() },
				new object[] { GetScenario_10(), new Cell(2, 3), GetCellsForScenario_10() },
				new object[] { GetScenario_11(), new Cell(5, 3), GetCellsForScenario_11() },
				new object[] { GetScenario_12(), new Cell(4, 3), GetCellsForScenario_12() },
				new object[] { GetScenario_13(), new Cell(5, 3), GetCellsForScenario_13() },
				new object[] { GetScenario_14(), new Cell(4, 3), GetCellsForScenario_14() },
				new object[] { GetScenario_17(), new Cell(5, 2), GetCellsForScenario_17() },
				new object[] { GetScenario_18(), new Cell(5, 2), GetCellsForScenario_18() },
				new object[] { GetScenario_19(), new Cell(2, 2), GetCellsForScenario_19() },
				new object[] { GetScenario_20(), new Cell(2, 2), GetCellsForScenario_20() },
				new object[] { GetScenario_21(), new Cell(6, 2), GetCellsForScenario_21() },
				new object[] { GetScenario_22(), new Cell(1, 2), GetCellsForScenario_22() }
			};
		}

		static ChessBoard GetEmptyChessBoard(BoardCell[] boardCellsToSet, GameStatus status)
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

			return GetEmptyChessBoard(boardCells, GameStatus.WhiteTurn);
		}

		static Cell[] GetCellsForScenario_1()
		{
			return new[]
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

			return GetEmptyChessBoard(boardCells, GameStatus.BlackTurn);
		}

		static Cell[] GetCellsForScenario_2()
		{
			return new[]
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

			return GetEmptyChessBoard(boardCells, GameStatus.WhiteTurn);
		}

		static Cell[] GetCellsForScenario_3()
		{
			return new[]
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
				new BoardCell(5, 3, new Pawn(Color.Black)),
				new BoardCell(7, 4, new King(Color.White))
			};

			return GetEmptyChessBoard(boardCells, GameStatus.BlackTurn);
		}

		static Cell[] GetCellsForScenario_4()
		{
			return new[]
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

			return GetEmptyChessBoard(boardCells, GameStatus.WhiteTurn);
		}

		static Cell[] GetCellsForScenario_5()
		{
			return new[]
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

			return GetEmptyChessBoard(boardCells, GameStatus.WhiteTurn);
		}

		static Cell[] GetCellsForScenario_6()
		{
			return new[]
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

			return GetEmptyChessBoard(boardCells, GameStatus.WhiteTurn);
		}

		static Cell[] GetCellsForScenario_7()
		{
			return new[]
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

			return GetEmptyChessBoard(boardCells, GameStatus.BlackTurn);
		}

		static Cell[] GetCellsForScenario_8()
		{
			return new[]
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

			return GetEmptyChessBoard(boardCells, GameStatus.BlackTurn);
		}

		static Cell[] GetCellsForScenario_9()
		{
			return new[]
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

			return GetEmptyChessBoard(boardCells, GameStatus.BlackTurn);
		}

		static Cell[] GetCellsForScenario_10()
		{
			return new[]
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

			return GetEmptyChessBoard(boardCells, GameStatus.WhiteTurn);
		}

		static Cell[] GetCellsForScenario_11()
		{
			return new Cell[] { };
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

		static Cell[] GetCellsForScenario_12()
		{
			return new Cell[] { };
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

			return GetEmptyChessBoard(boardCells, GameStatus.WhiteTurn);
		}

		static Cell[] GetCellsForScenario_13()
		{
			return new[]
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

			return GetEmptyChessBoard(boardCells, GameStatus.BlackTurn);
		}

		static Cell[] GetCellsForScenario_14()
		{
			return new[]
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

		static ChessBoard GetScenario_17()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),
				new BoardCell(5, 2, new Pawn(Color.White)),
				new BoardCell(3, 0, new Queen(Color.Black)),
				new BoardCell(7, 4, new King(Color.White))
			};

			return GetEmptyChessBoard(boardCells, GameStatus.WhiteTurn);
		}

		static Cell[] GetCellsForScenario_17()
		{
			return new Cell[] { };
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

		static ChessBoard GetScenario_18()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),
				new BoardCell(5, 2, new Pawn(Color.White)),
				new BoardCell(4, 1, new Queen(Color.Black)),
				new BoardCell(7, 4, new King(Color.White))
			};

			return GetEmptyChessBoard(boardCells, GameStatus.WhiteTurn);
		}

		static Cell[] GetCellsForScenario_18()
		{
			return new[]
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

		static ChessBoard GetScenario_19()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),
				new BoardCell(2, 2, new Pawn(Color.Black)),
				new BoardCell(4, 0, new Queen(Color.White)),
				new BoardCell(7, 4, new King(Color.White))
			};

			return GetEmptyChessBoard(boardCells, GameStatus.BlackTurn);
		}

		static Cell[] GetCellsForScenario_19()
		{
			return new Cell[] { };
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

		static ChessBoard GetScenario_20()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),
				new BoardCell(2, 2, new Pawn(Color.Black)),
				new BoardCell(3, 1, new Queen(Color.White)),
				new BoardCell(7, 4, new King(Color.White))
			};

			return GetEmptyChessBoard(boardCells, GameStatus.BlackTurn);
		}

		static Cell[] GetCellsForScenario_20()
		{
			return new[]
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

		static ChessBoard GetScenario_21()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),
				new BoardCell(6, 2, new Pawn(Color.White)),
				new BoardCell(3, 0, new Queen(Color.Black)),
				new BoardCell(7, 4, new King(Color.White))
			};

			return GetEmptyChessBoard(boardCells, GameStatus.WhiteTurn);
		}

		static Cell[] GetCellsForScenario_21()
		{
			return new[]
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

		static ChessBoard GetScenario_22()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),
				new BoardCell(1, 2, new Pawn(Color.Black)),
				new BoardCell(4, 0, new Queen(Color.White)),
				new BoardCell(7, 4, new King(Color.White))
			};

			return GetEmptyChessBoard(boardCells, GameStatus.BlackTurn);
		}

		static Cell[] GetCellsForScenario_22()
		{
			return new[]
			{
				new Cell(2, 2)
			};
		}
	}
}
