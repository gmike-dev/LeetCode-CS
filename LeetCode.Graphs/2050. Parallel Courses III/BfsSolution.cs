namespace LeetCode.Graphs._2050._Parallel_Courses_III;

public class BfsSolution
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
    var q = new Queue<int>();
    foreach (var v in start)
      q.Enqueue(v);
    var maxTime = new int[n + 1];
    while (q.Count > 0)
    {
      var v = q.Dequeue();
      foreach (var next in g[v])
      {
        if (maxTime[next] < maxTime[v] + time[v - 1])
        {
          maxTime[next] = maxTime[v] + time[v - 1];
          if (next != 0)
            q.Enqueue(next);
        }
      }
    }
    return maxTime[0];
  }
}
