namespace LeetCode.DP._97._Interleaving_String;

/// <summary>
/// https://leetcode.com/problems/interleaving-string/
/// </summary>
public class SolutionUsingMemoization
{
  public bool IsInterleave(string s1, string s2, string s3)
  {
    int n = s1.Length;
    int m = s2.Length;
    int k = s3.Length;
    if (n + m != k)
    {
      return false;
    }
    int[,] dp = new int[n + 1, m + 1];
    return F(0, 0);

    bool F(int i, int j)
    {
      if (i + j == k)
      {
        return true;
      }
      if (dp[i, j] != 0)
      {
        return dp[i, j] == 1;
      }
      bool result = i < n && s1[i] == s3[i + j] && F(i + 1, j) ||
                    j < m && s2[j] == s3[i + j] && F(i, j + 1);
      dp[i, j] = result ? 1 : 2;
      return result;
    }
  }
}

[TestFixture]
public class SolutionUsingMemoizationTests
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
    new SolutionUsingMemoization().IsInterleave(s1, s2, s3).Should().Be(expected);
  }
}
