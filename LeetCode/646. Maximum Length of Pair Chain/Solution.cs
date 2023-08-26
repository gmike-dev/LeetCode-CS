using System;

namespace LeetCode._646._Maximum_Length_of_Pair_Chain;

public class Solution
{
  public int FindLongestChain(int[][] pairs)
  {
    pairs.AsSpan().Sort((p1, p2) => p1[1].CompareTo(p2[1]));
    var len = 0;
    var right = int.MinValue;
    foreach (var p in pairs)
    {
      if (right < p[0])
      {
        len++;
        right = p[1];
      }
    }
    return len;
  }
}