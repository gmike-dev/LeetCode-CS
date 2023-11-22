using System;
using System.Collections.Generic;

namespace LeetCode._1424._Diagonal_Traverse_II;

public class GroupingSolution
{
  public int[] FindDiagonalOrder(IList<IList<int>> nums)
  {
    var m = nums.Count;
    var n = 0;
    var count = 0;
    foreach (var row in nums)
    {
      n = Math.Max(n, row.Count);
      count += row.Count;
    }
    var diagonal = new List<int>[m + n];
    for (var i = 0; i < diagonal.Length; i++)
      diagonal[i] = new List<int>();
    for (var i = 0; i < nums.Count; i++)
    for (var j = 0; j < nums[i].Count; j++)
      diagonal[i + j].Add(nums[i][j]);
    var result = new int[count];
    var pos = 0;
    foreach (var d in diagonal)
      for (var j = d.Count - 1; j >= 0; j--)
        result[pos++] = d[j];
    return result;
  }
}