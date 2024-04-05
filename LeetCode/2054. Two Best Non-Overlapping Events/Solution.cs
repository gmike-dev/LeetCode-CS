namespace LeetCode._2054._Two_Best_Non_Overlapping_Events;

public class Solution
{
  public int MaxTwoEvents(int[][] events)
  {
    var n = events.Length;
    Array.Sort(events, ByEndTime);

    var maxValue = new int[n];
    maxValue[0] = events[0][2];
    for (var i = 1; i < n; i++)
      maxValue[i] = Math.Max(events[i][2], maxValue[i - 1]);

    var result = maxValue[0];
    for (var i = 1; i < n; i++)
    {
      var value = events[i][2];
      var prev = FindLastEvent(i);
      if (prev >= 0)
        value += maxValue[prev];
      result = Math.Max(result, value);
    }
    return result;

    int ByEndTime(int[] x, int[] y)
    {
      return x[1] - y[1];
    }

    int FindLastEvent(int i)
    {
      var l = 0;
      var r = i - 1;
      var start = events[i][0];
      while (l <= r)
      {
        var m = l + (r - l) / 2;
        if (events[m][1] < start)
          l = m + 1;
        else
          r = m - 1;
      }
      return r;
    }
  }
}
