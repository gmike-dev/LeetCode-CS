namespace LeetCode._37._Sudoku_Solver;

public class SudokuBitmaskSolver
{
  private readonly char[][] board;
  private readonly int[] rowDigits = new int[9];
  private readonly int[] colDigits = new int[9];
  private readonly int[,] boxDigits = new int[3, 3];

  public SudokuBitmaskSolver(char[][] board)
  {
    this.board = board;

    for (var i = 0; i < 9; i++)
    for (var j = 0; j < 9; j++)
    {
      if (this.board[i][j] != '.')
        SetDigit(i, j, this.board[i][j]);
    }
  }

  public bool Solve(int row, int col)
  {
    if (row == 9)
      return true;
    if (col == 9)
      return Solve(row + 1, 0);
    if (board[row][col] != '.')
      return Solve(row, col + 1);

    for (var digit = '1'; digit <= '9'; digit++)
    {
      if (CanSet(row, col, digit))
      {
        SetDigit(row, col, digit);
        if (Solve(row, col + 1))
          return true;
        UnsetDigit(row, col, digit);
      }
    }
    return false;
  }

  private bool CanSet(int row, int col, char digit)
  {
    var mask = 1 << (digit - '1');
    return (rowDigits[row] & mask) == 0 &&
           (colDigits[col] & mask) == 0 &&
           (boxDigits[row / 3, col / 3] & mask) == 0;
  }

  private void SetDigit(int row, int col, char digit)
  {
    board[row][col] = digit;
    var mask = 1 << (digit - '1');
    rowDigits[row] |= mask;
    colDigits[col] |= mask;
    boxDigits[row / 3, col / 3] |= mask;
  }

  private void UnsetDigit(int row, int col, char digit)
  {
    board[row][col] = '.';
    var mask = ~(1 << (digit - '1'));
    rowDigits[row] &= mask;
    colDigits[col] &= mask;
    boxDigits[row / 3, col / 3] &= mask;
  }
}
