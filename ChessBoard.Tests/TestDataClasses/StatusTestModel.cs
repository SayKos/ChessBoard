namespace ChessBoard.Tests.TestDataClasses
{
	public class StatusTestModel
	{
		public ChessBoard InitialBoard { get; set; }
		public GameStatus ResultStatus { get; set; }
		public Cell FromCell { get; set; }
		public Cell ToCell { get; set; }
	}
}
