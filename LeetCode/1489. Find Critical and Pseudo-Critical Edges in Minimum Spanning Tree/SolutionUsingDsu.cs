using LeetCode.Common;

namespace LeetCode._1489._Find_Critical_and_Pseudo_Critical_Edges_in_Minimum_Spanning_Tree;

public class SolutionUsingDsu
{
  public IList<IList<int>> FindCriticalAndPseudoCriticalEdges(int n, int[][] edges)
  {
    var sortedEdges = GetSortedEdges(edges);
    var mst = new Mst(sortedEdges, n);
    var mstWeight = mst.Weight();
    var criticalEdges = new List<int>();
    var pseudoCriticalEdges = new List<int>();
    foreach (var edge in sortedEdges)
    {
      if (IsCriticalEdge(mst, mstWeight, edge))
        criticalEdges.Add(edge.Index);
      else if (IsPseudoCriticalEdge(mst, mstWeight, edge))
        pseudoCriticalEdges.Add(edge.Index);
    }
    return new List<IList<int>> { criticalEdges, pseudoCriticalEdges };
  }

  private static bool IsCriticalEdge(Mst mst, int originalWeight, Edge edge)
  {
    var mstWeightWithoutEdge = mst.WeightWithout(edge);
    return mstWeightWithoutEdge == -1 || mstWeightWithoutEdge > originalWeight;
  }

  private static bool IsPseudoCriticalEdge(Mst mst, int originalWeight, Edge edge)
  {
    return mst.WeightWithRequired(edge) == originalWeight;
  }

  private static Edge[] GetSortedEdges(int[][] edges)
  {
    return Enumerable.Range(0, edges.Length)
      .Select(i => new Edge(i, edges[i][0], edges[i][1], edges[i][2]))
      .OrderBy(e => e.Weight)
      .ToArray();
  }

  private readonly record struct Edge(int Index, int From, int To, int Weight);

  private class Dsu
  {
    private readonly int[] parent;
    private readonly int[] size;
    private int count;

    public int Count => count;

    private void MakeSet(int x)
    {
      parent[x] = x;
      size[x] = 1;
      count++;
    }

    private int Find(int x)
    {
      if (parent[x] != x)
      {
        parent[x] = Find(parent[x]);
      }
      return parent[x];
    }

    public bool Union(int x, int y)
    {
      x = Find(x);
      y = Find(y);
      if (x != y)
      {
        if (size[x] < size[y])
          (x, y) = (y, x);
        parent[y] = x;
        size[x] += size[y];
        count--;
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

  /// <summary>
  /// MST weight finder using Kruskal algo.
  /// </summary>
  private class Mst(Edge[] sortedByWeightEdges, int vertexCount)
  {
    public int WeightWithout(Edge excluded)
    {
      return Weight(excluded);
    }

    public int WeightWithRequired(Edge required)
    {
      return Weight(null, required);
    }

    public int Weight(Edge? excluded = null, Edge? required = null)
    {
      var dsu = new Dsu(vertexCount);
      var weight = 0;
      if (required != null)
      {
        var edge = required.Value;
        weight += edge.Weight;
        dsu.Union(edge.From, edge.To);
      }
      foreach (var edge in sortedByWeightEdges)
      {
        if (edge.Index != excluded?.Index)
        {
          if (dsu.Union(edge.From, edge.To))
            weight += edge.Weight;
        }
      }
      return dsu.Count > 1 ? -1 : weight;
    }
  }
}

[TestFixture]
public class SolutionUsingDsuTests
{
  [TestCase(5, "[[0,1,1],[1,2,1],[2,3,2],[0,3,2],[0,4,3],[3,4,3],[1,4,6]]", "[[0,1],[2,3,4,5]]")]
  [TestCase(4, "[[0,1,1],[1,2,1],[2,3,1],[0,3,1]]", "[[],[0,1,2,3]]")]
  public void Test(int n, string edges, string expected)
  {
    new SolutionUsingDsu().FindCriticalAndPseudoCriticalEdges(5, edges.Array2()).Should().BeEquivalentTo(expected.Array2());
  }
}
