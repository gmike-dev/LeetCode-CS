namespace LeetCode.__Graphs._2699._Modify_Graph_Edge_Weights;

public class Solution
{
  public int[][] ModifiedGraphEdges(int n, int[][] edges, int source, int destination, int target)
  {
    var g = new int[n, n];
    foreach (var edge in edges)
    {
      if (edge[2] > 0)
      {
        g[edge[0], edge[1]] = edge[2];
        g[edge[1], edge[0]] = edge[2];
      }
    }
    var minDist = Dijkstra(n, g, source, destination);
    if (minDist < target)
      return [];
    var equalTarget = minDist == target;
    foreach (var edge in edges)
    {
      if (edge[2] > 0)
        continue;

      edge[2] = equalTarget ? (int)1e9 : 1;
      g[edge[0], edge[1]] = edge[2];
      g[edge[1], edge[0]] = edge[2];

      if (!equalTarget)
      {
        var dist = Dijkstra(n, g, source, destination);
        if (dist <= target)
        {
          equalTarget = true;
          edge[2] += target - (int)dist;
        }
      }
    }

    return equalTarget ? edges : [];
  }

  private static long Dijkstra(int n, int[,] g, int source, int destination)
  {
    var used = new bool[n];
    var dist = new long[n];
    Array.Fill(dist, int.MaxValue);
    dist[source] = 0;
    for (var i = 0; i < n; i++)
    {
      var v = -1;
      for (var j = 0; j < n; j++)
      {
        if (!used[j] && (v == -1 || dist[j] < dist[v]))
          v = j;
      }
      if (dist[v] == int.MaxValue || v == destination)
        break;
      used[v] = true;
      for (var j = 0; j < n; j++)
      {
        if (g[v, j] != 0)
          dist[j] = Math.Min(dist[j], dist[v] + g[v, j]);
      }
    }
    return dist[destination];
  }
}

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    List<List<int>> expected = [[4, 1, 1], [2, 0, 1], [0, 3, 1], [4, 3, 3]];
    new Solution().ModifiedGraphEdges(5, [[4, 1, -1], [2, 0, -1], [0, 3, -1], [4, 3, -1]], 0, 1, 5)
      .Should()
      .BeEquivalentTo(expected);
  }

  [Test]
  public void Test2()
  {
    List<List<int>> expected = [];
    new Solution().ModifiedGraphEdges(3, [[0, 1, -1], [0, 2, 5]], 0, 2, 6)
      .Should()
      .BeEquivalentTo(expected);
  }

  [Test]
  public void Test3()
  {
    List<List<int>> expected = [[1, 0, 4], [1, 2, 3], [2, 3, 5], [0, 3, 1]];
    new Solution().ModifiedGraphEdges(4, [[1, 0, 4], [1, 2, 3], [2, 3, 5], [0, 3, -1]], 0, 2, 6)
      .Should()
      .BeEquivalentTo(expected);
  }

  [Test]
  public void Test4()
  {
    List<List<int>> expected = [[0, 1, 4], [2, 0, 2], [3, 2, 6], [2, 1, 10], [3, 0, 1000000000]];
    new Solution().ModifiedGraphEdges(4, [[0, 1, -1], [2, 0, 2], [3, 2, 6], [2, 1, 10], [3, 0, -1]], 1, 3, 12)
      .Should()
      .BeEquivalentTo(expected);
  }
}
