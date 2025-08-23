using LeetCode.Common;

namespace LeetCode._3197._Find_the_Minimum_Area_to_Cover_All_Ones_II;

public class Solution
{
  public int MinimumSum(int[][] grid)
  {
    var maxArea = int.MaxValue;
    maxArea = Math.Min(maxArea, SplitRow(grid));
    maxArea = Math.Min(maxArea, SplitRowCol(grid));
    grid = RotateCw(grid);
    maxArea = Math.Min(maxArea, SplitRowCol(grid));
    maxArea = Math.Min(maxArea, SplitRow(grid));
    grid = RotateCw(grid);
    maxArea = Math.Min(maxArea, SplitRowCol(grid));
    grid = RotateCw(grid);
    maxArea = Math.Min(maxArea, SplitRowCol(grid));
    return maxArea;
  }

  private int SplitRowCol(int[][] grid)
  {
    var n = grid.Length;
    var m = grid[0].Length;
    var result = int.MaxValue;
    for (var i = 1; i < n; i++)
    {
      var a1 = GetArea(grid, 0, i, 0, m);
      if (a1 == 0)
        continue;
      for (var j = 1; j < m; j++)
      {
        var a2 = GetArea(grid, i, n, 0, j);
        if (a2 == 0)
          continue;
        var a3 = GetArea(grid, i, n, j, m);
        if (a3 == 0)
          continue;
        result = Math.Min(result, a1 + a2 + a3);
      }
    }
    return result;
  }

  private static int SplitRow(int[][] grid)
  {
    var n = grid.Length;
    var m = grid[0].Length;
    var result = int.MaxValue;
    for (var i1 = 1; i1 < n - 1; i1++)
    {
      var a1 = GetArea(grid, 0, i1, 0, m);
      if (a1 == 0)
        continue;
      for (var i2 = i1 + 1; i2 < n; i2++)
      {
        var a2 = GetArea(grid, i1, i2, 0, m);
        if (a2 == 0)
          continue;
        var a3 = GetArea(grid, i2, n, 0, m);
        if (a3 == 0)
          continue;
        result = Math.Min(result, a1 + a2 + a3);
      }
    }
    return result;
  }

  private static int[][] RotateCw(int[][] grid)
  {
    var n = grid.Length;
    var m = grid[0].Length;
    var result = new int[m][];
    for (var i = 0; i < m; i++)
    {
      result[i] = new int[n];
    }
    for (var i = 0; i < n; i++)
    {
      for (var j = 0; j < m; j++)
        result[j][n - i - 1] = grid[i][j];
    }
    return result;
  }

  private static int GetArea(int[][] grid, int xMin, int xMax, int yMin, int yMax)
  {
    var x1 = xMax;
    var x2 = 0;
    var y1 = yMax;
    var y2 = 0;
    for (var i = xMin; i < xMax; i++)
    {
      for (var j = yMin; j < yMax; j++)
      {
        if (grid[i][j] != 0)
        {
          x1 = Math.Min(x1, i);
          x2 = Math.Max(x2, i);
          y1 = Math.Min(y1, j);
          y2 = Math.Max(y2, j);
        }
      }
    }
    if (x1 == xMax)
      return 0;
    return (x2 - x1 + 1) * (y2 - y1 + 1);
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("[[1,0,1],[1,1,1]]", 5)]
  [TestCase("[[1,0,1,0],[0,1,0,1]]", 5)]
  public void Test(string matrix, int expected)
  {
    new Solution().MinimumSum(matrix.Array2()).Should().Be(expected);
  }
}
