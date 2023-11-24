using System;
using System.Collections.Generic;

namespace LeetCode._1630._Arithmetic_Subarrays;

public class Solution
{
  public IList<bool> CheckArithmeticSubarrays(int[] nums, int[] l, int[] r)
  {
    var m = l.Length;
    var ans = new bool[m];
    for (var i = 0; i < m; i++)
      ans[i] = CanBeArithmetic(nums[l[i]..(r[i] + 1)]);
    return ans;
  }

  private static bool CanBeArithmetic(int[] a)
  {
    Array.Sort(a);
    for (var j = 1; j < a.Length - 1; j++)
    {
      if (a[j + 1] - a[j] != a[1] - a[0])
        return false;
    }
    return true;
  }
}