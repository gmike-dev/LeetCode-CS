using LeetCode.Common;

namespace LeetCode.Graphs._2203._Minimum_Weighted_Subgraph_With_the_Required_Paths;

public class Solution
{
  private const long Infinity = long.MaxValue / 3;

  public long MinimumWeight(int n, int[][] edges, int src1, int src2, int dest)
  {
    List<(int, int)>[] graph = CreateGraph(n, edges, false);
    List<(int, int)>[] reversedGraph = CreateGraph(n, edges, true);
    Span<long> dist1 = stackalloc long[n];
    Span<long> dist2 = stackalloc long[n];
    Span<long> dist3 = stackalloc long[n];
    Dijkstra(graph, src1, dist1);
    Dijkstra(graph, src2, dist2);
    Dijkstra(reversedGraph, dest, dist3);
    long result = Infinity;
    for (var i = 0; i < n; i++)
    {
      result = Math.Min(result, dist1[i] + dist2[i] + dist3[i]);
    }
    return result == Infinity ? -1 : result;
  }

  private static List<(int, int)>[] CreateGraph(int n, int[][] edges, bool reversed)
  {
    List<(int, int)>[] graph = new List<(int, int)>[n];
    for (var i = 0; i < n; i++)
    {
      graph[i] = [];
    }
    foreach (int[] edge in edges)
    {
      int u = edge[0];
      int v = edge[1];
      int w = edge[2];
      if (reversed)
      {
        (u, v) = (v, u);
      }
      graph[u].Add((v, w));
    }
    return graph;
  }

  private static void Dijkstra(List<(int, int)>[] graph, int source, Span<long> dist)
  {
    dist.Fill(Infinity);
    dist[source] = 0;
    PriorityQueue<int, long> queue = new();
    queue.Enqueue(source, 0L);
    while (queue.TryDequeue(out int u, out long d))
    {
      if (d > dist[u])
      {
        continue;
      }
      foreach ((int v, int w) in graph[u])
      {
        long newDist = d + w;
        if (newDist < dist[v])
        {
          dist[v] = newDist;
          queue.Enqueue(v, newDist);
        }
      }
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(6, "[[0,2,2],[0,5,6],[1,0,3],[1,4,5],[2,1,1],[2,3,3],[2,3,4],[3,4,2],[4,5,1]]", 0, 1, 5, 9)]
  [TestCase(3, "[[0,1,1],[2,1,1]]", 0, 1, 2, -1)]
  public void Test(int n, string edges, int src1, int src2, int dest, int expected)
  {
    new Solution().MinimumWeight(n, edges.Array2(), src1, src2, dest).Should().Be(expected);
  }
}
