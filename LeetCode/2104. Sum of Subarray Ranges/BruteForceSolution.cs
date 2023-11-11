using System;

namespace LeetCode._2104._Sum_of_Subarray_Ranges;

public class BruteForceSolution
{
  public long SubArrayRanges(int[] nums)
  {
    var n = nums.Length;
    var s = 0L;
    for (var i = 0; i < n - 1; i++)
    {
      var min = nums[i];
      var max = nums[i];
      for (var j = i + 1; j < n; j++)
      {
        min = Math.Min(nums[j], min);
        max = Math.Max(nums[j], max);
        s += max - min;
      }
    }
    return s;
  }
}