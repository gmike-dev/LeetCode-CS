namespace LeetCode.Graphs._1368._Minimum_Cost_to_Make_at_Least_One_Valid_Path_in_a_Grid;

public class BfsSolution2
{
  public int MinCost(int[][] grid)
  {
    var n = grid.Length;
    var m = grid[0].Length;
    Span<int> minCost = stackalloc int[n * m];
    minCost.Fill(n * m);
    minCost[0] = 0;
    Span<int> dr = [0, 0, 1, -1];
    Span<int> dc = [1, -1, 0, 0];
    var deque = new Deque<int>(n * m);
    deque.PushFront(0);
    while (deque.Count != 0)
    {
      var pos = deque.PopFront();
      var (row, col) = (pos / m, pos % m);
      for (var i = 0; i < 4; i++)
      {
        var nextRow = row + dr[i];
        var nextCol = col + dc[i];
        if (nextRow < 0 || nextRow >= n || nextCol < 0 || nextCol >= m)
          continue;
        var cost = grid[row][col] == i + 1 ? 0 : 1;
        var newCost = minCost[pos] + cost;
        var nextPos = m * nextRow + nextCol;
        if (newCost >= minCost[nextPos])
          continue;
        minCost[nextPos] = newCost;
        if (cost == 0)
          deque.PushFront(nextPos);
        else
          deque.PushBack(nextPos);
      }
    }
    return minCost[^1];
  }

  private class Deque<T>(int size)
  {
    private readonly T[] buffer = new T[size];
    private int start;

    public int Count { get; private set; }

    public void PushBack(T item)
    {
      buffer[(start + Count) % size] = item;
      Count++;
    }

    public void PushFront(T item)
    {
      start = (size + start - 1) % size;
      Count++;
      buffer[start] = item;
    }

    public T PopFront()
    {
      var result = buffer[start];
      start = (start + 1) % size;
      Count--;
      return result;
    }
  }
}

[TestFixture]
public class Solution2Tests
{
  [Test]
  public void Test1()
  {
    new BfsSolution2().MinCost([[1, 1, 1, 1], [2, 2, 2, 2], [1, 1, 1, 1], [2, 2, 2, 2]]).Should().Be(3);
  }

  [Test]
  public void Test2()
  {
    new BfsSolution2().MinCost([[1, 1, 3], [3, 2, 2], [1, 1, 4]]).Should().Be(0);
  }

  [Test]
  public void Test3()
  {
    new BfsSolution2().MinCost([[1, 2], [4, 3]]).Should().Be(1);
  }

  [Test]
  public void Test4()
  {
    new BfsSolution2().MinCost([
      [3, 4, 3], [2, 2, 2], [2, 1, 1], [4, 3, 2], [2, 1, 4], [2, 4, 1], [3, 3, 3], [1, 4, 2], [2, 2, 1], [2, 1, 1],
      [3, 3, 1], [4, 1, 4], [2, 1, 4], [3, 2, 2], [3, 3, 1], [4, 4, 1], [1, 2, 2], [1, 1, 1], [1, 3, 4], [1, 2, 1],
      [2, 2, 4], [2, 1, 3], [1, 2, 1], [4, 3, 2], [3, 3, 4], [2, 2, 1], [3, 4, 3], [4, 2, 3], [4, 4, 4]
    ]).Should().Be(18);
  }
}
