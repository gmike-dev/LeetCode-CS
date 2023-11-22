using System.Collections.Generic;
using System.Linq;

namespace LeetCode._1424._Diagonal_Traverse_II;

public class SortingSolution
{
  public int[] FindDiagonalOrder(IList<IList<int>> nums)
  {
    var items = new List<(int diagonal, int row, int value)>();
    for (var i = 0; i < nums.Count; i++)
    for (var j = 0; j < nums[i].Count; j++)
      items.Add((i + j, -i, nums[i][j]));
    items.Sort();
    return items.Select(item => item.value).ToArray();
  }
}