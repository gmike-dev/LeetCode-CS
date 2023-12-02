using System;
using System.Collections.Generic;

namespace LeetCode._78._Subsets;

public class RecursiveSolution
{
  public IList<IList<int>> Subsets(int[] nums)
  {
    Array.Sort(nums);
    var result = new List<IList<int>>();
    var temp = new List<int>();
    FillSubsets(nums, result, temp, 0);
    return result;
  }

  private static void FillSubsets(int[] nums, List<IList<int>> result, List<int> temp, int index)
  {
    result.Add(temp.ToArray());
    for (var i = index; i < nums.Length; i++)
    {
      temp.Add(nums[i]);
      FillSubsets(nums, result, temp, i + 1);
      temp.RemoveAt(temp.Count - 1);
    }
  }
}