namespace LeetCode._2017._Grid_Game;

public class Solution2
{
  public long GridGame(int[][] grid)
  {
    var n = grid[0].Length;
    var x = FastSum(grid[0]);
    var y = 0L;
    var result = long.MaxValue;
    for (var i = 0; i < n; i++)
    {
      x -= grid[0][i];
      result = Math.Min(result, Math.Max(x, y));
      y += grid[1][i];
    }
    return result;
  }

  private static long FastSum(Span<int> a)
  {
    var n = a.Length;
    var remaining = n % Vector<int>.Count;
    var v = Vector<int>.Zero;
    for (var i = 0; i < n - remaining; i += Vector<int>.Count)
      v += new Vector<int>(a[i..]);
    long s = 0;
    for (var i = 0; i < Vector<int>.Count; i++)
      s += v[i];
    for (var i = n - remaining; i < n; i++)
      s += a[i];
    return s;
  }
}

[TestFixture]
public class Solution2Tests
{
  [Test]
  public void Test1()
  {
    new Solution2().GridGame([
      [2, 5, 4],
      [1, 5, 1]
    ]).Should().Be(4);
  }

  [Test]
  public void Test2()
  {
    new Solution2().GridGame([
      [3, 3, 1],
      [8, 5, 2]
    ]).Should().Be(4);
  }

  [Test]
  public void Test3()
  {
    new Solution2().GridGame([
      [1, 3, 1, 15],
      [1, 3, 3, 1]
    ]).Should().Be(7);
  }

  [Test]
  public void Test4()
  {
    new Solution2().GridGame([
        [20, 3, 20, 17, 2, 12, 15, 17, 4, 15],
        [20, 10, 13, 14, 15, 5, 2, 3, 14, 3]
      ]).Should()
      .Be(63);
  }
}
