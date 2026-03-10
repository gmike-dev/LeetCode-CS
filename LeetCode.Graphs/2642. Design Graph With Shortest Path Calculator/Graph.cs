namespace LeetCode.Graphs._2642._Design_Graph_With_Shortest_Path_Calculator;

/// <summary>
/// Solution for <see href="https://leetcode.com/problems/design-graph-with-shortest-path-calculator/">Design Graph With Shortest Path Calculator</see> problem.
/// </summary>
public class Graph
{
  private readonly List<(int, int)>[] g;
  private readonly int n;

  public Graph(int n, int[][] edges)
  {
    this.n = n;
    g = new List<(int, int)>[n];
    for (var i = 0; i < n; i++)
    {
      g[i] = [];
    }
    foreach (int[] edge in edges)
    {
      AddEdge(edge);
    }
  }

  public void AddEdge(int[] edge)
  {
    int u = edge[0];
    int v = edge[1];
    int w = edge[2];
    g[u].Add((v, w));
  }

  public int ShortestPath(int node1, int node2)
  {
    return Dijkstra(node1, node2);
  }

  private int Dijkstra(int from, int to)
  {
    Span<int> dist = stackalloc int[n];
    dist.Fill(int.MaxValue);
    dist[from] = 0;
    PriorityQueue<int, int> queue = new();
    queue.Enqueue(from, 0);
    while (queue.TryDequeue(out int u, out int d))
    {
      if (d > dist[u])
      {
        continue;
      }
      if (u == to)
      {
        return d;
      }
      foreach ((int v, int w) in g[u])
      {
        int newDist = d + w;
        if (newDist < dist[v])
        {
          dist[v] = newDist;
          queue.Enqueue(v, newDist);
        }
      }
    }
    return -1;
  }
}

[TestFixture]
public class GraphTests
{
  [Test]
  public void Test1()
  {
    Graph g = new(4, [
      [0, 2, 5],
      [0, 1, 2],
      [1, 2, 1],
      [3, 0, 3]
    ]);
    g.ShortestPath(3, 2).Should().Be(6);
    g.ShortestPath(0, 3).Should().Be(-1);
    g.AddEdge([1, 3, 4]);
    g.ShortestPath(0, 3).Should().Be(6);
  }

  [Test]
  public void Test2()
  {
    Graph g = new(6, [
      [3, 5, 990551],
      [1, 3, 495721],
      [0, 1, 985797],
      [4, 5, 422863],
      [4, 1, 505663]
    ]);
    g.ShortestPath(0, 1).Should().Be(985797);
    g.ShortestPath(3, 5).Should().Be(990551);
    g.ShortestPath(4, 4).Should().Be(0);
    g.ShortestPath(0, 3).Should().Be(1481518);
    g.AddEdge([5, 0, 250117]);
    g.ShortestPath(4, 5).Should().Be(422863);
    g.AddEdge([3, 1, 142005]);
    g.ShortestPath(4, 0).Should().Be(672980);
  }
}
