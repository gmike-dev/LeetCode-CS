namespace LeetCode.Graphs._1462._Course_Schedule_IV;

public class Solution2
{
  public IList<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries)
  {
    var g = new List<int>[numCourses];
    for (var i = 0; i < numCourses; i++)
      g[i] = [];
    foreach (var p in prerequisites)
      g[p[0]].Add(p[1]);
    var isPrerequisite = new bool[numCourses, numCourses];
    for (var i = 0; i < numCourses; i++)
      FillAllPrerequisites(i);
    var ans = new bool[queries.Length];
    for (var i = 0; i < queries.Length; i++)
      ans[i] = isPrerequisite[queries[i][0], queries[i][1]];
    return ans;

    void FillAllPrerequisites(int u)
    {
      Dfs(u);
      return;

      void Dfs(int v)
      {
        foreach (var nv in g[v])
        {
          if (isPrerequisite[u, nv])
            continue;
          isPrerequisite[u, nv] = true;
          Dfs(nv);
        }
      }
    }
  }
}

[TestFixture]
public class Solution2Tests
{
  [Test]
  public void Test1()
  {
    new Solution2().CheckIfPrerequisite(2, [[1, 0]], [[0, 1], [1, 0]])
      .Should()
      .BeEquivalentTo([false, true], o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new Solution2().CheckIfPrerequisite(2, [], [[1, 0], [0, 1]])
      .Should()
      .BeEquivalentTo([false, false], o => o.WithStrictOrdering());
  }

  [Test]
  public void Test3()
  {
    new Solution2().CheckIfPrerequisite(3, [[1, 2], [1, 0], [2, 0]], [[1, 0], [1, 2]])
      .Should()
      .BeEquivalentTo([true, true], o => o.WithStrictOrdering());
  }

  [Test]
  public void Test4()
  {
    new Solution2().CheckIfPrerequisite(3, [[1, 0], [2, 0]], [[0, 1], [2, 0]])
      .Should()
      .BeEquivalentTo([false, true], o => o.WithStrictOrdering());
  }
}
