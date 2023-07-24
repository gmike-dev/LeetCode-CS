using System.Collections.Generic;
using System.Linq;

namespace LeetCode._1218._Longest_Arithmetic_Subsequence_of_Given_Difference;

public class Solution
{
  public int LongestSubsequence(int[] arr, int difference)
  {
    var d = new Dictionary<int, int>();
    foreach (var x in arr)
    {
      var prev = x - difference;
      if (d.TryGetValue(prev, out var prevLength))
        d[x] = prevLength + 1;
      else
        d[x] = 1;
    }
    return d.Values.Max();
  }
}