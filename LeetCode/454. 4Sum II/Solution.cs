using System.Collections.Generic;

namespace LeetCode._454._4Sum_II;

public class Solution
{
  public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
  {
    var cnt = new Dictionary<int, int>();
    foreach (var n1 in nums1)
    foreach (var n2 in nums2)
    {
      var s = n1 + n2;
      if (cnt.TryGetValue(s, out var count))
        cnt[s] = count + 1;
      else
        cnt[s] = 1;
    }
    var result = 0;
    foreach (var n3 in nums3)
    foreach (var n4 in nums4)
    {
      var s = n3 + n4;
      if (cnt.TryGetValue(-s, out var count))
        result += count;
    }
    return result;
  }
}