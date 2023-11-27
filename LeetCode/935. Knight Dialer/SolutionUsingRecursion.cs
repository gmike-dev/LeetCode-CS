using System;
using System.Collections.Generic;

namespace LeetCode._935._Knight_Dialer;

public class SolutionUsingRecursion
{
  private readonly Dictionary<int, int[]> next = new()
  {
    [0] = new[] { 4, 6 },
    [1] = new[] { 6, 8 },
    [2] = new[] { 7, 9 },
    [3] = new[] { 4, 8 },
    [4] = new[] { 0, 3, 9 },
    [5] = Array.Empty<int>(),
    [6] = new[] { 0, 1, 7 },
    [7] = new[] { 2, 6 },
    [8] = new[] { 1, 3 },
    [9] = new[] { 2, 4 }
  };

  private const int Mod = (int)1e9 + 7;
  private readonly Dictionary<(int, int), int> cache = new();

  public int KnightDialer(int n)
  {
    var result = 0;
    for (var digit = 0; digit <= 9; digit++)
    {
      result = (result + Dp(n, digit)) % Mod;
    }
    return result;
  }

  private int Dp(int n, int digit)
  {
    if (n == 1)
      return 1;

    var key = (n, digit);
    if (cache.TryGetValue(key, out var result))
      return result;

    foreach (var nextDigit in next[digit])
      result = (result + Dp(n - 1, nextDigit)) % Mod;

    cache[key] = result;
    return result;
  }
}