using System.Collections.Generic;
using System.Linq;

namespace LeetCode._1424._Diagonal_Traverse_II;

public class SortingSolution
{
  public int[] FindDiagonalOrder(IList<IList<int>> nums)
  {
    var list = new List<(int d, int pos, int value)>();
    for (var i = 0; i < nums.Count; i++)
    for (var j = 0; j < nums[i].Count; j++)
      list.Add((i + j, -i, nums[i][j]));
    list.Sort();
    return list.Select(v => v.value).ToArray();
  }
}