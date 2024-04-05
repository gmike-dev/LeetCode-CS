namespace LeetCode._2642._Design_Graph_With_Shortest_Path_Calculator;

public class Graph
{
  private int[,] g;
  private int n;

  public Graph(int n, int[][] edges)
  {
    this.n = n;
    g = new int[n, n];
    foreach (var edge in edges)
      AddEdge(edge);
  }

  public void AddEdge(int[] edge)
  {
    g[edge[0], edge[1]] = edge[2];
  }

  public int ShortestPath(int node1, int node2)
  {
    return Dijkstra(node1, node2);
  }

  private int Dijkstra(int from, int to)
  {
    var used = new bool[n];
    var dist = new int[n];
    Array.Fill(dist, int.MaxValue);
    dist[from] = 0;
    for (var i = 0; i < n; i++)
    {
      var v = -1;
      for (var j = 0; j < n; j++)
      {
        if (!used[j] && (v == -1 || dist[j] < dist[v]))
          v = j;
      }
      if (dist[v] == int.MaxValue)
        break;
      used[v] = true;
      for (var j = 0; j < n; j++)
      {
        if (g[v, j] != 0)
          dist[j] = Math.Min(dist[j], dist[v] + g[v, j]);
      }
    }
    return dist[to] == int.MaxValue ? -1 : dist[to];
  }
}
