using LeetCode.Common;

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
      var treeIds = new int[vertexCount];
      var treesCount = vertexCount;
      for (var i = 0; i < vertexCount; i++)
        treeIds[i] = i;
      var weight = 0;
      if (required != null)
      {
        var edge = required.Value;
        weight += edge.Weight;
        treeIds[edge.From] = treeIds[edge.To];
        treesCount--;
      }
      foreach (var edge in sortedByWeightEdges)
      {
        if (edge.Index != excluded?.Index)
        {
          var fromTree = treeIds[edge.From];
          var toTree = treeIds[edge.To];
          if (fromTree != toTree)
          {
            weight += edge.Weight;
            for (var j = 0; j < vertexCount; j++)
              if (treeIds[j] == fromTree)
                treeIds[j] = toTree;
            treesCount--;
          }
        }
      }
      return treesCount > 1 ? -1 : weight;
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(5, "[[0,1,1],[1,2,1],[2,3,2],[0,3,2],[0,4,3],[3,4,3],[1,4,6]]", "[[0,1],[2,3,4,5]]")]
  [TestCase(4, "[[0,1,1],[1,2,1],[2,3,1],[0,3,1]]", "[[],[0,1,2,3]]")]
  public void Test(int n, string edges, string expected)
  {
    new Solution().FindCriticalAndPseudoCriticalEdges(5, edges.Array2()).Should().BeEquivalentTo(expected.Array2());
  }
}
