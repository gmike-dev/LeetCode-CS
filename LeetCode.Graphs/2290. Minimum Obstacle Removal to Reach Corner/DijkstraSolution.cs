namespace LeetCode.Graphs._2290._Minimum_Obstacle_Removal_to_Reach_Corner;

public class DijkstraSolution
{
  public int MinimumObstacles(int[][] grid)
  {
    Span<int> dr = [-1, 1, 0, 0];
    Span<int> dc = [0, 0, -1, 1];
    var m = grid.Length;
    var n = grid[0].Length;
    var costs = new int[m][];
    for (var i = 0; i < m; i++)
    {
      costs[i] = new int[n];
      costs[i].AsSpan().Fill(int.MaxValue);
    }
    costs[0][0] = 0;
    var q = new PriorityQueue<(int, int), int>();
    q.Enqueue((0, 0), 0);
    while (q.TryDequeue(out var p, out var cost))
    {
      var (r, c) = p;
      if (cost != costs[r][c])
        continue;
      for (var i = 0; i < 4; i++)
      {
        var nr = r + dr[i];
        var nc = c + dc[i];
        if (nr < 0 || nr >= m || nc < 0 || nc >= n)
          continue;
        var nCost = cost + grid[nr][nc];
        if (nCost < costs[nr][nc])
        {
          costs[nr][nc] = nCost;
          q.Enqueue((nr, nc), nCost);
        }
      }
    }
    return costs[m - 1][n - 1];
  }
}

[TestFixture]
public class DijkstraSolutionTests
{
  [Test]
  public void Test1()
  {
    new DijkstraSolution().MinimumObstacles([
      [0, 1, 1],
      [1, 1, 0],
      [1, 1, 0]
    ]).Should().Be(2);
  }

  [Test]
  public void Test2()
  {
    new DijkstraSolution().MinimumObstacles([
      [0, 1, 0, 0, 0],
      [0, 1, 0, 1, 0],
      [0, 0, 0, 1, 0]
    ]).Should().Be(0);
  }
}
