using System;

namespace LeetCode._1846._Maximum_Element_After_Decreasing;

public class SortSolution
{
  public int MaximumElementAfterDecrementingAndRearranging(int[] arr)
  {
    Array.Sort(arr);
    var max = 0;
    foreach (var x in arr)
      max = Math.Min(x, max + 1);
    return max;
  }
}