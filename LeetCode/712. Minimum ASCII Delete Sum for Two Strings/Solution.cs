using System;
using System.Collections.Generic;

namespace LeetCode._712._Minimum_ASCII_Delete_Sum_for_Two_Strings;

public class Solution
{
  public int MinimumDeleteSum(string s1, string s2)
  {
    var n = s1.Length;
    var m = s2.Length;
    var dp = new int[n + 1, m + 1];
    for (var i = 1; i <= n; i++)
      dp[i, 0] = dp[i - 1, 0] + s1[i - 1];
    for (var j = 1; j <= m; j++)
      dp[0, j] = dp[0, j - 1] + s2[j - 1];
    for (var i = 1; i <= n; i++)
    for (var j = 1; j <= m; j++)
    {
      if (s1[i - 1] == s2[j - 1])
        dp[i, j] = dp[i - 1, j - 1];
      else
        dp[i, j] = Math.Min(s1[i - 1] + dp[i - 1, j], s2[j - 1] + dp[i, j - 1]);
    }
    return dp[n, m];
  }

  private readonly Dictionary<(int, int), int> _cache = new();

  public int MinimumDeleteSum_Recursion(string s1, string s2)
  {
    return Dp(s1, s2);
  }

  private int Dp(ReadOnlySpan<char> s1, ReadOnlySpan<char> s2)
  {
    if (s1.IsEmpty)
      return AsciiSum(s2);
    if (s2.IsEmpty)
      return AsciiSum(s1);

    var cacheKey = (s1.Length, s2.Length);
    if (_cache.TryGetValue(cacheKey, out var result))
      return result;

    if (s1[0] == s2[0])
      result = Dp(s1[1..], s2[1..]);
    else
      result = Math.Min(s1[0] + Dp(s1[1..], s2), s2[0] + Dp(s1, s2[1..]));

    _cache[cacheKey] = result;
    return result;
  }

  private static int AsciiSum(ReadOnlySpan<char> s)
  {
    var result = 0;
    foreach (var c in s)
      result += c;
    return result;
  }
}