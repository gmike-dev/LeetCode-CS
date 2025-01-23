namespace LeetCode._1267._Count_Servers_that_Communicate;

public class Solution2
{
  public int CountServers(int[][] grid)
  {
    var n = grid.Length;
    var m = grid[0].Length;
    Span<int> onlyServerInRow = stackalloc int[n];
    onlyServerInRow.Fill(-1);
    Span<int> colCount = stackalloc int[m];
    var totalServersCount = 0;
    for (var i = 0; i < n; i++)
    {
      var rowCount = 0;
      var lastCol = 0;
      for (var j = 0; j < m; j++)
      {
        if (grid[i][j] == 0)
          continue;
        rowCount++;
        colCount[j]++;
        lastCol = j;
      }
      if (rowCount == 1)
        onlyServerInRow[i] = lastCol;
      totalServersCount += rowCount;
    }
    for (var i = 0; i < n; i++)
    {
      if (onlyServerInRow[i] != -1 && colCount[onlyServerInRow[i]] == 1)
        totalServersCount--;
    }
    return totalServersCount;
  }
}

[TestFixture]
public class Solution2Tests
{
  [Test]
  public void Test1()
  {
    new Solution2().CountServers([[1, 0], [0, 1]]).Should().Be(0);
  }

  [Test]
  public void Test2()
  {
    new Solution2().CountServers([[1, 0], [1, 1]]).Should().Be(3);
  }

  [Test]
  public void Test3()
  {
    new Solution2().CountServers([[1, 1, 0, 0], [0, 0, 1, 0], [0, 0, 1, 0], [0, 0, 0, 1]]).Should().Be(4);
  }
}
