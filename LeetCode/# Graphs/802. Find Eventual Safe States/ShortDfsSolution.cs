using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.__Graphs._802._Find_Eventual_Safe_States;

public class ShortDfsSolution
{
  public IList<int> EventualSafeNodes(int[][] graph)
  {
    var n = graph.Length;
    var visited = new BitArray(n);
    var safe = new BitArray(n);
    return Enumerable.Range(0, n).Where(IsSafe).ToArray();

    bool IsSafe(int i)
    {
      if (visited[i])
        return safe[i];
      visited[i] = true;
      return safe[i] = graph[i].All(IsSafe);
    }
  }
}

[TestFixture]
public class ShortDfsSolutionTests
{
  [Test]
  public void Test1()
  {
    new ShortDfsSolution().EventualSafeNodes(new[]
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
    new ShortDfsSolution().EventualSafeNodes(new[]
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
    new ShortDfsSolution().EventualSafeNodes(new[]
      {
        new[] { 1 },
        new[] { 0, 2 },
        new int[] { },
      })
      .Should()
      .BeEquivalentTo(new[] { 2 }, o => o.WithStrictOrdering());
  }
}
