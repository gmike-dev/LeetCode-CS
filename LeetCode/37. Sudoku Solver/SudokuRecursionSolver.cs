namespace LeetCode._37._Sudoku_Solver;

public class SudokuRecursionSolver(char[][] board)
{
  public bool Solve()
  {
    for (var row = 0; row < 9; row++)
    for (var col = 0; col < 9; col++)
    {
      if (board[row][col] == '.')
      {
        for (var digit = '1'; digit <= '9'; digit++)
        {
          if (CanSet(row, col, digit))
          {
            board[row][col] = digit;
            if (Solve())
              return true;
            board[row][col] = '.';
          }
        }
        return false;
      }
    }
    return true;
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
