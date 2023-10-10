using System;
using System.Linq;

namespace LeetCode._2009._Minimum_Number_of_Operations;

public class Solution
{
  public int MinOperations(int[] nums)
  {
    var items = nums.Distinct().OrderBy(x => x).ToArray();
    var n = nums.Length;
    var result = int.MaxValue;
    for (int l = 0, r = 0; l < items.Length; l++)
    {
      while (r < items.Length && items[r] - items[l] < n)
        r++;
      var unique = r - l;
      result = Math.Min(result, n - unique);
    }
    return result;
  }
}