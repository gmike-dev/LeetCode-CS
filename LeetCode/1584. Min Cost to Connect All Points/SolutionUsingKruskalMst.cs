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

    public void MakeSet(int x)
    {
      _parent[x] = x;
      _size[x] = 1;
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

}