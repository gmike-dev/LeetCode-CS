using System;
using System.Collections.Generic;

namespace LeetCode._664._Strange_Printer;

public class Solution
{
  private readonly Dictionary<long, int> _cache = new();

  public int StrangePrinter(string s)
  {
    return Print(s, 0, s.Length - 1);
  }

  private int Print(string s, int l, int r)
  {
    if (l > r)
      return 0;
    if (l == r)
      return 1;

    return Cached(l, r, () =>
    {
      var result = s[l] == s[r] ? Print(s, l + 1, r) : r - l + 1;
      for (var i = l; i < r; i++)
        result = Math.Min(result, Print(s, l, i) + Print(s, i + 1, r));
      return result;
    });
  }

  private int Cached(int l, int r, Func<int> f)
  {
    var cacheKey = ((long)l << 31) + r;
    if (_cache.TryGetValue(cacheKey, out var result))
      return result;
    result = f();
    _cache[cacheKey] = result;
    return result;
  }
}