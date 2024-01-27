using System;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.__DP._629._K_Inverse_Pairs_Array;

public class Solution
{
  public int KInversePairs(int n, int k)
  {
    if (k == 0)
      return 1; // [1, 2, ..., n - 1, n].
    var maxPairs = n * (n - 1) / 2;
    if (k > maxPairs)
      return 0;
    if (k == maxPairs)
      return 1; // [n, n - 1, ..., 1].

    const int mod = (int)1e9 + 7;
    var dp = new int[n + 1][];
    for (var i = 0; i < dp.Length; i++)
      dp[i] = new int[k + 1];
    dp[2][0] = 1;
    dp[2][1] = 1;
    for (var i = 3; i <= n; i++)
    {
      for (var j = 1; j <= Math.Min(i - 1, k); j++)
        dp[i][j] = dp[i][j] + dp[i - 1][k - j];
    }
    return dp[n][k];
  }
}

[TestFixture]
public class Tests
{
  [TestCase(3, 0, 1)]
  [TestCase(3, 1, 2)]
  public void Test(int n, int k, int expected)
  {
    new Solution().KInversePairs(n, k).Should().Be(expected);
  }
}