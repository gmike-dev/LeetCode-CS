using System;

namespace LeetCode._2616._Minimize_the_Maximum_Difference_of_Pairs;

public class Solution
{
  public int MinimizeMax(int[] nums, int p)
  {
    Array.Sort(nums);

    var l = 0;
    var r = nums[^1] - nums[0];
    while (l < r)
    {
      var m = l + (r - l) / 2;
      if (CanTakePairs(nums, p, m))
        r = m;
      else
        l = m + 1;
    }
    return l;
  }

  private static bool CanTakePairs(int[] nums, int p, int d)
  {
    for (var i = 0; i < nums.Length - 1 && p > 0; i++)
    {
      if (nums[i + 1] - nums[i] <= d)
      {
        p--;
        i++;
      }
    }
    return p == 0;
  }
}