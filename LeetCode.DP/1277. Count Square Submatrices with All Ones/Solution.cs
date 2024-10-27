namespace LeetCode.DP._1277._Count_Square_Submatrices_with_All_Ones;

public class Solution
{
  public int CountSquares(int[][] matrix)
  {
    var n = matrix.Length;
    var m = matrix[0].Length;
    var dp = new int[n][];
    for (var i = 0; i < n; i++)
      dp[i] = new int[m];
    for (var i = 0; i < n; i++)
      dp[i][0] = matrix[i][0];
    for (var j = 0; j < m; j++)
      dp[0][j] = matrix[0][j];
    for (var i = 1; i < n; i++)
    {
      for (var j = 1; j < m; j++)
      {
        if (matrix[i][j] != 0)
          dp[i][j] = Math.Min(dp[i - 1][j - 1], Math.Min(dp[i][j - 1], dp[i - 1][j])) + 1;
      }
    }
    return dp.SelectMany(r => r).Sum();
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().CountSquares([
      [0, 1, 1, 1],
      [1, 1, 1, 1],
      [0, 1, 1, 1]
    ]).Should().Be(15);
  }

  [Test]
  public void Test2()
  {
    new Solution().CountSquares([
      [1, 0, 1],
      [1, 1, 0],
      [1, 1, 0]
    ]).Should().Be(7);
  }
}
