namespace LeetCode._36._Valid_Sudoku;

public class Solution
{
  public bool IsValidSudoku(char[][] board)
  {
    for (var row = 0; row < 9; row++)
    for (var col = 0; col < 9; col++)
    {
      if (board[row][col] != '.' && !IsValid(board, row, col))
        return false;
    }
    return true;
  }

  private static bool IsValid(char[][] board, int row, int col)
  {
    for (var i = 0; i < 9; i++)
    {
      if (i != col && board[row][i] == board[row][col])
        return false;
      if (i != row && board[i][col] == board[row][col])
        return false;
      var boxRow = 3 * (row / 3) + i / 3;
      var boxCol = 3 * (col / 3) + i % 3;
      if (row != boxRow && col != boxCol && board[boxRow][boxCol] == board[row][col])
        return false;
    }
    return true;
  }
}