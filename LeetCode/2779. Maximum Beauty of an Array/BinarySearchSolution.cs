using System;

namespace LeetCode._2779._Maximum_Beauty_of_an_Array;

public class BinarySearchSolution
{
  public int MaximumBeauty(int[] nums, int k)
  {
    Array.Sort(nums);
    var maxBeauty = 1;
    for (var i = 0; i < nums.Length - 1; i++)
    {
      var upperBound = UpperBound(nums, i, nums.Length, nums[i] + 2 * k);
      maxBeauty = Math.Max(maxBeauty, upperBound - i);
    }
    return maxBeauty;
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