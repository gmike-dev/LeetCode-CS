namespace LeetCode.__Graphs._3310._Remove_Methods_From_Project;

public class Solution
{
  public IList<int> RemainingMethods(int n, int k, int[][] invocations)
  {
    var g = new List<int>[n];
    for (var i = 0; i < n; i++)
      g[i] = [];
    foreach (var invocation in invocations)
      g[invocation[0]].Add(invocation[1]);

    var suspicious = new bool[n];
    MarkSuspicious(k);

    var visited = new bool[n];
    for (var i = 0; i < n; i++)
    {
      if (!suspicious[i] && !visited[i] && CallSuspicious(i))
        return Enumerable.Range(0, n).ToArray();
    }
    return Enumerable.Range(0, n).Where(i => !suspicious[i]).ToArray();

    bool CallSuspicious(int a)
    {
      visited[a] = true;
      foreach (var b in g[a])
      {
        if (!visited[b] && (suspicious[b] || CallSuspicious(b)))
          return true;
      }
      return false;
    }

    void MarkSuspicious(int a)
    {
      suspicious[a] = true;
      foreach (var b in g[a])
      {
        if (!suspicious[b])
          MarkSuspicious(b);
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
    new Solution().RemainingMethods(4, 1, [[1, 2], [0, 1], [3, 2]])
      .Should()
      .BeEquivalentTo([0, 1, 2, 3]);
  }

  [Test]
  public void Test2()
  {
    new Solution().RemainingMethods(5, 0, [[1, 2], [0, 2], [0, 1], [3, 4]])
      .Should()
      .BeEquivalentTo([3, 4]);
  }

  [Test]
  public void Test3()
  {
    new Solution().RemainingMethods(3, 2, [[1, 2], [0, 1], [2, 0]])
      .Should()
      .BeEmpty();
  }
}
