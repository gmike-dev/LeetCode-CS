using System;

namespace LeetCode._2439._Minimize_Maximum_of_Array;

public class Solution
{
  public int MinimizeArrayValue(int[] nums)
  {
    var n = nums.Length;
    var s = 0L;
    var result = 0L;
    for (var i = 0; i < n; i++)
    {
      s += nums[i];
      result = Math.Max(result, (s + i) / (i + 1));
    }
    return (int)result;
  }
}