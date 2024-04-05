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
    dp[0][0] = 1;
    for (var N = 1; N <= n; N++)
    for (var K = 0; K <= k; K++)
    for (var i = 0; i <= Math.Min(K, N - 1); i++)
      dp[N][K] = (dp[N][K] + dp[N - 1][K - i]) % mod;
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
