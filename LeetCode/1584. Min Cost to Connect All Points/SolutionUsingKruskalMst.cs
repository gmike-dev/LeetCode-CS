using System;
using System.Collections.Generic;

namespace LeetCode._1584._Min_Cost_to_Connect_All_Points;

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
  
  private readonly record struct Edge (int From, int To, int Weight)
  {
    public static Edge Create(int[][] points, int i, int j) => 
      new(i, j, Math.Abs(points[i][0] - points[j][0]) + Math.Abs(points[i][1] - points[j][1]));
  }
  
  private class Dsu
  {
    private readonly int[] _parent;
    private readonly int[] _size;

    public void MakeSet(int v)
    {
      _parent[v] = v;
      _size[v] = 1;
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

}