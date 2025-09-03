namespace LeetCode._36._Valid_Sudoku;

public class Solution1
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

[TestFixture]
public class Solution1Tests
{
  [Test]
  public void Test1()
  {
    new Solution1().IsValidSudoku([
      ['5', '3', '.', '.', '7', '.', '.', '.', '.'],
      ['6', '.', '.', '1', '9', '5', '.', '.', '.'],
      ['.', '9', '8', '.', '.', '.', '.', '6', '.'],
      ['8', '.', '.', '.', '6', '.', '.', '.', '3'],
      ['4', '.', '.', '8', '.', '3', '.', '.', '1'],
      ['7', '.', '.', '.', '2', '.', '.', '.', '6'],
      ['.', '6', '.', '.', '.', '.', '2', '8', '.'],
      ['.', '.', '.', '4', '1', '9', '.', '.', '5'],
      ['.', '.', '.', '.', '8', '.', '.', '7', '9']
    ]).Should().BeTrue();
  }

  [Test]
  public void Test2()
  {
    new Solution1().IsValidSudoku([
      ['8', '3', '.', '.', '7', '.', '.', '.', '.'],
      ['6', '.', '.', '1', '9', '5', '.', '.', '.'],
      ['.', '9', '8', '.', '.', '.', '.', '6', '.'],
      ['8', '.', '.', '.', '6', '.', '.', '.', '3'],
      ['4', '.', '.', '8', '.', '3', '.', '.', '1'],
      ['7', '.', '.', '.', '2', '.', '.', '.', '6'],
      ['.', '6', '.', '.', '.', '.', '2', '8', '.'],
      ['.', '.', '.', '4', '1', '9', '.', '.', '5'],
      ['.', '.', '.', '.', '8', '.', '.', '7', '9']
    ]).Should().BeFalse();
  }
}
