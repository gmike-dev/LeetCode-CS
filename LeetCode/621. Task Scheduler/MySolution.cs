namespace LeetCode._621._Task_Scheduler;

public class MySolution
{
  public int LeastInterval(char[] tasks, int n)
  {
    var cnt = new int[128];
    foreach (var t in tasks)
      cnt[t]++;
    var next = new int[128];
    var m = tasks.Length;
    var i = 0;
    for (; m > 0; i++)
    {
      var max = 0;
      for (var t = 'A'; t <= 'Z'; t++)
      {
        if (cnt[max] < cnt[t] && next[t] <= i)
          max = t;
      }
      if (max != 0)
      {
        cnt[max]--;
        m--;
        next[max] = i + n + 1;
      }
    }
    return i;
  }
}
