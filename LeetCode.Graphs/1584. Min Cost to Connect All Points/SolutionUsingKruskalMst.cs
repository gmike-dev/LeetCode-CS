using LeetCode.Common;

namespace LeetCode.Graphs._1584._Min_Cost_to_Connect_All_Points;

public class SolutionUsingKruskalMst
{
  public int MinCostConnectPoints(int[][] points)
  {
    var edges = new List<Edge>();
    for (var i = 0; i < points.Length - 1; i++)
    for (var j = i + 1; j < points.Length; j++)
      edges.Add(Edge.Create(points, i, j));
    return Kruskal(edges, points.Length);
  }

  private static int Kruskal(List<Edge> edges, int vertexCount)
  {
    edges.Sort((x, y) => x.Weight.CompareTo(y.Weight));
    var dsu = new Dsu(vertexCount);
    var mstWeight = 0;
    foreach (var edge in edges)
      if (dsu.Union(edge.From, edge.To))
        mstWeight += edge.Weight;
    return mstWeight;
  }

  private readonly record struct Edge(int From, int To, int Weight)
  {
    public static Edge Create(int[][] points, int i, int j) =>
      new(i, j, Math.Abs(points[i][0] - points[j][0]) + Math.Abs(points[i][1] - points[j][1]));
  }

  private class Dsu
  {
    private readonly int[] parent;
    private readonly int[] size;

    private void MakeSet(int x)
    {
      parent[x] = x;
      size[x] = 1;
    }

    private int Find(int x)
    {
      while (parent[x] != x)
      {
        parent[x] = parent[parent[x]];
        x = parent[x];
      }
      return x;
    }

    public bool Union(int x, int y)
    {
      x = Find(x);
      y = Find(y);
      if (x != y)
      {
        if (size[x] < size[y])
          (x, y) = (y, x);
        parent[y] = x; // Always add a smaller set to a larger set.
        size[x] += size[y];
      }
      return x != y;
    }

    public Dsu(int n)
    {
      parent = new int[n];
      size = new int[n];
      for (var i = 0; i < n; i++)
        MakeSet(i);
    }
  }
}

[TestFixture]
public class SolutionUsingKruskalMstTests
{
  [TestCase("[[0,0],[2,2],[3,10],[5,2],[7,0]]", 20)]
  [TestCase("[[3,12],[-2,5],[-4,1]]", 18)]
  public void Test(string points, int expected)
  {
    new SolutionUsingKruskalMst().MinCostConnectPoints(points.Array2()).Should().Be(expected);
  }
}
