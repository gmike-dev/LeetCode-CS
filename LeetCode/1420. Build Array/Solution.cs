namespace LeetCode._1420._Build_Array;

public class Solution
{
  public int NumOfArrays(int n, int m, int k)
  {
    const int mod = (int)1e9 + 7;
    var dp = new int[n + 1, m + 1, k + 1];
    for (var i = 1; i <= m; i++)
      dp[1, i, 1] = 1;
    for (var len = 1; len <= n; len++)
    for (var max = 1; max <= m; max++)
    for (var cost = 1; cost <= k; cost++)
    {
      var s = (long)dp[len - 1, max, cost] * max % mod;
      for (var i = 1; i < max; i++)
        s = (s + dp[len - 1, i, cost - 1]) % mod;
      dp[len, max, cost] = (int)((dp[len, max, cost] + s) % mod);
    }
    var ans = 0L;
    for (var i = 1; i <= m; i++)
      ans = (ans + dp[n, i, k]) % mod;
    return (int)ans;
  }
}