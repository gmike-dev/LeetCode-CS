using System;

namespace LeetCode._33._Search_in_Rotated_Sorted_Array;

public class Solution
{
  public int Search(int[] nums, int target)
  {
    return Search(nums, 0, nums.Length - 1, target);
  }

  private int Search(int[] nums, int l, int r, int target)
  {
    if (l > r)
      return -1;

    if (l == r)
      return nums[l] == target ? l : -1;

    int result;
    if (nums[l] >= nums[r])
    {
      var m = l + (r - l) / 2;
      result = Search(nums, l, m, target);
      if (result >= 0)
        return result;
      result = Search(nums, m + 1, r, target);
      return result >= 0 ? result : -1;
    }
    
    result = Array.BinarySearch(nums, l, r - l + 1, target);
    return result < 0 ? -1 : result;
  }
}