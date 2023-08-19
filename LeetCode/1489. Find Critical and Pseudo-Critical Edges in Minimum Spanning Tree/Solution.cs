using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode._1489._Find_Critical_and_Pseudo_Critical_Edges_in_Minimum_Spanning_Tree;

public class Solution
{
  public IList<IList<int>> FindCriticalAndPseudoCriticalEdges(int n, int[][] edges)
  {
    var m = edges.Length;
    var customEdges = Enumerable.Range(0, m).Select(i => new Edge(i, edges[i][0], edges[i][1], edges[i][2])).ToArray();
    var mst = new Mst(customEdges, n);
    var mstWeight = mst.CalculateWeight();
    var criticalEdges = new List<int>();
    var pseudoCriticalEdges = new List<int>();
    foreach (var edge in customEdges)
    {
      mst.Delete(edge);
      var mstWeightWithoutEdge = mst.CalculateWeight();
      mst.Add(edge);
      var isCriticalEdge = mstWeightWithoutEdge == -1 || mstWeightWithoutEdge > mstWeight;
      if (isCriticalEdge)
      {
        criticalEdges.Add(edge.Index);
        continue;
      }
      mst.AddRequired(edge);
      var mstWeightWithRequiredEdge = mst.CalculateWeight();
      mst.RemoveRequired(edge);
      var isPseudoCriticalEdge = mstWeightWithRequiredEdge == mstWeight;
      if (isPseudoCriticalEdge)
        pseudoCriticalEdges.Add(edge.Index);
    }
    return new List<IList<int>> { criticalEdges, pseudoCriticalEdges };
  }

  private readonly record struct Edge(int Index, int From, int To, int Weight);

  private class Mst
  {
    private readonly int _vertexCount;
    private readonly SortedSet<Edge> _edges;
    private readonly List<Edge> _requiredEdges = new();

    public void AddRequired(Edge e) => _requiredEdges.Add(e);
    public void RemoveRequired(Edge e) => _requiredEdges.Remove(e);
    public void Add(Edge e) => _edges.Add(e);
    public void Delete(Edge e) => _edges.Remove(e);

    public int CalculateWeight()
    {
      var treeIds = new int[_vertexCount];
      for (var i = 0; i < _vertexCount; i++)
        treeIds[i] = i;
      var weight = 0;
      if (_requiredEdges.Count > 0)
      {
        var treeId = _requiredEdges[0].From;
        foreach (var edge in _requiredEdges)
        {
          weight += edge.Weight;
          treeIds[edge.From] = treeIds[edge.To] = treeId;
        }
      }
      foreach (var edge in _edges)
      {
        var fromTreeId = treeIds[edge.From];
        var toTreeId = treeIds[edge.To];
        if (fromTreeId != toTreeId)
        {
          weight += edge.Weight;
          for (var j = 0; j < _vertexCount; j++)
            if (treeIds[j] == fromTreeId)
              treeIds[j] = toTreeId;
        }
      }
      var treesCount = treeIds.Distinct().Count();
      return treesCount > 1 ? -1 : weight;
    }

    public Mst(IEnumerable<Edge> edges, int vertexCount)
    {
      _vertexCount = vertexCount;
      _edges = new SortedSet<Edge>(edges, Comparer<Edge>.Create((e1, e2) =>
      {
        var cmp = e1.Weight.CompareTo(e2.Weight);
        return cmp != 0 ? cmp : e1.Index.CompareTo(e2.Index);
      }));
    }
  }
}