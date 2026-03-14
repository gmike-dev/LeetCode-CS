using LeetCode.Common;

namespace LeetCode.Graphs._1584._Min_Cost_to_Connect_All_Points;

public class SolutionUsingPrimPriorityQueue
{
  public int MinCostConnectPoints(int[][] points)
  {
    int n = points.Length;
    List<(int v, int weight)>[] g = new List<(int v, int weight)>[n];
    for (int i = 0; i < n; i++)
    {
      g[i] = [];
    }
    for (int i = 0; i < n; i++)
    {
      int[] p1 = points[i];
      int x1 = p1[0];
      int y1 = p1[1];
      for (int j = i + 1; j < n; j++)
      {
        int[] p2 = points[j];
        int x2 = p2[0];
        int y2 = p2[1];
        int w = Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        g[i].Add((j, w));
        g[j].Add((i, w));
      }
    }
    return Prim(g);
  }

  private static int Prim(List<(int v, int weight)>[] g)
  {
    int n = g.Length;
    var used = new bool[n];
    var pq = new PriorityQueue<int, int>();
    pq.Enqueue(0, 0);
    int mst = 0;
    while (pq.TryDequeue(out int v, out int w))
    {
      if (used[v])
      {
        continue;
      }

      used[v] = true;
      mst += w;

      foreach (var (to, weight) in g[v])
      {
        if (!used[to])
        {
          pq.Enqueue(to, weight);
        }
      }
    }

    return mst;
  }
}

[TestFixture]
public class SolutionUsingPrimPriorityQueueTests
{
  [TestCase("[[0,0],[2,2],[3,10],[5,2],[7,0]]", 20)]
  [TestCase("[[3,12],[-2,5],[-4,1]]", 18)]
  public void Test(string points, int expected)
  {
    new SolutionUsingPrimPriorityQueue().MinCostConnectPoints(points.Array2()).Should().Be(expected);
  }
}
