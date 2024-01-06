using System;

namespace LeetCode._1235._Maximum_Profit_in_Job_Scheduling;

public class Solution
{
  public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
  {
    var n = startTime.Length;
    var jobs = new (int StartTime, int EndTime, int Profit)[n];
    for (var i = 0; i < n; i++)
      jobs[i] = (startTime[i], endTime[i], profit[i]);
    Array.Sort(jobs);
    var maxProfit = new int[n];
    maxProfit[n - 1] = jobs[n - 1].Profit;
    for (var i = n - 2; i >= 0; i--)
    {
      var p = jobs[i].Profit;
      var next = FindNextJob(i);
      if (next < n)
        p += maxProfit[next];
      maxProfit[i] = Math.Max(p, maxProfit[i + 1]);
    }
    return maxProfit[0];

    int FindNextJob(int i)
    {
      var l = i + 1;
      var r = n - 1;
      var nextStartTime = jobs[i].EndTime;
      while (l <= r)
      {
        var m = l + (r - l) / 2;
        if (jobs[m].StartTime < nextStartTime)
          l = m + 1;
        else
          r = m - 1;
      }
      return l;
    }
  }
}