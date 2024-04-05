namespace LeetCode._1489._Find_Critical_and_Pseudo_Critical_Edges_in_Minimum_Spanning_Tree;

public class Solution
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

  private class Mst
  {
    private readonly int _vertexCount;
    private readonly Edge[] _edges;

    public int WeightWithout(Edge excluded) => Weight(excluded);

    public int WeightWithRequired(Edge required) => Weight(null, required);

    public int Weight(Edge? excluded = null, Edge? required = null)
    {
      var treeIds = new int[_vertexCount];
      var treesCount = _vertexCount;
      for (var i = 0; i < _vertexCount; i++)
        treeIds[i] = i;
      var weight = 0;
      if (required != null)
      {
        var edge = required.Value;
        weight += edge.Weight;
        treeIds[edge.From] = treeIds[edge.To];
        treesCount--;
      }
      foreach (var edge in _edges)
      {
        if (edge.Index != excluded?.Index)
        {
          var fromTree = treeIds[edge.From];
          var toTree = treeIds[edge.To];
          if (fromTree != toTree)
          {
            weight += edge.Weight;
            for (var j = 0; j < _vertexCount; j++)
              if (treeIds[j] == fromTree)
                treeIds[j] = toTree;
            treesCount--;
          }
        }
      }
      return treesCount > 1 ? -1 : weight;
    }

    public Mst(Edge[] sortedByWeightEdges, int vertexCount)
    {
      _vertexCount = vertexCount;
      _edges = sortedByWeightEdges;
    }
  }
}
