using System;

namespace LeetCode._719._Find_K_th_Smallest_Pair_Distance;

public class BinarySearchSolution
{
  public int SmallestDistancePair(int[] nums, int k)
  {
    Array.Sort(nums);
    var n = nums.Length;
    var l = 0;
    var r = nums[^1] - nums[0];
    while (l < r)
    {
      var m = l + (r - l) / 2;
      var count = 0;
      for (int i = 0, j = 0; i < n; i++)
      {
        while (j < n && nums[j] - nums[i] <= m)
          j++;
        count += j - i - 1;
      }
      if (count < k)
        l = m + 1;
      else
        r = m;
    }
    return l;
  }
}