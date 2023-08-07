using System;

namespace LeetCode._37._Sudoku_Solver;

public class Solution
{
  public void SolveSudoku(char[][] board)
  {
    if (!new SudokuSolver(board).Solve(0, 0))
      throw new InvalidOperationException("Solution not found");
  }

  private class SudokuSolver
  {
    private readonly char[][] _board;
    private readonly int[] _rowDigits = new int[9];
    private readonly int[] _colDigits = new int[9];
    private readonly int[,] _boxDigits = new int[3, 3];

    public SudokuSolver(char[][] board)
    {
      _board = board;

      for (var i = 0; i < 9; i++)
      for (var j = 0; j < 9; j++)
      {
        if (_board[i][j] != '.')
          SetDigit(i, j, _board[i][j]);
      }
    }

    public bool Solve(int row, int col)
    {
      if (row == 9)
        return true;
      if (col == 9)
        return Solve(row + 1, 0);
      if (_board[row][col] != '.')
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
      return (_rowDigits[row] & mask) == 0 &&
             (_colDigits[col] & mask) == 0 &&
             (_boxDigits[row / 3, col / 3] & mask) == 0;
    }

    private void SetDigit(int row, int col, char digit)
    {
      _board[row][col] = digit;
      var mask = 1 << (digit - '1');
      _rowDigits[row] |= mask;
      _colDigits[col] |= mask;
      _boxDigits[row / 3, col / 3] |= mask;
    }

    private void UnsetDigit(int row, int col, char digit)
    {
      _board[row][col] = '.';
      var mask = ~(1 << (digit - '1'));
      _rowDigits[row] &= mask;
      _colDigits[col] &= mask;
      _boxDigits[row / 3, col / 3] &= mask;
    }
  }
}