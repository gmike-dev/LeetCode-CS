namespace LeetCode.DP._3394._Check_if_Grid_can_be_Cut_into_Sections;

public class Solution
{
  public int CountPathsWithXorValue(int[][] grid, int k)
  {
    var n = grid.Length;
    var m = grid[0].Length;
    var dp = new int[n, m, 16];
    dp[0, 0, grid[0][0]] = 1;
    var xor = grid[0][0];
    for (var j = 1; j < m; j++)
      dp[0, j, xor ^= grid[0][j]] = 1;
    xor = grid[0][0];
    for (var i = 1; i < n; i++)
      dp[i, 0, xor ^= grid[i][0]] = 1;
    const int mod = (int)1e9 + 7;
    for (var i = 1; i < n; i++)
    {
      for (var j = 1; j < m; j++)
      {
        for (var x = 0; x < 16; x++)
        {
          dp[i, j, x] = (dp[i - 1, j, x ^ grid[i][j]] +
                         dp[i, j - 1, x ^ grid[i][j]]) % mod;
        }
      }
    }
    return dp[n - 1, m - 1, k];
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().CountPathsWithXorValue([
      [2, 1, 5],
      [7, 10, 0],
      [12, 6, 4]
    ], 11).Should().Be(3);
  }

  [Test]
  public void Test2()
  {
    new Solution().CountPathsWithXorValue([
      [1, 3, 3, 3],
      [0, 3, 3, 2],
      [3, 0, 1, 1]
    ], 2).Should().Be(5);
  }
}
