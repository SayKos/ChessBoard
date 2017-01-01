# ChessBoard
Small library to help you to manage an entire chess game and serialize it to Json. 


## It helps you:
*	Create new game with start or specific chessmen positions or with Json serialized format;
*	Get acceptable cells for every chessman;
*	Make movements and get correct game status after it;
*	Serialize game to Json.



## Usage


### Serialized game
How does serialized game look like you can find [here: StartPositions.json]( https://github.com/SayKos/ChessBoard/blob/master/ChessBoard.Tests/StartPositions.json). Line breaks were added just for readability.


### Board presentation
Board is two-dimensional array (8 rows and 8 columns). Board stored in BoardCells property of ChessBoard instance.

```c#
//       _________________________________
// 0	  |   |   |   |   |   |   |   |   |
//       _________________________________
// 1	  |   |   |   |   |   |   |   |   |
//       _________________________________
// 2	  |   |   |   |   |   |   |   |   |
//       _________________________________
// 3	  |   |   |   |   |   |   |   |   |
//       _________________________________
// 4	  |   |   |   |   |   |   |   |   |
//       _________________________________
// 5	  |   |   |   |   |   |   |   |   |
//       _________________________________
// 6	  |   |   |   |   |   |   |   |   |
//       _________________________________
// 7	  |   |   |   |   |   |   |   |   |
//       _________________________________
//			
//         0   1   2   3   4   5   6   7   
```

```c#
Cell cell = chessboard.BoardCells[3, 5]; // cell on 3 row and 5 column
```



### Create new instance


#### New instance and set start position
```c#
var chessBoard = new ChessBoard();
chessBoard.SetStartPosition(); // Set default start positions for all chessmen and GameStatus.WhiteTurn status.
```


#### New instance with predefined board cells
```c#
var chessBoard = new ChessBoard(boardCells); // BoardCell[8, 8]
```


#### New instance with serialized chess board
```c#
var chessBoard = new ChessBoard(serializedChessBoard); // string
```


### Get current status of the game

Status is enum that can be:
*	WhiteTurn,
*	BlackTurn,
*	ShahForWhite,
*	ShahForBlack,
*	WhiteWin,
*	BlackWin,
*	StalemateForBlack,
*	StalemateForWhite,
*	Draw

```c#
GameStatus status = chessboard.Status;
```
Also new status returned as result of MoveChessman method:
```c#
GameStatus status = chessboard.MoveChessman(oldPosition, newPosition);
```


### Get serialized chess board
```c#
string status = chessboard.GetSerializedChessBoard();
```


### Make movement for the specific chessman

To make movement you just need to specify old and new cells:
```c#
Cell oldPosition = new Cell(3, 5);
Cell newPosition = new Cell(3, 6);

GameStatus status = chessboard.MoveChessman(oldPosition, newPosition);
```

Also, in case of Pawn moving to the last row, you need to specify new type for Pawn transformation (promotion):
```c#
ChessmenType? newType = ChessmenType.Queen; // Can’t be as King or Pawn
GameStatus status = chessboard.MoveChessman(oldPosition, newPosition, newType);
```


### Get acceptable cells for the specific cell

You can get acceptable cells for any chessman. You need to specify it’s cell:
```c#
Cell queenCell = new Cell(3, 5);
List<Cell> acceptableCells = chessboard.GetAcceptableCells(queenCell);
```


### Stop game by giving up

It will set Status as BlackWin or WhiteWin depeding on specified Color.
```c#
chessboard.GiveUp(Color.Black);
```


### Check that game is not over

Just checking that game status is not WhiteWin, BlackWin, StalemateForWhite, StalemateForBlack or Draw;

```c#
bool isGameOver = chessboard.IsGameOver();
```
