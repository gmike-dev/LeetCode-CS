namespace LeetCode._81._Search_in_Rotated_Sorted_Array_II;

public class Solution
{
  /// <summary>
  /// https://leetcode.com/problems/search-in-rotated-sorted-array-ii
  /// </summary>
  /// <param name="nums">Integer array sorted in non-decreasing order (not necessarily with distinct values).</param>
  public bool Search(int[] nums, int target)
  {
    return Search(nums, 0, nums.Length - 1, target);
  }

  private bool Search(int[] nums, int l, int r, int target)
  {
    if (l > r)
      return false;

    if (l == r)
      return nums[l] == target;

    if (nums[l] >= nums[r])
    {
      var m = l + (r - l) / 2;
      return Search(nums, l, m, target) || Search(nums, m + 1, r, target);
    }

    return Array.BinarySearch(nums, l, r - l + 1, target) >= 0;
  }
}
