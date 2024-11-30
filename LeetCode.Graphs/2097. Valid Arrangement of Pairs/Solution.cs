namespace LeetCode.Graphs._2097._Valid_Arrangement_of_Pairs;

public class Solution
{
  public int[][] ValidArrangement(int[][] pairs)
  {
    var n = pairs.Length;
    var g = new Dictionary<int, Stack<int>>();
    var inDegree = new Dictionary<int, int>();
    var outDegree = new Dictionary<int, int>();
    for (var i = 0; i < n; i++)
    {
      var p = pairs[i];
      var u = p[0];
      var v = p[1];
      if (!g.TryGetValue(u, out var next))
        g[u] = next = new Stack<int>();
      next.Push(v);
      outDegree[u] = outDegree.GetValueOrDefault(u) + 1;
      inDegree[v] = inDegree.GetValueOrDefault(v) + 1;
    }

    var a = new List<int>();
    var start = -1;
    foreach (var (u, degree) in outDegree)
    {
      if (degree == inDegree.GetValueOrDefault(u) + 1)
      {
        start = u;
        break;
      }
    }
    if (start == -1)
      start = pairs[0][0];
    Dfs(start);
    a.Reverse();
    var result = new int[n][];
    for (var i = 0; i < n; i++)
      result[i] = [a[i], a[i + 1]];
    return result;

    void Dfs(int u)
    {
      var next = g.GetValueOrDefault(u);
      if (next != null)
      {
        while (next.Count != 0)
          Dfs(next.Pop());
      }
      a.Add(u);
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().ValidArrangement([[5, 1], [4, 5], [11, 9], [9, 4]]).Should()
      .BeEquivalentTo((int[][]) [[11, 9], [9, 4], [4, 5], [5, 1]]);
  }

  [Test]
  public void Test2()
  {
    new Solution().ValidArrangement([[1, 3], [3, 2], [2, 1]]).Should()
      .BeEquivalentTo((int[][]) [[1, 3], [3, 2], [2, 1]]);
  }

  [Test]
  public void Test3()
  {
    new Solution().ValidArrangement([[1, 2], [1, 3], [2, 1]]).Should()
      .BeEquivalentTo((int[][]) [[1, 2], [2, 1], [1, 3]]);
  }
}
