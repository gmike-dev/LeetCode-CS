namespace LeetCode.Graphs._2924._Find_Champion_II;

public class Solution
{
  public int FindChampion(int n, int[][] edges)
  {
    var g = new List<int>[n];
    foreach (var e in edges)
      (g[e[0]] ??= []).Add(e[1]);
    var candidates = Enumerable.Range(0, n).ToHashSet();
    var visited = new HashSet<int>();
    for (var i = 0; i < n; i++)
      F(i);
    return candidates.Count == 1 ? candidates.First() : -1;

    void F(int v)
    {
      if (!visited.Add(v) || g[v] == null)
        return;
      foreach (var next in g[v])
      {
        candidates.Remove(next);
        F(next);
      }
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().FindChampion(3, [[0, 1], [1, 2]]).Should().Be(0);
  }

  [Test]
  public void Test2()
  {
    new Solution().FindChampion(4, [[0, 2], [1, 3], [1, 2]]).Should().Be(-1);
  }
}
