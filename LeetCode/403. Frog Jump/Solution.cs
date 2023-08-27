using System;
using System.Collections.Generic;

namespace LeetCode._403._Frog_Jump;

public class Solution
{
  private readonly HashSet<(int length, int k)> _cache = new();
  
  public bool CanCross(int[] stones)
  {
    return stones[1] - stones[0] == 1 && Jump(stones.AsSpan(1), 1);
  }

  private bool Jump(Span<int> stones, int prevK)
  {
    if (stones.Length == 1)
      return true;

    var key = (stones.Length, prevK);
    if (_cache.Contains(key))
      return false;

    for (var k = Math.Max(prevK - 1, 1); k <= prevK + 1; k++)
    {
      var next = stones.BinarySearch(stones[0] + k);
      if (next > 0 && Jump(stones[next..], k))
        return true;
    }

    _cache.Add(key);
    return false;
  }
}