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

    public void MakeSet(int v)
    {
      _parent[v] = v;
      _size[v] = 1;
      _count++;
    }

    public int Find(int v)
    {
      while (_parent[v] != v)
      {
        _parent[v] = _parent[_parent[v]];
        v = _parent[v];
      }
      return v;
    }

    public bool Union(int v1, int v2)
    {
      var s1 = Find(v1);
      var s2 = Find(v2);
      if (s1 != s2)
      {
        _parent[s1] = s2;
        if (_size[s1] > _size[s2])
          (_size[s1], _size[s2]) = (_size[s2], _size[s1]);
        _size[s1] += _size[s2];
        _count--;
      }
      return s1 != s2;
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