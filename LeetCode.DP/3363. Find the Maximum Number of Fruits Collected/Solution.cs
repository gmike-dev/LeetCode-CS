using LeetCode.Common;

namespace LeetCode.DP._3363._Find_the_Maximum_Number_of_Fruits_Collected;

public class Solution
{
  public int MaxCollectedFruits(int[][] fruits)
  {
    var n = fruits.Length;
    var dp = new int[n, n];
    dp[0, 0] = fruits[0][0];
    dp[0, n - 1] = fruits[0][n - 1];
    dp[n - 1, 0] = fruits[n - 1][0];
    for (var i = 1; i < n - 1; i++)
    {
      for (var j = Math.Max(i + 1, n - i - 1); j < n; j++)
      {
        var d = 0;
        if (j > n - i - 1)
          d = Math.Max(d, dp[i - 1, j]);
        if (j + 1 < n)
          d = Math.Max(d, dp[i - 1, j + 1]);
        if (j > i)
          d = Math.Max(d, dp[i - 1, j - 1]);
        dp[i, j] = fruits[i][j] + d;
      }
    }
    for (var j = 1; j < n - 1; j++)
    {
      for (var i = Math.Max(j + 1, n - j - 1); i < n; i++)
      {
        var d = 0;
        if (i > n - j - 1)
          d = Math.Max(d, dp[i, j - 1]);
        if (i + 1 < n)
          d = Math.Max(d, dp[i + 1, j - 1]);
        if (i > j)
          d = Math.Max(d, dp[i - 1, j - 1]);
        dp[i, j] = fruits[i][j] + d;
      }
    }
    for (var i = 1; i < n; i++)
      dp[i, i] = fruits[i][i] + dp[i - 1, i - 1];
    return dp[n - 2, n - 1] + dp[n - 1, n - 2] + dp[n - 1, n - 1];
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("[[1,2,3,4],[5,6,8,7],[9,10,11,12],[13,14,15,16]]", 100)]
  [TestCase("[[1,1],[1,1]]", 4)]
  public void Test(string fruits, int expected)
  {
    new Solution().MaxCollectedFruits(fruits.Array2()).Should().Be(expected);
  }
}
