namespace LeetCode.DP._808._Soup_Servings;

public class BottomUpSolution
{
  public double SoupServings(int n)
  {
    if (n > 4800)
      return 1.0;

    n = (n + 24) / 25;

    var dp = new double[n + 1, n + 1];
    for (var j = 1; j <= n; j++)
      dp[0, j] = 1.0;
    dp[0, 0] = 0.5;

    for (var i = 1; i <= n; i++)
    {
      for (var j = 1; j <= n; j++)
      {
        dp[i, j] = 0.25 * (dp[Math.Max(0, i - 4), j] +
                           dp[Math.Max(0, i - 3), j - 1] +
                           dp[Math.Max(0, i - 2), Math.Max(0, j - 2)] +
                           dp[i - 1, Math.Max(0, j - 3)]);
      }
    }
    return dp[n, n];
  }
}

[TestFixture]
public class BottomUpSolutionTests
{
  [TestCase(50, 0.625)]
  [TestCase(100, 0.71875)]
  public void Test(int n, double expected)
  {
    new BottomUpSolution().SoupServings(n).Should().Be(expected);
  }
}
