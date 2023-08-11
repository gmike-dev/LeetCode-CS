using System;

namespace LeetCode._518._Coin_Change_II;

public class Solution
{
  public int Change(int amount, int[] coins)
  {
    var n = coins.Length;

    var prev = new int[amount + 1];
    var curr = new int[amount + 1];

    for (var s = 0; s <= amount; s += coins[0])
      prev[s] = 1;

    for (var i = 1; i < n; i++)
    {
      for (var s = 0; s <= amount; s++)
      {
        if (s >= coins[i])
          curr[s] = prev[s] + curr[s - coins[i]];
        else
          curr[s] = prev[s];
      }
      (curr, prev) = (prev, curr);
    }
    return prev[amount];
  }
  
  public int Change_Dp(int amount, int[] coins)
  {
    var n = coins.Length;

    var dp = new int[amount + 1][];
    for (var i = 0; i < dp.Length; i++)
      dp[i] = new int[n + 1];

    for (var s = 0; s <= amount; s += coins[0])
      dp[s][0] = 1;

    for (var i = 1; i < n; i++)
    {
      for (var s = 0; s <= amount; s++)
      {
        if (s >= coins[i])
          dp[s][i] = dp[s][i - 1] + dp[s - coins[i]][i];
        else
          dp[s][i] = dp[s][i - 1];
      }
    }
    return dp[amount][n - 1];
  }
  
  private int[][] _cache;

  public int Change_Memoization(int amount, int[] coins)
  {
    _cache = new int[amount + 1][];
    for (var i = 0; i < _cache.Length; i++)
    {
      _cache[i] = new int[coins.Length + 1];
      _cache[i].AsSpan().Fill(-1);
    }
    return Combinations(amount, coins);
  }

  private int Combinations(int amount, Span<int> coins)
  {
    if (coins.Length == 1)
      return amount % coins[0] == 0 ? 1 : 0;

    if (_cache[amount][coins.Length] != -1)
      return _cache[amount][coins.Length];

    var result = 0;
    for (var i = 0; i <= amount; i += coins[0])
      result += Combinations(amount - i, coins[1..]);

    _cache[amount][coins.Length] = result;
    return result;
  }
}