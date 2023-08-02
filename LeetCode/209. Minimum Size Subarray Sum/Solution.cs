using System;

namespace LeetCode._209._Minimum_Size_Subarray_Sum;

public class Solution
{
  public int MinSubArrayLen(int target, int[] nums)
  {
    var result = int.MaxValue;
    var n = nums.Length;
    for (int l = 0, r = 0, s = 0; l < n; s -= nums[l], l++)
    {
      while (r < n && s < target)
      {
        s += nums[r];
        r++;
      }
      if (s >= target)
      {
        result = Math.Min(result, r - l);
      }
      else if (r == n)
      {
        break;
      }
    }
    return result == int.MaxValue ? 0 : result;
  }
}