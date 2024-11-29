namespace LeetCode.Graphs._2290._Minimum_Obstacle_Removal_to_Reach_Corner;

public class LinearDequeSolution2
{
  public int MinimumObstacles(int[][] grid)
  {
    var m = grid.Length;
    var n = grid[0].Length;
    var size = m * n;
    Span<int> d = [0, 1, 0, -1, 0];
    Span<int> cost = stackalloc int[size];
    Span<int> deque = stackalloc int[size];
    cost[1..].Fill(-1);
    var dequeStart = 0;
    var dequeSize = 1;
    while (dequeSize != 0)
    {
      var p = deque[dequeStart];
      dequeStart = (dequeStart + 1) % size;
      dequeSize--;
      var (r, c) = (p / n, p % n);
      for (var i = 0; i < 4; i++)
      {
        var (nr, nc) = (r + d[i], c + d[i + 1]);
        if (nr < 0 || nr >= m || nc < 0 || nc >= n)
          continue;
        var np = nr * n + nc;
        if (cost[np] == -1)
        {
          var value = grid[nr][nc];
          cost[np] = cost[p] + value;
          if (value == 0)
          {
            dequeStart = (size + dequeStart - 1) % size;
            deque[dequeStart] = np;
          }
          else
          {
            deque[(dequeStart + dequeSize) % size] = np;
          }
          dequeSize++;
        }
      }
    }
    return cost[^1];
  }
}

[TestFixture]
public class LinearDequeSolution2Tests
{
  [Test]
  public void Test1()
  {
    new LinearDequeSolution2().MinimumObstacles([
      [0, 1, 1],
      [1, 1, 0],
      [1, 1, 0]
    ]).Should().Be(2);
  }

  [Test]
  public void Test2()
  {
    new LinearDequeSolution2().MinimumObstacles([
      [0, 1, 0, 0, 0],
      [0, 1, 0, 1, 0],
      [0, 0, 0, 1, 0]
    ]).Should().Be(0);
  }
}
