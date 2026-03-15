namespace LeetCode.DP._97._Interleaving_String;

/// <summary>
/// https://leetcode.com/problems/interleaving-string/
/// </summary>
public class Solution
{
  public bool IsInterleave(string s1, string s2, string s3)
  {
    int m = s1.Length;
    int n = s2.Length;
    if (m + n != s3.Length)
      return false;
    var dp = new bool[n + 1];
    dp[0] = true;
    for (var i = 0; i < n && s2[i] == s3[i]; i++)
      dp[i + 1] = true;
    for (var i = 0; i < m; i++)
    {
      dp[0] = dp[0] && s1[i] == s3[i];
      for (var j = 0; j < n; j++)
      {
        dp[j + 1] = dp[j + 1] && s1[i] == s3[i + j + 1] ||
                    dp[j] && s2[j] == s3[i + j + 1];
      }
    }
    return dp[n];
  }
}

[TestFixture]
public class SolutionTests
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
    new Solution().IsInterleave(s1, s2, s3).Should().Be(expected);
  }
}
