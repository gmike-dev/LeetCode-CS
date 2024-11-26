namespace LeetCode.Graphs._2924._Find_Champion_II;

public class InDegreeCountSolution
{
  public int FindChampion(int n, int[][] edges)
  {
    Span<int> indegree = stackalloc int[n];
    foreach (var e in edges)
      indegree[e[1]]++;
    var champion = -1;
    var count = 0;
    for (var i = 0; i < n; i++)
    {
      if (indegree[i] == 0)
      {
        champion = i;
        count++;
      }
    }
    return count == 1 ? champion : -1;
  }
}

[TestFixture]
public class InDegreeCountSolutionTests
{
  [Test]
  public void Test1()
  {
    new InDegreeCountSolution().FindChampion(3, [[0, 1], [1, 2]]).Should().Be(0);
  }

  [Test]
  public void Test2()
  {
    new InDegreeCountSolution().FindChampion(4, [[0, 2], [1, 3], [1, 2]]).Should().Be(-1);
  }
}
