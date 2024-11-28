namespace LeetCode.Graphs._2290._Minimum_Obstacle_Removal_to_Reach_Corner;

public class LinearSolution
{
  public int MinimumObstacles(int[][] grid)
  {
    var m = grid.Length;
    var n = grid[0].Length;
    var cost = new int[m][];
    for (var i = 0; i < m; i++)
    {
      cost[i] = new int[n];
      cost[i].AsSpan().Fill(-1);
    }
    cost[0][0] = 0;
    Span<int> dir = [0, 1, 0, -1, 0];
    var deque = new LinkedList<(int r, int c)>();
    deque.AddFirst((0, 0));
    while (deque.Count != 0)
    {
      var (r, c) = deque.First.Value;
      deque.RemoveFirst();
      for (var i = 0; i < 4; i++)
      {
        var nr = r + dir[i];
        var nc = c + dir[i + 1];
        if (nr >= 0 && nr < m && nc >= 0 && nc < n && cost[nr][nc] == -1)
        {
          var value = grid[nr][nc];
          cost[nr][nc] = cost[r][c] + value;
          if (value == 0)
            deque.AddFirst((nr, nc));
          else
            deque.AddLast((nr, nc));
        }
      }
    }
    return cost[^1][^1];
  }
}

[TestFixture]
public class LinearSolutionTests
{
  [Test]
  public void Test1()
  {
    new LinearSolution().MinimumObstacles([
      [0, 1, 1],
      [1, 1, 0],
      [1, 1, 0]
    ]).Should().Be(2);
  }

  [Test]
  public void Test2()
  {
    new LinearSolution().MinimumObstacles([
      [0, 1, 0, 0, 0],
      [0, 1, 0, 1, 0],
      [0, 0, 0, 1, 0]
    ]).Should().Be(0);
  }
}
