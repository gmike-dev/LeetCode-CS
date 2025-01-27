namespace LeetCode.Graphs._1462._Course_Schedule_IV;

public class Solution
{
  public IList<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries)
  {
    var g = new int[numCourses][];
    for (var i = 0; i < numCourses; i++)
    {
      g[i] = new int[numCourses];
      g[i].AsSpan().Fill(-1);
      g[i][i] = 0;
    }
    foreach (var p in prerequisites)
      g[p[0]][p[1]] = 1;
    var results = new bool[queries.Length];
    for (var i = 0; i < queries.Length; i++)
      results[i] = Check(queries[i][0], queries[i][1]);
    return results;

    bool Check(int from, int to)
    {
      if (g[from][to] != -1)
        return g[from][to] != 0;
      for (var i = 0; i < numCourses; i++)
      {
        if (g[from][i] == 1 && Check(i, to))
        {
          g[from][to] = 1;
          return true;
        }
      }
      g[from][to] = 0;
      return false;
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().CheckIfPrerequisite(2, [[1, 0]], [[0, 1], [1, 0]])
      .Should()
      .BeEquivalentTo([false, true], o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new Solution().CheckIfPrerequisite(2, [], [[1, 0], [0, 1]])
      .Should()
      .BeEquivalentTo([false, false], o => o.WithStrictOrdering());
  }

  [Test]
  public void Test3()
  {
    new Solution().CheckIfPrerequisite(3, [[1, 2], [1, 0], [2, 0]], [[1, 0], [1, 2]])
      .Should()
      .BeEquivalentTo([true, true], o => o.WithStrictOrdering());
  }

  [Test]
  public void Test4()
  {
    new Solution().CheckIfPrerequisite(3, [[1, 0], [2, 0]], [[0, 1], [2, 0]])
      .Should()
      .BeEquivalentTo([false, true], o => o.WithStrictOrdering());
  }
}
