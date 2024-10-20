namespace LeetCode.DP._712._Minimum_ASCII_Delete_Sum_for_Two_Strings;

public class DpSolution
{
  public int MinimumDeleteSum(string s1, string s2)
  {
    var n = s1.Length;
    var m = s2.Length;
    var dp = new int[n + 1, m + 1];
    for (var i = 1; i <= n; i++)
      dp[i, 0] = dp[i - 1, 0] + s1[i - 1];
    for (var j = 1; j <= m; j++)
      dp[0, j] = dp[0, j - 1] + s2[j - 1];
    for (var i = 1; i <= n; i++)
    for (var j = 1; j <= m; j++)
    {
      if (s1[i - 1] == s2[j - 1])
        dp[i, j] = dp[i - 1, j - 1];
      else
        dp[i, j] = Math.Min(s1[i - 1] + dp[i - 1, j], s2[j - 1] + dp[i, j - 1]);
    }
    return dp[n, m];
  }
}

[TestFixture]
public class DpSolutionTests
{
  [TestCase("sea", "eat", 231)]
  [TestCase("delete", "leet", 403)]
  public void Test1(string s1, string s2, int expected)
  {
    new DpSolution().MinimumDeleteSum(s1, s2).Should().Be(expected);
  }
}
