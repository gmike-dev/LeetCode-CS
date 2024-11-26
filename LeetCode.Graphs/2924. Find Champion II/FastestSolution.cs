namespace LeetCode.Graphs._2924._Find_Champion_II;

public class FastestSolution
{
  public int FindChampion(int n, int[][] edges)
  {
    Span<bool> weak = stackalloc bool[n];
    foreach (var e in edges)
      weak[e[1]] = true;
    var champion = -1;
    for (var i = 0; i < n; i++)
    {
      if (weak[i])
        continue;
      if (champion != -1)
        return -1;
      champion = i;
    }
    return champion;
  }
}


[TestFixture]
public class FastestSolutionTests
{
  [Test]
  public void Test1()
  {
    new FastestSolution().FindChampion(3, [[0, 1], [1, 2]]).Should().Be(0);
  }

  [Test]
  public void Test2()
  {
    new FastestSolution().FindChampion(4, [[0, 2], [1, 3], [1, 2]]).Should().Be(-1);
  }
}
