using System.Collections;

namespace LeetCode.__Graphs._802._Find_Eventual_Safe_States;

public class DfsSolution
{
  public IList<int> EventualSafeNodes(int[][] graph)
  {
    var n = graph.Length;
    var visited = new BitArray(n);
    var safe = new BitArray(n);
    for (var i = 0; i < n; i++)
      Dfs(i);

    return Enumerable.Range(0, n).Where(i => safe[i]).ToArray();

    void Dfs(int i)
    {
      if (visited[i])
        return;
      visited[i] = true;
      if (graph[i].Length == 0)
      {
        safe[i] = true;
        return;
      }
      foreach (var next in graph[i])
        Dfs(next);
      safe[i] = graph[i].All(j => safe[j]);
    }
  }
}

[TestFixture]
public class DfsSolutionTests
{
  [Test]
  public void Test1()
  {
    new DfsSolution().EventualSafeNodes(new[]
      {
        new[] { 1, 2 },
        new[] { 2, 3 },
        new[] { 5 },
        new[] { 0 },
        new[] { 5 },
        new int[] { },
        new int[] { }
      })
      .Should()
      .BeEquivalentTo(new[] { 2, 4, 5, 6 }, o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new DfsSolution().EventualSafeNodes(new[]
      {
        new[] { 1, 2, 3, 4 },
        new[] { 1, 2 },
        new[] { 3, 4 },
        new[] { 0, 4 },
        new int[] { }
      })
      .Should()
      .BeEquivalentTo(new[] { 4 }, o => o.WithStrictOrdering());
  }

  [Test]
  public void Test3()
  {
    new DfsSolution().EventualSafeNodes(new[]
      {
        new[] { 1 },
        new[] { 0, 2 },
        new int[] { },
      })
      .Should()
      .BeEquivalentTo(new[] { 2 }, o => o.WithStrictOrdering());
  }
}
