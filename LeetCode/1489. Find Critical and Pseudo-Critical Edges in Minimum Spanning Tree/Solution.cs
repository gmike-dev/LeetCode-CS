using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode._1489._Find_Critical_and_Pseudo_Critical_Edges_in_Minimum_Spanning_Tree;

public class Solution
{
  public IList<IList<int>> FindCriticalAndPseudoCriticalEdges(int n, int[][] edges)
  {
    var m = edges.Length;
    var sortedEdges = Enumerable.Range(0, m).Select(i => new Edge(i, edges[i][0], edges[i][1], edges[i][2])).ToArray();
    SortByWeight(sortedEdges);
    var mst = new Mst(sortedEdges, n);
    var mstWeight = mst.CalculateWeight();
    var criticalEdges = new List<int>();
    var pseudoCriticalEdges = new List<int>();
    foreach (var edge in sortedEdges)
    {
      mst.Exclude(edge);
      var mstWeightWithoutEdge = mst.CalculateWeight();
      mst.UndoExclude();
      var isCriticalEdge = mstWeightWithoutEdge == -1 || mstWeightWithoutEdge > mstWeight;
      if (isCriticalEdge)
      {
        criticalEdges.Add(edge.Index);
        continue;
      }
      mst.Require(edge);
      var mstWeightWithRequiredEdge = mst.CalculateWeight();
      mst.UndoRequire();
      var isPseudoCriticalEdge = mstWeightWithRequiredEdge == mstWeight;
      if (isPseudoCriticalEdge)
        pseudoCriticalEdges.Add(edge.Index);
    }
    return new List<IList<int>> { criticalEdges, pseudoCriticalEdges };
  }

  private static void SortByWeight(Edge[] edges)
  {
    Array.Sort(edges, Comparer<Edge>.Create((e1, e2) =>
    {
      var cmp = e1.Weight.CompareTo(e2.Weight);
      return cmp != 0 ? cmp : e1.Index.CompareTo(e2.Index);
    }));
  }

  private readonly record struct Edge(int Index, int From, int To, int Weight);

  private class Mst
  {
    private readonly int _vertexCount;
    private readonly Edge[] _edges;
    private Edge? _excludedEdge;
    private Edge? _requiredEdge;

    public void Require(Edge e) => _requiredEdge = e;
    public void UndoRequire() => _requiredEdge = null;
    public void Exclude(Edge e) => _excludedEdge = e;
    public void UndoExclude() => _excludedEdge = null;

    public int CalculateWeight()
    {
      var treeIds = new int[_vertexCount];
      for (var i = 0; i < _vertexCount; i++)
        treeIds[i] = i;
      var weight = 0;
      if (_requiredEdge is { } requiredEdge)
      {
        weight += requiredEdge.Weight;
        treeIds[requiredEdge.From] = treeIds[requiredEdge.To];
      }
      foreach (var edge in _edges)
      {
        if (edge.Index != _excludedEdge?.Index)
        {
          var fromTree = treeIds[edge.From];
          var toTree = treeIds[edge.To];
          if (fromTree != toTree)
          {
            weight += edge.Weight;
            for (var j = 0; j < _vertexCount; j++)
              if (treeIds[j] == fromTree)
                treeIds[j] = toTree;
          }
        }
      }
      var treesCount = treeIds.Distinct().Count();
      return treesCount > 1 ? -1 : weight;
    }

    public Mst(Edge[] sortedByWeightEdges, int vertexCount)
    {
      _vertexCount = vertexCount;
      _edges = sortedByWeightEdges;
    }
  }
}