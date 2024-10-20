namespace LeetCode.Graphs._2050._Parallel_Courses_III;

public class DfsSolution
{
  public int MinimumTime(int n, int[][] relations, int[] time)
  {
    var g = new List<int>[n + 1];
    var start = new HashSet<int>(Enumerable.Range(1, n));
    foreach (var rel in relations)
    {
      (g[rel[0]] ??= new List<int>()).Add(rel[1]);
      start.Remove(rel[1]);
    }
    for (var i = 1; i <= n; i++)
      g[i] ??= new List<int> { 0 };
    var maxTime = new int[n + 1];
    foreach (var v in start)
      Dfs(v);
    return maxTime[0];

    void Dfs(int v)
    {
      foreach (var next in g[v])
      {
        var t = maxTime[v] + time[v - 1];
        if (maxTime[next] < t)
        {
          maxTime[next] = t;
          if (next != 0)
            Dfs(next);
        }
      }
    }
  }
}
