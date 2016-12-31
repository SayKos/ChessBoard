
using ChessBoard.Chessmens;

namespace ChessBoard.Tests.TestDataClasses
{
	class StatusTestData : TestData
	{
		public static object[] GetTestCases()
		{
			var testsName = "Status tests - ";

			return new object[]
			{
				new object[] { WhiteTurn_BlackTurn(), testsName + nameof(WhiteTurn_BlackTurn) },
				new object[] { BlackTurn_WhiteTurn(), testsName + nameof(BlackTurn_WhiteTurn) },
				new object[] { WhiteTurn_ShahForBlack(), testsName + nameof(WhiteTurn_ShahForBlack) },
				new object[] { BlackTurn_ShahForWhite(), testsName + nameof(BlackTurn_ShahForWhite) },
				new object[] { ShahForBlack_WhiteTurn(), testsName + nameof(ShahForBlack_WhiteTurn) },
				new object[] { ShahForWhite_BlackTurn(), testsName + nameof(ShahForWhite_BlackTurn) },
				new object[] { WhiteTurn_StalemateForBlack(), testsName + nameof(WhiteTurn_StalemateForBlack) },
				new object[] { BlackTurn_StalemateForWhite(), testsName + nameof(BlackTurn_StalemateForWhite) },
				new object[] { BlackTurn_BlackWin(), testsName + nameof(BlackTurn_BlackWin) },
				new object[] { WhiteTurn_WhiteWin(), testsName + nameof(WhiteTurn_WhiteWin) },
				new object[] { WhiteTurn_Draw(), testsName + nameof(WhiteTurn_Draw) }
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
		//		6	  |   |   |   |   | + |   |   |   |
		//			  _________________________________
		//		7	  |   |   |   |WQ |WKI|   |   |   |
		//			  _________________________________
		//			
		//			
		//			   0   1   2   3   4   5   6   7   

		static StatusTestModel WhiteTurn_BlackTurn()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),

				new BoardCell(7, 4, new King(Color.White)),
				new BoardCell(7, 3, new King(Color.White))
			};

			return new StatusTestModel
			{
				InitialBoard = SetupChessBoard(boardCells, GameStatus.WhiteTurn),
				ResultStatus = GameStatus.BlackTurn,
				FromCell = new Cell(7, 4),
				ToCell = new Cell(6, 4)
			};
		}

		//			  _________________________________
		//		0	  |   |   |   |   |BKI|   |   |   |
		//		 	  _________________________________
		//		1	  |   |   |   |   | + |   |   |   |
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
		//		7	  |   |   |   |WQ |WKI|   |   |   |
		//			  _________________________________
		//			
		//			
		//			   0   1   2   3   4   5   6   7   

