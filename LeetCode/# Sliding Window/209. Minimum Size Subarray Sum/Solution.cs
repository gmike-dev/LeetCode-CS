using System;

namespace LeetCode.__Sliding_Window._209._Minimum_Size_Subarray_Sum;

public class Solution
{
  public int MinSubArrayLen(int target, int[] nums)
  {
    var result = int.MaxValue;
    var n = nums.Length;
    var l = 0;
    var s = 0;
    for (var r = 0; r < n; r++)
    {
      s += nums[r];
      while (s >= target)
      {
        result = Math.Min(result, r - l + 1);
        s -= nums[l++];
      }
    }
    return result == int.MaxValue ? 0 : result;
  }
}
