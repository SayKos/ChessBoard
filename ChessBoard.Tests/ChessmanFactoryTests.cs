using System;
using System.Collections.Generic;
using ChessBoard.Chessmens;
using NUnit.Framework;

namespace ChessBoard.Tests
{
	[TestFixture]
	class ChessmanFactoryTests
	{
		[Test, TestCaseSource(nameof(GetChessmanTypes))]
		public void TryToCreateChessmanTest(ChessmenType chessmanType, Type expectedType)
		{
			var color = Color.Black;
			var createdChessman = ChessmanFactory.TryToCreateChessman(color, chessmanType);

			Assert.AreEqual(createdChessman.GetType(), expectedType, "Types should be aqual");
			Assert.AreEqual(createdChessman.Type, chessmanType, "Chessman types should be aqual");
			Assert.AreEqual(createdChessman.Color, color, "Colors types should be aqual");
		}

		static object[] GetChessmanTypes()
		{
			return new object[]
			{
				new object[] { ChessmenType.Pawn, typeof(Pawn) },
				new object[] { ChessmenType.Rook, typeof(Rook) },
				new object[] { ChessmenType.Knight, typeof(Knight) },
				new object[] { ChessmenType.Bishop, typeof(Bishop) },
				new object[] { ChessmenType.Queen, typeof(Queen) },
				new object[] { ChessmenType.King, typeof(King) }
			};
		}

		[Test, TestCaseSource(nameof(GetStartPositionsAndExpectedTypes))]
		public void TryToCreateChessmanOnStartPosition(int row, int collumn, Type expectedType, ChessmenType expectedChessmenType)
		{
			var createdChessman = ChessmanFactory.TryToCreateChessmanOnStartPosition(row, collumn);

			Assert.AreEqual(createdChessman.GetType(), expectedType, "Types should be aqual");
			Assert.AreEqual(createdChessman.Type, expectedChessmenType, "Chessman types should be aqual");
		}

		static List<object> GetStartPositionsAndExpectedTypes()
		{
			List<object> cases = new List<object>();

			cases.AddRange(TestData.GetPawnStartPositionsAndExpectedTypes());
			cases.AddRange(TestData.GetRookStartPositionsAndExpectedTypes());
			cases.AddRange(TestData.GetKnightStartPositionsAndExpectedTypes());
			cases.AddRange(TestData.GetBishopStartPositionsAndExpectedTypes());
			cases.AddRange(TestData.GetQueenStartPositionsAndExpectedTypes());
			cases.AddRange(TestData.GetKingStartPositionsAndExpectedTypes());

			return cases;
		}
	}
}
