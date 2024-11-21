using System.Runtime.CompilerServices;

namespace LeetCode._2257._Count_Unguarded_Cells_in_the_Grid;

public class Solution2
{
  public int CountUnguarded(int m, int n, int[][] guards, int[][] walls)
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    int Index(int row, int col) => row * n + col;

    Span<int> grid = stackalloc int[m * n];
    foreach (var g in guards)
      grid[Index(g[0], g[1])] = 2;
    foreach (var w in walls)
      grid[Index(w[0], w[1])] = 3;
    for (var i = 0; i < m; i++)
    {
      var prev = 0;
      for (var j = 0; j < n; j++)
      {
        if (grid[Index(i, j)] > 1)
          prev = grid[Index(i, j)];
        else if (prev == 2)
          grid[Index(i, j)] = 1;
      }
    }
    for (var j = 0; j < n; j++)
    {
      var prev = 0;
      for (var i = 0; i < m; i++)
      {
        if (grid[Index(i, j)] > 1)
          prev = grid[Index(i, j)];
        else if (prev == 2)
          grid[Index(i, j)] = 1;
      }
    }
    for (var j = 0; j < n; j++)
    {
      var prev = 0;
      for (var i = m - 1; i >= 0; i--)
      {
        if (grid[Index(i, j)] > 1)
          prev = grid[Index(i, j)];
        else if (prev == 2)
          grid[Index(i, j)] = 1;
      }
    }
    for (var i = 0; i < m; i++)
    {
      var prev = 0;
      for (var j = n - 1; j >= 0; j--)
      {
        if (grid[Index(i, j)] > 1)
          prev = grid[Index(i, j)];
        else if (prev == 2)
          grid[Index(i, j)] = 1;
      }
    }
    var count = 0;
    for (var i = 0; i < m; i++)
    {
      for (var j = 0; j < n; j++)
      {
        if (grid[Index(i, j)] == 0)
          count++;
      }
    }
    return count;
  }
}

[TestFixture]
public class Solution2Tests
{
  [Test]
  public void Test1()
  {
    new Solution2().CountUnguarded(4, 6, [[0, 0], [1, 1], [2, 3]], [[0, 1], [2, 2], [1, 4]])
      .Should().Be(7);
  }

  [Test]
  public void Test2()
  {
    new Solution2().CountUnguarded(3, 3, [[1, 1]], [[0, 1], [1, 0], [2, 1], [1, 2]])
      .Should().Be(4);
  }
}
