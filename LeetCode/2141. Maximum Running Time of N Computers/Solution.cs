namespace LeetCode._2141._Maximum_Running_Time_of_N_Computers;

public class Solution
{
  public long MaxRunTime(int n, int[] batteries)
  {
    Array.Sort(batteries, (x, y) => y.CompareTo(x));
    long s = 0;
    for (var i = n; i < batteries.Length; i++)
      s += batteries[i];
    long maxRuntime = batteries[n - 1];
    for (var i = n - 1; i > 0 && s > 0; i--)
    {
      var d = batteries[i - 1] - batteries[i];
      var ds = Math.Min(d * (n - i), s);
      maxRuntime += ds / (n - i);
      s -= ds;
    }
    if (s > 0)
      maxRuntime += s / n;

    return maxRuntime;
  }
}
