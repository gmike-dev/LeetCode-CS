using System;
using System.Linq;

namespace LeetCode._646._Maximum_Length_of_Pair_Chain;

public class SolutionDpWithOn2
{
  public int FindLongestChain(int[][] pairs)
  {
    Array.Sort(pairs, (p1, p2) => p1[1].CompareTo(p2[1]));
    var n = pairs.Length;
    var d = new int[n];
    d[0] = 1;
    for (var i = 1; i < n; i++)
    {
      for (var j = 0; j < n; j++)
      {
        if (pairs[j][1] < pairs[i][0])
          d[i] = Math.Max(d[i], d[j] + 1);
      }
    }
    return d.Max();
  }
}