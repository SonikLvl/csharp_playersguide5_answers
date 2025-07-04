//195 Tic-Tac-Toe
Console.Title = "Tic-Tac-Toe";

Cell[] board = Cell.CreateBoard();
BoardStateManager boardStateManager = new BoardStateManager();
Console.WriteLine("Use num pad to choose squre. Write in number of cell.");
char player = 'X';
int playerChoice;


while (true)
{
    
    Console.WriteLine($"It`s {player} turn.");
    ShowBoard(board);
    Console.WriteLine("What square do you want to play in?");
    playerChoice = Convert.ToInt32(Console.ReadLine());

    board[playerChoice - 1].StateChange(player, board);//state update

    //game enders
    if (boardStateManager.CheckCellsForCombination(board))
    {
        ShowBoard(board);
        Console.WriteLine($"Player {player} won!");
        break;
    }
    if (!boardStateManager.HaveEmptyCells(board))
    {
        ShowBoard(board);
        Console.WriteLine($"Draw!");
        break;
    }

    player = (player == 'X' ? 'O' : 'X');
}


void ShowBoard(Cell[] board)
{
    if (board != null)
    {
        Console.WriteLine($" {board[6].StateShow()} | {board[7].StateShow()} | {board[8].StateShow()}\n" + // 7 8 9
                          $"---+---+---\n" +
                          $" {board[3].StateShow()} | {board[4].StateShow()} | {board[5].StateShow()}\n" + // 4 5 6
                          $"---+---+---\n" +
                          $" {board[0].StateShow()} | {board[1].StateShow()} | {board[2].StateShow()}\n"); // 1 2 3
    }
    else Console.WriteLine("Board is null.");
}
class Cell
{
    //private CellNumber CellNumber { get; init; }
    public CellState State { get; private set; } = CellState.Empty;

   // private Cell() { } //cell initialisation = for creating board

    public static Cell[] CreateBoard() 
    {
        Cell[] board = new Cell[9];
        for (int i = 0; i<9; i++)
        {
            board[i] = new Cell();
        }
        return board; //returns cells 1 to 9 (downleft to upperright)
    }
    
    public char StateShow()
    {
        return State switch
        {
            CellState.Empty => ' ',
            CellState.Circle => 'O',
            CellState.Cross => 'X',
            _ => ' '
        };
    }
    public void StateChange(char player, Cell[] board)
    {
        if (player != null)
        {
            if (State == CellState.Empty)
                State = player switch
                {
                    'X' => CellState.Cross,
                    'O' => CellState.Circle,
                    _ => CellState.Empty
                };
            else 
            { 
                Console.WriteLine("Cell taken choose another.");
                int playerChoice = Convert.ToInt32(Console.ReadLine());
                board[playerChoice - 1].StateChange(player, board);
            }
        }
        else Console.WriteLine("No player to take cell");
    }
}

class BoardStateManager
{
    private static (CellState, CellState, CellState)[] winCombinations;
    public bool HaveEmptyCells(Cell[] board)
    {
        return Array.Exists(board, element => element.State == CellState.Empty);
    }
    public bool CheckCellsForCombination(Cell[] board)
    {
        winCombinations = new (CellState, CellState, CellState)[]{
            (board[6].State, board[7].State, board[8].State), //horisontal
            (board[3].State, board[4].State, board[5].State),
            (board[0].State, board[1].State, board[2].State),

            (board[0].State, board[3].State, board[6].State), //vertical
            (board[1].State, board[4].State, board[7].State),
            (board[2].State, board[5].State, board[8].State),

            (board[2].State, board[4].State, board[6].State), //crossed
            (board[0].State, board[4].State, board[8].State)}
        ;
        foreach (var winComb in winCombinations) 
        {
            if (winComb.Equals((CellState.Circle, CellState.Circle, CellState.Circle)) || winComb.Equals((CellState.Cross, CellState.Cross, CellState.Cross)))
            {
                return true;
            }
        }
        return false;
    }
}
//enum CellNumber {DownLeft = 1, Down, DownRight, Left, Center, Right, UpLeft, Up, UpRight }
enum CellState { Empty, Circle, Cross}