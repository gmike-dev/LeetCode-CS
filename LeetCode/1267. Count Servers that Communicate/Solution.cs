namespace LeetCode._1267._Count_Servers_that_Communicate;

public class Solution
{
  public int CountServers(int[][] grid)
  {
    var n = grid.Length;
    var m = grid[0].Length;
    Span<int> row = stackalloc int[n];
    Span<int> col = stackalloc int[m];
    var count = 0;
    for (var i = 0; i < n; i++)
    {
      for (var j = 0; j < m; j++)
      {
        var value = grid[i][j];
        row[i] += value;
        col[j] += value;
      }
      count += row[i];
    }
    for (var i = 0; i < n; i++)
    {
      for (var j = 0; j < m; j++)
      {
        if (grid[i][j] != 0 && row[i] == 1 && col[j] == 1)
          count--;
      }
    }
    return count;
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().CountServers([[1, 0], [0, 1]]).Should().Be(0);
  }

  [Test]
  public void Test2()
  {
    new Solution().CountServers([[1, 0], [1, 1]]).Should().Be(3);
  }

  [Test]
  public void Test3()
  {
    new Solution().CountServers([[1, 1, 0, 0], [0, 0, 1, 0], [0, 0, 1, 0], [0, 0, 0, 1]]).Should().Be(4);
  }
}
