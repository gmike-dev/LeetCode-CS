using System;

namespace LeetCode._33._Search_in_Rotated_Sorted_Array;

public class Solution
{
  /// <summary>
  /// https://leetcode.com/problems/search-in-rotated-sorted-array
  /// </summary>
  /// <param name="nums">An integer array sorted in ascending order (with distinct values).</param>
  public int Search(int[] nums, int target)
  {
    var l = 0;
    var n = nums.Length;
    var r = n - 1;
    while (l <= r)
    {
      var m = l + (r - l) / 2;
      if (nums[m] > nums[^1])
        l = m + 1;
      else
        r = m - 1;
    }

    var pivot = l;
    var result = pivot > 0 && target >= nums[0] ? 
      Array.BinarySearch(nums, 0, pivot, target) : 
      Array.BinarySearch(nums, pivot, n - pivot, target);
    return result >= 0 ? result : -1;
  }
}