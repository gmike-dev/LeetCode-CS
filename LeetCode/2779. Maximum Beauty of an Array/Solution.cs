using System;

namespace LeetCode._2779._Maximum_Beauty_of_an_Array;

public class Solution
{
  public int MaximumBeauty(int[] nums, int k)
  {
    Array.Sort(nums);
    var maxBeauty = 1;
    var right = 0;
    for (var i = 0; i < nums.Length - maxBeauty; i++)
    {
      var target = nums[i] + 2 * k;
      while (right < nums.Length && nums[right] <= target)
        right++;
      maxBeauty = Math.Max(maxBeauty, right - i);
    }
    return maxBeauty;
  }
}