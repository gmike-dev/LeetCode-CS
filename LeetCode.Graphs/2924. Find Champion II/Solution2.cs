namespace LeetCode.Graphs._2924._Find_Champion_II;

public class Solution2
{
  public int FindChampion(int n, int[][] edges)
  {
    return Enumerable.Range(0, n).Except(edges.Select(e => e[1])).ToArray() is [var winner] ? winner : -1;
  }
}

[TestFixture]
public class Solution2Tests
{
  [Test]
  public void Test1()
  {
    new Solution2().FindChampion(3, [[0, 1], [1, 2]]).Should().Be(0);
  }

  [Test]
  public void Test2()
  {
    new Solution2().FindChampion(4, [[0, 2], [1, 3], [1, 2]]).Should().Be(-1);
  }
}
