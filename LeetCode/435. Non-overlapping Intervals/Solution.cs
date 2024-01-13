using System;

namespace LeetCode.NonOverlappingIntervals;

public class Solution
{
  public int EraseOverlapIntervals(int[][] intervals)
  {
    Array.Sort(intervals, (s1, s2) => s1[1].CompareTo(s2[1]));

    var result = 0;
    for (int i = 0, j = 1; j < intervals.Length; j++)
    {
      var r1 = intervals[i][1];
      var l2 = intervals[j][0];
      if (l2 < r1)
      {
        result++;
      }
      else
      {
        i = j;
      }
    }
    return result;
  }
}