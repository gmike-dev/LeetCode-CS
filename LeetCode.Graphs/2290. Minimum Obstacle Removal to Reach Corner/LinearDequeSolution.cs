namespace LeetCode.Graphs._2290._Minimum_Obstacle_Removal_to_Reach_Corner;

public class LinearDequeSolution
{
  public int MinimumObstacles(int[][] grid)
  {
    var m = grid.Length;
    var n = grid[0].Length;
    Span<int> cost = stackalloc int[m * n];
    cost.Fill(-1);
    cost[0] = 0;
    Span<int> d = [0, 1, 0, -1, 0];
    var deque = new Deque<int>(m * n);
    deque.PushBack(0);
    while (deque.Count != 0)
    {
      var p = deque.PopFront();
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
            deque.PushFront(np);
          else
            deque.PushBack(np);
        }
      }
    }
    return cost[^1];
  }

  private class Deque<T>(int size)
  {
    private readonly T[] buffer = new T[size];
    private int start;
    private int count;

    public int Count => count;

    public void PushBack(T item)
    {
      buffer[(start + count) % size] = item;
      count++;
    }

    public void PushFront(T item)
    {
      start = (size + start - 1) % size;
      count++;
      buffer[start] = item;
    }

    public T PopFront()
    {
      var result = buffer[start];
      start = (start + 1) % size;
      count--;
      return result;
    }
  }
}

[TestFixture]
public class LinearDequeSolutionTests
{
  [Test]
  public void Test1()
  {
    new LinearDequeSolution().MinimumObstacles([
      [0, 1, 1],
      [1, 1, 0],
      [1, 1, 0]
    ]).Should().Be(2);
  }

  [Test]
  public void Test2()
  {
    new LinearDequeSolution().MinimumObstacles([
      [0, 1, 0, 0, 0],
      [0, 1, 0, 1, 0],
      [0, 0, 0, 1, 0]
    ]).Should().Be(0);
  }
}
