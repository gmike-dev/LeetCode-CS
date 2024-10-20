namespace LeetCode._37._Sudoku_Solver;

public class Solution
{
  public void SolveSudoku(char[][] board)
  {
    if (!new SudokuOptimizedRecursionSolver(board).Solve(0, 0))
      throw new InvalidOperationException("Solution not found");
  }

  public void SolveSudoku_SimpleRecursion(char[][] board)
  {
    if (!new SudokuRecursionSolver(board).Solve())
      throw new InvalidOperationException("Solution not found");
  }

  public void SolveSudoku_Bitmasks(char[][] board)
  {
    if (!new SudokuBitmaskSolver(board).Solve(0, 0))
      throw new InvalidOperationException("Solution not found");
  }
}
