using System;
using System.Collections.Generic;

namespace LeetCode._1851._Minimum_Interval_to_Include_Each_Query;

public class Solution
{
  public int[] MinInterval(int[][] intervals, int[] queries)
  {
    Array.Sort(intervals, (x, y) => x[0].CompareTo(y[0]));
    var queue = new PriorityQueue<int, int>();
    var m = queries.Length;
    var p = new int[m];
    for (var i = 0; i < m; i++)
      p[i] = i;
    var cmp = Comparer<int>.Create((q1, q2) => queries[q1].CompareTo(queries[q2]));
    Array.Sort(p, cmp);
    var j = 0;
    foreach (var qi in p)
    {
      var query = queries[qi];
      for (; j < intervals.Length && intervals[j][0] <= query; j++)
      {
        var i = intervals[j];
        queue.Enqueue(i[1], i[1] - i[0] + 1);
      }
      while (queue.TryPeek(out var right, out _) && right < query)
        queue.Dequeue();
      queries[qi] = queue.TryPeek(out _, out var length) ? length : -1;
    }
    return queries;
  }
}