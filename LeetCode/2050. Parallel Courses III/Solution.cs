namespace LeetCode._2050._Parallel_Courses_III;

public class Solution
{
  public int MinimumTime(int n, int[][] relations, int[] time)
  {
    var g = new List<int>[n + 1];
    foreach (var rel in relations)
      (g[rel[0]] ??= new List<int>()).Add(rel[1]);
    var mem = new int[n + 1];
    return Enumerable.Range(1, n).Max(Dfs);

    int Dfs(int v)
    {
      if (mem[v] != 0)
        return mem[v];
      if (g[v] is null)
        return time[v - 1];
      foreach (var next in g[v])
        mem[v] = Math.Max(mem[v], time[v - 1] + Dfs(next));
      return mem[v];
    }
  }
}
