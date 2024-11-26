namespace LeetCode.Graphs._2924._Find_Champion_II;

public class InDegreeCountSolution2
{
  public int FindChampion(int n, int[][] edges)
  {
    var weak = new BitArray(n);
    foreach (var e in edges)
      weak.Set(e[1], true);
    var champion = -1;
    var count = 0;
    for (var i = 0; i < n; i++)
    {
      if (!weak[i])
      {
        champion = i;
        count++;
      }
    }
    return count == 1 ? champion : -1;
  }
}

[TestFixture]
public class InDegreeCountSolution2Tests
{
  [Test]
  public void Test1()
  {
    new InDegreeCountSolution2().FindChampion(3, [[0, 1], [1, 2]]).Should().Be(0);
  }

  [Test]
  public void Test2()
  {
    new InDegreeCountSolution2().FindChampion(4, [[0, 2], [1, 3], [1, 2]]).Should().Be(-1);
  }
}
