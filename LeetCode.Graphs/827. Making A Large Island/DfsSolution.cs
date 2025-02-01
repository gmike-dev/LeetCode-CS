namespace LeetCode.Graphs._827._Making_A_Large_Island;

public class DfsSolution
{
  public int LargestIsland(int[][] grid)
  {
    var n = grid.Length;
    var islandIds = new int[n][];
    for (var i = 0; i < n; i++)
      islandIds[i] = new int[n];
    Span<int> islandSize = stackalloc int[n * n + 1];
    var currentId = 1;
    for (var i = 0; i < n; i++)
    {
      for (var j = 0; j < n; j++)
      {
        if (grid[i][j] == 0 || islandIds[i][j] != 0)
          continue;
        islandSize[currentId] = Dfs(i, j, currentId);
        currentId++;
      }
    }
    var maxIslandSize = 0;
    Span<int> d = [0, 1, 0, -1, 0];
    var connected = new HashSet<int>();
    for (var i = 0; i < n; i++)
    {
      for (var j = 0; j < n; j++)
      {
        if (grid[i][j] != 0)
          continue;
        var size = 1;
        connected.Clear();
        for (var k = 0; k < 4; k++)
        {
          var x = i + d[k];
          var y = j + d[k + 1];
          if (x < 0 || y < 0 || x >= n || y >= n)
            continue;
          var id = islandIds[x][y];
          if (id != 0 && connected.Add(id))
            size += islandSize[id];
        }
        maxIslandSize = Math.Max(maxIslandSize, size);
      }
    }
    return maxIslandSize == 0 ? n * n : maxIslandSize;

    int Dfs(int i, int j, int island)
    {
      if (i < 0 || j < 0 || i >= n || j >= n || grid[i][j] == 0 || islandIds[i][j] != 0)
        return 0;
      islandIds[i][j] = island;
      return Dfs(i - 1, j, island) + Dfs(i + 1, j, island) + Dfs(i, j - 1, island) + Dfs(i, j + 1, island) + 1;
    }
  }
}

[TestFixture]
public class DfsSolutionTests
{
  [Test]
  public void Test1()
  {
    new DfsSolution().LargestIsland([[1, 0], [0, 1]]).Should().Be(3);
  }

  [Test]
  public void Test2()
  {
    new DfsSolution().LargestIsland([[1, 1], [1, 0]]).Should().Be(4);
  }

  [Test]
  public void Test3()
  {
    new DfsSolution().LargestIsland([[1, 1], [1, 1]]).Should().Be(4);
  }

  [Test]
  public void Test4()
  {
    new DfsSolution().LargestIsland([
      [0, 1, 1, 0, 0, 1, 1, 0],
      [0, 1, 1, 0, 0, 1, 0, 0],
      [1, 0, 1, 0, 1, 0, 1, 0],
      [0, 1, 1, 0, 1, 1, 1, 1],
      [1, 0, 0, 0, 0, 0, 0, 1],
      [0, 0, 0, 1, 1, 1, 0, 0],
      [1, 1, 0, 0, 0, 0, 0, 1],
      [0, 0, 0, 1, 0, 1, 0, 1]
    ]).Should().Be(15);
  }

  [Test]
  public void Test5()
  {
    new DfsSolution().LargestIsland([[1]]).Should().Be(1);
  }
}
