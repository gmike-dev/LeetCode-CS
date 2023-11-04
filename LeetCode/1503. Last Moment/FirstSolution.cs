using System;
using System.Collections.Generic;

namespace LeetCode._1503._Last_Moment;

public class FirstSolution
{
  public int GetLastMoment(int n, int[] left, int[] right)
  {
    var ants = new List<(int pos, bool left)>();
    foreach (var pos in left)
      ants.Add((pos, true));
    foreach (var pos in right)
      ants.Add((pos, false));
    ants.Sort();
    var l = 0;
    while (l < ants.Count && ants[l].left)
      l++;
    if (l == ants.Count)
      return ants[l - 1].pos;
    var r = ants.Count - 1;
    while (r >= 0 && !ants[r].left)
      r--;
    if (r < 0)
      return n - ants[0].pos;
    var d = ants[r].pos - ants[l].pos;
    return Math.Max(ants[l].pos, n - ants[r].pos) + d;
  }
}