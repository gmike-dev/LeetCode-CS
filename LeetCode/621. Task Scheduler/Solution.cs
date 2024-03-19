using System;
using System.Linq;

namespace LeetCode._621._Task_Scheduler;

public class Solution
{
  public int LeastInterval(char[] tasks, int n)
  {
    var count = new int['Z' - 'A' + 1];
    foreach (var t in tasks)
      count[t - 'A']++;
    var maxCount = count.Max();
    var maxFreq = count.Count(c => c == maxCount);
    return Math.Max(tasks.Length, (maxCount - 1) * (n + 1) + maxFreq);
  }
}
