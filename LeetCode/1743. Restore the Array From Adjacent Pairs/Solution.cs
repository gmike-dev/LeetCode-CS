using System.Collections.Generic;
using System.Linq;

namespace LeetCode._1743._Restore_the_Array_From_Adjacent_Pairs;

public class Solution
{
  public int[] RestoreArray(int[][] adjacentPairs)
  {
    var n = adjacentPairs.Length;
    var h = new Dictionary<int, List<int>>();
    for (var i = 1; i < n; i++)
    {
      var p = adjacentPairs[i];
      if (h.TryGetValue(p[0], out var adj))
        adj.Add(p[1]);
      else
        h.Add(p[0], new List<int> { p[1] });
      if (h.TryGetValue(p[1], out adj))
        adj.Add(p[0]);
      else
        h.Add(p[1], new List<int> { p[0] });
    }
    var list = new LinkedList<int>(adjacentPairs[0]);
    while (h.TryGetValue(list.Last.Value, out var neighbours) && neighbours.Count > 0)
    {
      var item = list.Last.Value;
      var paired = neighbours[^1];
      list.AddLast(paired);
      neighbours.Remove(paired);
      h[paired].Remove(item);
    }
    while (h.TryGetValue(list.First.Value, out var neighbours) && neighbours.Count > 0)
    {
      var item = list.First.Value;
      var paired = neighbours[^1];
      list.AddFirst(paired);
      neighbours.Remove(paired);
      h[paired].Remove(item);
    }
    return list.ToArray();
  }
}