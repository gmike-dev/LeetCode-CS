namespace LeetCode._2352._Equal_Row_and_Column_Pairs;

public class Solution
{
  public int EqualPairs(int[][] grid)
  {
    var answer = 0;
    var n = grid.Length;
    for (var row = 0; row < n; row++)
    {
      for (var col = 0; col < n; col++)
      {
        if (IsEquals(grid, row, col))
          answer++;
      }
    }
    return answer;
  }

  private bool IsEquals(int[][] grid, int row, int column)
  {
    var n = grid.Length;
    for (var i = 0; i < n; i++)
    {
      if (grid[row][i] != grid[i][column])
        return false;
    }
    return true;
  }
}