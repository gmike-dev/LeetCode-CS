namespace LeetCode.__Graphs._3123._Find_Edges_in_Shortest_Paths;

public class Solution
{
  public bool[] FindAnswer(int n, int[][] edges)
  {
    var g = new List<(int v, int w, int i)>[n];
    for (var i = 0; i < n; i++)
      g[i] = [];
    for (var i = 0; i < edges.Length; i++)
    {
      var e = edges[i];
      g[e[0]].Add((e[1], e[2], i));
      g[e[1]].Add((e[0], e[2], i));
    }

    // Dijkstra
    var costs = new int[n];
    Array.Fill(costs, int.MaxValue);
    costs[0] = 0;

    var next = new PriorityQueue<int, int>();
    next.Enqueue(0, 0);

    var prev = new List<(int v, int i)>[n];
    for (var i = 0; i < n; i++)
      prev[i] = [];

    while (next.TryDequeue(out var v, out var w))
    {
      if (w != costs[v])
        continue;
      foreach (var to in g[v])
      {
        var weight = w + to.w;
        if (weight < costs[to.v])
        {
          next.Enqueue(to.v, weight);
          prev[to.v] = [(v, to.i)];
          costs[to.v] = weight;
        }
        else if (weight == costs[to.v])
        {
          prev[to.v].Add((v, to.i));
        }
      }
    }

    // Backtrack paths and mark used edges.
    var result = new bool[edges.Length];
    var q = new Queue<int>();
    q.Enqueue(n - 1);
    while (q.Count > 0)
    {
      var v = q.Dequeue();
      foreach (var p in prev[v])
      {
        result[p.i] = true;
        q.Enqueue(p.v);
      }
    }
    return result;
  }
}

[TestFixture]
public class Tests4
{
  [Test]
  public void Test1()
  {
    new Solution().FindAnswer(6,
        [[0, 1, 4], [0, 2, 1], [1, 3, 2], [1, 4, 3], [1, 5, 1], [2, 3, 1], [3, 5, 3], [4, 5, 2]])
      .Should()
      .BeEquivalentTo([true, true, true, false, true, true, true, false], o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new Solution().FindAnswer(4, [[2, 0, 1], [0, 1, 1], [0, 3, 4], [3, 2, 2]])
      .Should()
      .BeEquivalentTo([true, false, false, true], o => o.WithStrictOrdering());
  }
}
