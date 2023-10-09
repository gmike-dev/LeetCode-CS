namespace LeetCode._34._Find_First_and_Last_Position;

public class Solution
{
  public int[] SearchRange(int[] nums, int target)
  {
    var lb = LowerBound(nums, 0, nums.Length, target);
    if (lb == nums.Length || nums[lb] != target)
      return new[] { -1, -1 };
    var ub = UpperBound(nums, lb, nums.Length, target);
    return new[] { lb, ub - 1 };
  }

  private static int LowerBound(int[] a, int beginIndex, int endIndex, int value)
  {
    if (beginIndex >= endIndex)
      return endIndex;
    var l = beginIndex;
    var r = endIndex - 1;
    while (l < r)
    {
      var m = l + (r - l) / 2;
      if (a[m] < value)
        l = m + 1;
      else
        r = m;
    }
    return a[l] < value ? endIndex : l;
  }

  private static int UpperBound(int[] a, int beginIndex, int endIndex, int value)
  {
    if (beginIndex >= endIndex)
      return endIndex;
    var l = beginIndex;
    var r = endIndex - 1;
    while (l < r)
    {
      var m = l + (r - l) / 2;
      if (a[m] <= value)
        l = m + 1;
      else
        r = m;
    }
    return a[l] <= value ? endIndex : l;
  }
}