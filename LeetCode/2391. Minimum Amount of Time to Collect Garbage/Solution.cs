using System.Collections.Generic;

namespace LeetCode._2391._Minimum_Amount_of_Time_to_Collect_Garbage;

public class Solution
{
  public int GarbageCollection(string[] garbage, int[] travel)
  {
    var n = garbage.Length;
    var count = new Dictionary<char, int[]>
    {
      ['M'] = new int[n],
      ['P'] = new int[n],
      ['G'] = new int[n]
    };
    var last = new Dictionary<char, int>();
    for (var i = 0; i < n; i++)
    {
      for (var j = 0; j < garbage[i].Length; j++)
      {
        var g = garbage[i][j];
        count[g][i]++;
        last[g] = i;
      }
    }

    var total = 0;
    foreach (var g in "MPG")
    {
      if (last.TryGetValue(g, out var m))
      {
        var cnt = count[g];
        for (var i = 0; i < m; i++)
        {
          total += cnt[i];
          total += travel[i];
        }
        total += count[g][m];
      }
    }
    return total;
  }
}