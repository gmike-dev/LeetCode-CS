namespace LeetCode.Graphs._2467._Most_Profitable_Path_in_a_Tree;

public class Solution
{
  public int MostProfitablePath(int[][] edges, int bob, int[] amount)
  {
    var n = amount.Length;
    var g = new List<int>[n];
    var parent = new int[n];
    var indegree = new int[n];
    BuildGraph();
    FindParents();

    var alice = new Queue<(int, int)>();
    var visited = new bool[n];
    alice.Enqueue((0, amount[0]));
    visited[0] = true;
    var maxProfit = int.MinValue;
    while (alice.Count != 0)
    {
      amount[bob] = 0;
      bob = parent[bob];
      var m = alice.Count;
      for (var i = 0; i < m; i++)
      {
        var (node, profit) = alice.Dequeue();
        var isChild = indegree[node] == 1 && node != 0;
        if (isChild)
        {
          maxProfit = Math.Max(maxProfit, profit);
        }
        else
        {
          foreach (var child in g[node])
          {
            if (visited[child])
              continue;
            var reward = child == bob ? amount[child] / 2 : amount[child];
            alice.Enqueue((child, profit + reward));
            visited[child] = true;
          }
        }
      }
    }
    return maxProfit;

    void BuildGraph()
    {
      for (var i = 0; i < n; i++)
        g[i] = [];
      foreach (var e in edges)
      {
        var (u, v) = (e[0], e[1]);
        g[u].Add(v);
        g[v].Add(u);
        indegree[u]++;
        indegree[v]++;
      }
    }

    void FindParents()
    {
      var q = new Queue<int>();
      var u = new bool[n];
      q.Enqueue(0);
      u[0] = true;
      while (q.Count != 0)
      {
        var p = q.Dequeue();
        foreach (var child in g[p])
        {
          if (u[child])
            continue;
          parent[child] = p;
          q.Enqueue(child);
          u[child] = true;
        }
      }
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().MostProfitablePath(
      [[0, 1], [1, 2], [1, 3], [3, 4]], 3,
      [-2, 4, 2, -4, 6]).Should().Be(6);
  }

  [Test]
  public void Test2()
  {
    new Solution().MostProfitablePath(
      [[0, 1]], 1, [-7280, 2350]).Should().Be(-7280);
  }
}
