using System;
using System.Collections.Generic;

namespace LeetCode._128._Longest_Consecutive_Sequence;

public class ShortSolution
{
  public int LongestConsecutive(int[] nums)
  {
    var hashSet = new HashSet<int>(nums);
    var maxLength = 0;
    foreach (var num in nums)
    {
      if (hashSet.Contains(num - 1))
        continue;
      var length = 1;
      while (hashSet.Contains(num + length))
        length++;
      maxLength = Math.Max(maxLength, length);
    }
    return maxLength;
  }
}