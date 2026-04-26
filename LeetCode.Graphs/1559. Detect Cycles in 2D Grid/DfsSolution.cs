namespace LeetCode.Graphs._1559._Detect_Cycles_in_2D_Grid;

/// <summary>
/// https://leetcode.com/problems/detect-cycles-in-2d-grid
/// </summary>
public class DfsSolution
{
  public bool ContainsCycle(char[][] grid)
  {
    int m = grid.Length;
    int n = grid[0].Length;
    int[,] time = new int[m, n];
    for (int i = 0; i < m; i++)
    {
      for (int j = 0; j < n; j++)
      {
        if (time[i, j] == 0 && Dfs(i, j, 1))
        {
          return true;
        }
      }
    }
    return false;

    bool Dfs(int row, int col, int t)
    {
      time[row, col] = t;
      Span<int> d = [1, 0, -1, 0, 1];
      for (int i = 0; i < 4; i++)
      {
        int nr = row + d[i];
        int nc = col + d[i + 1];
        if (nr < 0 || nr >= m || nc < 0 || nc >= n || grid[nr][nc] != grid[row][col])
        {
          continue;
        }
        int nt = time[nr, nc];
        if (nt > 0 && nt < t - 1 || nt == 0 && Dfs(nr, nc, t + 1))
        {
          return true;
        }
      }
      return false;
    }
  }
}

[TestFixture]
public class DfsSolutionTests
{
  [Test]
  public void Test1()
  {
    new DfsSolution()
      .ContainsCycle([
        ['a', 'a', 'a', 'a'],
        ['a', 'b', 'b', 'a'],
        ['a', 'b', 'b', 'a'],
        ['a', 'a', 'a', 'a']
      ]).Should()
      .BeTrue();
  }

  [Test]
  public void Test2()
  {
    new DfsSolution()
      .ContainsCycle([
        ['c', 'c', 'c', 'a'],
        ['c', 'd', 'c', 'c'],
        ['c', 'c', 'e', 'c'],
        ['f', 'c', 'c', 'c']
      ]).Should()
      .BeTrue();
  }

  [Test]
  public void Test3()
  {
    new DfsSolution()
      .ContainsCycle([
        ['a', 'b', 'b'],
        ['b', 'z', 'b'],
        ['b', 'b', 'a']
      ]).Should()
      .BeFalse();
  }
}
