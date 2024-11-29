namespace LeetCode.Graphs._2577._Minimum_Time_to_Visit_a_Cell_In_a_Grid;

public class Solution
{
  public int MinimumTime(int[][] grid)
  {
    if (grid[0][1] > 1 && grid[1][0] > 1)
      return -1;
    Span<int> d = [0, 1, 0, -1, 0];
    var m = grid.Length;
    var n = grid[0].Length;
    Span<bool> visited = stackalloc bool[m * n];
    visited[0] = true;
    var q = new PriorityQueue<int, int>();
    q.Enqueue(0, 0);
    while (q.TryDequeue(out var p, out var time))
    {
      var (r, c) = (p / n, p % n);
      for (var i = 0; i < 4; i++)
      {
        var (nr, nc) = (r + d[i], c + d[i + 1]);
        if (nr < 0 || nr >= m || nc < 0 || nc >= n)
          continue;
        var np = nr * n + nc;
        if (visited[np])
          continue;
        var waitTime = 1 - (grid[nr][nc] - time) % 2;
        var nextTime = Math.Max(grid[nr][nc] + waitTime, time + 1);
        if (np == visited.Length - 1)
          return nextTime;
        visited[np] = true;
        q.Enqueue(np, nextTime);
      }
    }
    return -1;
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().MinimumTime([[0, 1, 3, 2], [5, 1, 2, 5], [4, 3, 8, 6]]).Should().Be(7);
  }

  [Test]
  public void Test2()
  {
    new Solution().MinimumTime([[0, 2, 4], [3, 2, 1], [1, 0, 4]]).Should().Be(-1);
  }
}