		static StatusTestModel BlackTurn_WhiteTurn()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),

				new BoardCell(7, 4, new King(Color.White)),
				new BoardCell(7, 3, new King(Color.White))
			};

			return new StatusTestModel
			{
				InitialBoard = SetupChessBoard(boardCells, GameStatus.BlackTurn),
				ResultStatus = GameStatus.WhiteTurn,
				FromCell = new Cell(0, 4),
				ToCell = new Cell(1, 4)
			};
		}

		//			  _________________________________
		//		0	  | + |   |   |   |BKI|   |   |   |
		//		 	  _________________________________
		//		1	  |WQ |   |   |   |   |   |   |   |
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

		static StatusTestModel WhiteTurn_ShahForBlack()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),

				new BoardCell(7, 4, new King(Color.White)),
				new BoardCell(1, 0, new Queen(Color.White))
			};

			return new StatusTestModel
			{
				InitialBoard = SetupChessBoard(boardCells, GameStatus.WhiteTurn),
				ResultStatus = GameStatus.ShahForBlack,
				FromCell = new Cell(1, 0),
				ToCell = new Cell(0, 0)
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
		//		6	  |BQ |   |   |   |   |   |   |   |
		//			  _________________________________
		//		7	  | + |   |   |   |WKI|   |   |   |
		//			  _________________________________
		//			
		//			
		//			   0   1   2   3   4   5   6   7   

		static StatusTestModel BlackTurn_ShahForWhite()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),
				new BoardCell(6, 0, new Queen(Color.Black)),

				new BoardCell(7, 4, new King(Color.White))
			};

			return new StatusTestModel
			{
				InitialBoard = SetupChessBoard(boardCells, GameStatus.BlackTurn),
				ResultStatus = GameStatus.ShahForWhite,
				FromCell = new Cell(6, 0),
				ToCell = new Cell(7, 0)
			};
		}

		//			  _________________________________
		//		0	  |WQ |   |   |   |BKI|   |   |   |
		//		 	  _________________________________
		//		1	  |   |   |   |   | + |   |   |   |
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

		static StatusTestModel ShahForBlack_WhiteTurn()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),

				new BoardCell(7, 4, new King(Color.White)),
				new BoardCell(0, 0, new Queen(Color.White))
			};

			return new StatusTestModel
			{
				InitialBoard = SetupChessBoard(boardCells, GameStatus.ShahForBlack),
				ResultStatus = GameStatus.WhiteTurn,
				FromCell = new Cell(0, 4),
				ToCell = new Cell(1, 4)
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
		//		6	  |   |   |   |   | + |   |   |   |
		//			  _________________________________
		//		7	  |BQ |   |   |   |WKI|   |   |   |
		//			  _________________________________
		//			
		//			
		//			   0   1   2   3   4   5   6   7   

		static StatusTestModel ShahForWhite_BlackTurn()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 4, new King(Color.Black)),
				new BoardCell(7, 0, new Queen(Color.Black)),

				new BoardCell(7, 4, new King(Color.White))
			};

			return new StatusTestModel
			{
				InitialBoard = SetupChessBoard(boardCells, GameStatus.ShahForWhite),
				ResultStatus = GameStatus.BlackTurn,
				FromCell = new Cell(7, 4),
				ToCell = new Cell(6, 4)
			};
		}

		//			  _________________________________
		//		0	  |BKI|   |   |   |   |   |   |   |
		//		 	  _________________________________
		//		1	  |   |   |WQ |   |   |   |   |   |
		//			  _________________________________
		//		2	  |   | + |   |   |   |   |   |   |
		//			  _________________________________
		//		3	  |   |WKI|   |   |   |   |   |   |
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

		static StatusTestModel WhiteTurn_StalemateForBlack()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 0, new King(Color.Black)),

				new BoardCell(3, 1, new King(Color.White)),
				new BoardCell(1, 2, new Queen(Color.White))
			};

			return new StatusTestModel
			{
				InitialBoard = SetupChessBoard(boardCells, GameStatus.WhiteTurn),
				ResultStatus = GameStatus.StalemateForBlack,
				FromCell = new Cell(3, 1),
				ToCell = new Cell(2, 1)
			};
		}

		//			  _________________________________
		//		0	  |WKI|   |   |   |   |   |   |   |
		//		 	  _________________________________
		//		1	  |   |   |BQ |   |   |   |   |   |
		//			  _________________________________
		//		2	  |   | + |   |   |   |   |   |   |
		//			  _________________________________
		//		3	  |   |BKI|   |   |   |   |   |   |
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

		public static StatusTestModel BlackTurn_StalemateForWhite()
		{
			var boardCells = new[]
			{
				new BoardCell(3, 1, new King(Color.Black)),
				new BoardCell(1, 2, new Queen(Color.Black)),

				new BoardCell(0, 0, new King(Color.White))
			};

			return new StatusTestModel
			{
				InitialBoard = SetupChessBoard(boardCells, GameStatus.BlackTurn),
				ResultStatus = GameStatus.StalemateForWhite,
				FromCell = new Cell(3, 1),
				ToCell = new Cell(2, 1)
			};
		}

		//			  _________________________________
		//		0	  |WKI|   |   |   |   |   |   |   |
		//		 	  _________________________________
		//		1	  |   | + |BQ |   |   |   |   |   |
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

		public static StatusTestModel BlackTurn_BlackWin()
		{
			var boardCells = new[]
			{
				new BoardCell(2, 1, new King(Color.Black)),
				new BoardCell(1, 2, new Queen(Color.Black)),

				new BoardCell(0, 0, new King(Color.White))
			};

			return new StatusTestModel
			{
				InitialBoard = SetupChessBoard(boardCells, GameStatus.BlackTurn),
				ResultStatus = GameStatus.BlackWin,
				FromCell = new Cell(1, 2),
				ToCell = new Cell(1, 1)
			};
		}

		//			  _________________________________
		//		0	  |BKI|   |   |   |   |   |   |   |
		//		 	  _________________________________
		//		1	  |   | + |WQ |   |   |   |   |   |
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

		public static StatusTestModel WhiteTurn_WhiteWin()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 0, new King(Color.Black)),

				new BoardCell(2, 1, new King(Color.White)),
				new BoardCell(1, 2, new Queen(Color.White))
			};

			return new StatusTestModel
			{
				InitialBoard = SetupChessBoard(boardCells, GameStatus.WhiteTurn),
				ResultStatus = GameStatus.WhiteWin,
				FromCell = new Cell(1, 2),
				ToCell = new Cell(1, 1)
			};
		}

		//			  _________________________________
		//		0	  |BKI|   |   |   |   |   |   |   |
		//		 	  _________________________________
		//		1	  |   |   |BQ+|   |   |   |   |   |
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

		public static StatusTestModel WhiteTurn_Draw()
		{
			var boardCells = new[]
			{
				new BoardCell(0, 0, new King(Color.Black)),
				new BoardCell(1, 2, new Queen(Color.Black)),

				new BoardCell(2, 1, new King(Color.White)),
				
			};

			return new StatusTestModel
			{
				InitialBoard = SetupChessBoard(boardCells, GameStatus.WhiteTurn),
				ResultStatus = GameStatus.Draw,
				FromCell = new Cell(2, 1),
				ToCell = new Cell(1, 2)
			};
		}
	}
}
