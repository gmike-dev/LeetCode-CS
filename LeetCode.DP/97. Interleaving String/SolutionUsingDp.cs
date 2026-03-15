namespace LeetCode.DP._97._Interleaving_String;

/// <summary>
/// https://leetcode.com/problems/interleaving-string/
/// </summary>
public class SolutionUsingDp
{
  public bool IsInterleave(string s1, string s2, string s3)
  {
    int m = s1.Length;
    int n = s2.Length;
    if (m + n != s3.Length)
      return false;
    bool[,] dp = new bool[m + 1, n + 1];
    dp[0, 0] = true;
    for (int i = 0; i < m && s1[i] == s3[i]; i++)
      dp[i + 1, 0] = true;
    for (int i = 0; i < n && s2[i] == s3[i]; i++)
      dp[0, i + 1] = true;
    for (int i = 0; i < m; i++)
    {
      for (int j = 0; j < n; j++)
      {
        dp[i + 1, j + 1] = dp[i, j + 1] && s1[i] == s3[i + j + 1] ||
                           dp[i + 1, j] && s2[j] == s3[i + j + 1];
      }
    }
    return dp[m, n];
  }
}

[TestFixture]
public class SolutionUsingDpTests
{
  [TestCase("aabcc", "dbbca", "aadbbcbcac", true)]
  [TestCase("aabcc", "dbbca", "aadbbbaccc", false)]
  [TestCase("", "", "", true)]
  [TestCase("aabcc", "dbbca", "aadbbcbacc", true)]
  [TestCase("abababababababababababababababababababababababababababababababababababababababababababababababababbb",
    "babababababababababababababababababababababababababababababababababababababababababababababababaaaba",
    "abababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababbb",
    false)]
  public void Test(string s1, string s2, string s3, bool expected)
  {
    new SolutionUsingDp().IsInterleave(s1, s2, s3).Should().Be(expected);
  }
}
