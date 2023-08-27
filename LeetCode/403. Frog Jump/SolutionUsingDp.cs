using System;
using System.Collections.Generic;

namespace LeetCode._403._Frog_Jump;

public class SolutionUsingDp
{
  public bool CanCross(int[] stones)
  {
    if (stones[1] - stones[0] != 1)
      return false;
    var n = stones.Length;
    var dp = new HashSet<int>[n];
    dp[1] = new HashSet<int> { 1 };
    for (var i = 1; i < n; i++)
    {
      if (dp[i] == null)
        continue;
      foreach (var prevK in dp[i])
      {
        for (var k = Math.Max(prevK - 1, 1); k <= prevK + 1; k++)
        {
          var to = Array.BinarySearch(stones, i + 1, n - i - 1, stones[i] + k);
          if (to > 0)
            (dp[to] ??= new HashSet<int>()).Add(k);
        }
      }
    }
    return dp[n - 1] != null;
  }
}