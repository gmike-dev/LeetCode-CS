using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode._2009._Minimum_Number_of_Operations;

public class Solution
{
  public int MinOperations(int[] nums)
  {
    var items = new SortedSet<int>(nums).ToArray();
    var n = nums.Length;
    var result = int.MaxValue;
    for (int l = 0; l < items.Length; l++)
    {
      var r = Array.BinarySearch(items, items[l] + n - 1);
      if (r < 0)
        r = ~r - 1;
      var unique = r - l + 1;
      result = Math.Min(result, n - unique);
    }
    return result;
  }
}