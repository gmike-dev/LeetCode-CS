using System;

namespace LeetCode._518._Coin_Change_II;

public class Solution
{
  private int[][] _cache;

  public int Change(int amount, int[] coins)
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