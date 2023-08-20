using System.Collections.Generic;
using System.Linq;

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

  /// <summary>
  /// Disjoint-set.
  /// </summary>
  /// <remarks>Union–find data structure.</remarks>
  private class Dsu
  {
    private readonly int[] _parent;
    private readonly int[] _size;
    private int _count;

    public int Count => _count;

    public void MakeSet(int x)
    {
      _parent[x] = x;
      _size[x] = 1;
      _count++;
    }

    public int Find(int x)
    {
      while (_parent[x] != x)
      {
        _parent[x] = _parent[_parent[x]];
        x = _parent[x];
      }
      return x;
    }

    public bool Union(int x, int y)
    {
      x = Find(x);
      y = Find(y);
      if (x != y)
      {
        if (_size[x] < _size[y])
          (x, y) = (y, x);
        _parent[y] = x; // Always add a smaller set to a larger set.
        _size[x] += _size[y];
        _count--;
      }
      return x != y;
    }

    public Dsu(int n)
    {
      _parent = new int[n];
      _size = new int[n];
      for (var i = 0; i < n; i++)
        MakeSet(i);
    }
  }

  /// <summary>
  /// MST weight finder using Kruskal algo.
  /// </summary>
  private class Mst
  {
    private readonly int _vertexCount;
    private readonly Edge[] _edges;

    public int WeightWithout(Edge excluded) => Weight(excluded);

    public int WeightWithRequired(Edge required) => Weight(null, required);

    public int Weight(Edge? excluded = null, Edge? required = null)
    {
      var dsu = new Dsu(_vertexCount);
      var weight = 0;
      if (required != null)
      {
        var edge = required.Value;
        weight += edge.Weight;
        dsu.Union(edge.From, edge.To);
      }
      foreach (var edge in _edges)
      {
        if (edge.Index != excluded?.Index)
        {
          if (dsu.Union(edge.From, edge.To))
            weight += edge.Weight;
        }
      }
      return dsu.Count > 1 ? -1 : weight;
    }

    public Mst(Edge[] sortedByWeightEdges, int vertexCount)
    {
      _vertexCount = vertexCount;
      _edges = sortedByWeightEdges;
    }
  }
}