using System;
using System.Collections.Generic;

namespace LeetCode._128._Longest_Consecutive_Sequence;

public class Solution
{
  public int LongestConsecutive(int[] nums)
  {
    var hashSet = new HashSet<int>(nums);
    var maxLength = 0;
    foreach (var num in nums)
    {
      if (hashSet.Contains(num))
      {
        hashSet.Remove(num);
        var length = 1;
        for (var item = num + 1; hashSet.Contains(item); item++, length++)
          hashSet.Remove(item);
        for (var item = num - 1; hashSet.Contains(item); item--, length++)
          hashSet.Remove(item);
        maxLength = Math.Max(maxLength, length);
      }
    }
    return maxLength;
  }
}