namespace LeetCode.Graphs._2658._Maximum_Number_of_Fish_in_a_Grid;

public class BfsSolution
{
  public int FindMaxFish(int[][] grid)
  {
    var n = grid.Length;
    var m = grid[0].Length;
    var visited = new bool[n, m];
    var maxSum = 0;
    for (var i = 0; i < n; i++)
    {
      for (var j = 0; j < m; j++)
        maxSum = Math.Max(maxSum, Sum(i, j));
    }
    return maxSum;

    int Sum(int row, int col)
    {
      if (visited[row, col] || grid[row][col] == 0)
        return 0;
      Span<int> d = [0, 1, 0, -1, 0];
      var s = 0;
      var q = new Queue<(int, int)>();
      q.Enqueue((row, col));
      visited[row, col] = true;
      while (q.Count != 0)
      {
        var (r, c) = q.Dequeue();
        s += grid[r][c];
        for (var i = 0; i < 4; i++)
        {
          var nr = r + d[i];
          var nc = c + d[i + 1];
          if (nr < 0 || nr >= n || nc < 0 || nc >= m || visited[nr, nc] || grid[nr][nc] == 0)
            continue;
          visited[nr, nc] = true;
          q.Enqueue((nr, nc));
        }
      }
      return s;
    }
  }
}

[TestFixture]
public class BfsSolutionTests
{
  [Test]
  public void Test1()
  {
    new BfsSolution().FindMaxFish([[0, 2, 1, 0], [4, 0, 0, 3], [1, 0, 0, 4], [0, 3, 2, 0]]).Should().Be(7);
  }

  [Test]
  public void Test2()
  {
    new BfsSolution().FindMaxFish([[1, 0, 0, 0], [0, 0, 0, 0], [0, 0, 0, 0], [0, 0, 0, 1]]).Should().Be(1);
  }
}
