namespace LeetCode.Graphs._207._Course_Schedule;

public class Solution
{
  public bool CanFinish(int numCourses, int[][] prerequisites)
  {
    var next = new List<int>[numCourses];
    foreach (var p in prerequisites)
      (next[p[1]] ??= []).Add(p[0]);
    var color = new int[numCourses];
    return !Enumerable.Range(0, numCourses).Any(IsCycle);

    bool IsCycle(int v)
    {
      if (color[v] == 0)
      {
        color[v] = 1;
        if (next[v]?.Any(IsCycle) == true)
          return true;
        color[v] = 2;
      }
      return color[v] == 1;
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().CanFinish(2, [[1, 0]]).Should().BeTrue();
  }

  [Test]
  public void Test2()
  {
    new Solution().CanFinish(2, [[1, 0], [0, 1]]).Should().BeFalse();
  }

  [Test]
  public void Test3()
  {
    new Solution().CanFinish(4, [
      [2, 0],
      [2, 1],
      [3, 2],
      [2, 3]
    ]).Should().BeFalse();
  }

  [Test]
  public void Test4()
  {
    new Solution().CanFinish(4, [
      [2, 0],
      [2, 1],
      [3, 2]
    ]).Should().BeTrue();
  }

  [Test]
  public void Test5()
  {
    new Solution().CanFinish(8, [
      [1, 0], [0, 5],
      [1, 7], [7, 0],
      [4, 6], [6, 2]
    ]).Should().BeTrue();
  }

  [Test]
  public void Test6()
  {
    new Solution().CanFinish(6, [
      [1, 0], [2, 0],
      [3, 5], [3, 2],
      [4, 3], [5, 1]
    ]).Should().BeTrue();
  }

  [Test]
  public void Test7()
  {
    new Solution().CanFinish(5, [
      [1, 0], [2, 0],
      [3, 4], [3, 2],
      [4, 1]
    ]).Should().BeTrue();
  }

  [Test]
  public void Test41()
  {
    new Solution().CanFinish(20, [
      [0, 10], [3, 18],
      [5, 5], [6, 11],
      [11, 14], [13, 1],
      [15, 1], [17, 4]
    ]).Should().BeFalse();
  }
}
