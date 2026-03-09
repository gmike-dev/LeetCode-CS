using LeetCode.Common;

namespace LeetCode.Graphs._1129._Shortest_Path_with_Alternating_Colors;

/// <summary>
/// Solution for <see href="https://leetcode.com/problems/shortest-path-with-alternating-colors/">Shortest Path with Alternating Colors</see> problem.
/// </summary>
public class Solution
{
  public int[] ShortestAlternatingPaths(int n, int[][] redEdges, int[][] blueEdges)
  {
    int[] result = new int[n];
    List<int>[][] g = new List<int>[2][];
    for (int i = 0; i < 2; i++)
    {
      g[i] = new List<int>[n];
      for (int j = 0; j < n; j++)
      {
        g[i][j] = [];
      }
    }
    foreach (int[] e in redEdges)
    {
      g[0][e[0]].Add(e[1]);
    }
    foreach (int[] e in blueEdges)
    {
      g[1][e[0]].Add(e[1]);
    }
    result.AsSpan(1).Fill(int.MaxValue);
    Bfs(0);
    Bfs(1);
    for (var i = 0; i < n; i++)
    {
      if (result[i] == int.MaxValue)
      {
        result[i] = -1;
      }
    }
    return result;

    void Bfs(int index)
    {
      bool[][] visited = new bool[2][];
      for (int i = 0; i < 2; i++)
      {
        visited[i] = new bool[n];
        visited[i][0] = true;
      }
      int length = 1;
      Queue<int> q = new();
      q.Enqueue(0);
      while (q.Count > 0)
      {
        int qSize = q.Count;
        for (int i = 0; i < qSize; i++)
        {
          int u = q.Dequeue();
          foreach (int v in g[index][u])
          {
            if (!visited[index][v])
            {
              q.Enqueue(v);
              visited[index][v] = true;
              result[v] = Math.Min(result[v], length);
            }
          }
        }
        index = (index + 1) & 1;
        length++;
      }
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(3, "[[0,1],[1,2]]", "[]", "[0,1,-1]")]
  [TestCase(3, "[[0,1]]", "[[2,1]]", "[0,1,-1]")]
  [TestCase(5, "[[0,1],[1,2],[2,3],[3,4]]", "[[1,2],[2,3],[3,1]]", "[0,1,2,3,7]")]
  public void Test(int n, string redEdges, string blueEdges, string expected)
  {
    new Solution().ShortestAlternatingPaths(n, redEdges.Array2(), blueEdges.Array2())
      .Should().BeEquivalentTo(expected.Array(), o => o.WithStrictOrdering());
  }
}
