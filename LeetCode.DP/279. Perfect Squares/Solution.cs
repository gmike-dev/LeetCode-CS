namespace LeetCode.DP._279._Perfect_Squares;

public class Solution
{
  public int NumSquares(int n)
  {
    var dp = new int[n + 1];
    Array.Fill(dp, int.MaxValue);
    dp[0] = 0;
    for (var i = 1; i <= n; i++)
    {
      for (var j = 1; i - j * j >= 0; j++)
      {
        dp[i] = Math.Min(dp[i], dp[i - j * j] + 1);
      }
    }
    return dp[n];
  }
}

[TestFixture]
public class Tests
{
  [TestCase(12, 3)]
  [TestCase(13, 2)]
  [TestCase(1024, 1)]
  [TestCase(1025, 2)]
  [TestCase(10000, 1)]
  [TestCase(999, 4)]
  public void Test(int n, int expected)
  {
    new Solution().NumSquares(n).Should().Be(expected);
  }
}
