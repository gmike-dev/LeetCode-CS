namespace LeetCode.__DP._1463._Cherry_Pickup_II;

public class Solution
{
  public int CherryPickup(int[][] grid)
  {
    var n = grid.Length;
    var m = grid[0].Length;
    var dp = new int[n][][];
    for (var i = 0; i < n; i++)
    {
      dp[i] = new int[m][];
      for (var j = 0; j < m; j++)
        dp[i][j] = new int[m];
    }
    for (var i = 0; i < m - 1; i++)
    {
      for (var j = i + 1; j < m; j++)
        dp[n - 1][i][j] = grid[n - 1][i] + grid[n - 1][j];
    }

    for (var row = n - 2; row >= 0; row--)
    {
      for (var i = 0; i < m - 1; i++)
      {
        for (var j = i + 1; j < m; j++)
        {
          dp[row][i][j] = grid[row][i] + grid[row][j];
          var max = 0;
          for (var d1 = -1; d1 <= 1; d1++)
          {
            for (var d2 = -1; d2 <= 1; d2++)
            {
              var c1 = i + d1;
              var c2 = j + d2;
              if (c1 < c2 && c1 >= 0 && c2 < m)
                max = Math.Max(max, dp[row + 1][c1][c2]);
            }
          }
          dp[row][i][j] += max;
        }
      }
    }
    return dp[0][0][m - 1];
  }
}

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().CherryPickup(new[]
    {
      new[] { 3, 1, 1 },
      new[] { 2, 5, 1 },
      new[] { 1, 5, 5 },
      new[] { 2, 1, 1 }
    }).Should().Be(24);
  }

  [Test]
  public void Test2()
  {
    new Solution().CherryPickup(new[]
    {
      new[] { 1, 0, 0, 0, 0, 0, 1 },
      new[] { 2, 0, 0, 0, 0, 3, 0 },
      new[] { 2, 0, 9, 0, 0, 0, 0 },
      new[] { 0, 3, 0, 5, 4, 0, 0 },
      new[] { 1, 0, 2, 3, 0, 0, 6 }
    }).Should().Be(28);
  }
}
