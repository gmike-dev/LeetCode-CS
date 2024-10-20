namespace LeetCode._37._Sudoku_Solver;

public class SudokuOptimizedRecursionSolver(char[][] board)
{
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
        board[row][col] = digit;
        if (Solve(row, col + 1))
          return true;
        board[row][col] = '.';
      }
    }
    return false;
  }

  private bool CanSet(int row, int col, char digit)
  {
    for (var i = 0; i < 9; i++)
    {
      if (board[row][i] == digit || board[i][col] == digit ||
          board[3 * (row / 3) + i / 3][3 * (col / 3) + i % 3] == digit)
        return false;
    }
    return true;
  }
}
