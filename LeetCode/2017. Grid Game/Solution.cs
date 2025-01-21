namespace LeetCode._2017._Grid_Game;

public class Solution
{
  public long GridGame(int[][] grid)
  {
    var n = grid[0].Length;
    var x = 0L;
    for (var i = 0; i < n; i++)
      x += grid[0][i];
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
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().GridGame([
      [2, 5, 4],
      [1, 5, 1]
    ]).Should().Be(4);
  }

  [Test]
  public void Test2()
  {
    new Solution().GridGame([
      [3, 3, 1],
      [8, 5, 2]
    ]).Should().Be(4);
  }

  [Test]
  public void Test3()
  {
    new Solution().GridGame([
      [1, 3, 1, 15],
      [1, 3, 3, 1]
    ]).Should().Be(7);
  }

  [Test]
  public void Test4()
  {
    new Solution().GridGame([
        [20, 3, 20, 17, 2, 12, 15, 17, 4, 15],
        [20, 10, 13, 14, 15, 5, 2, 3, 14, 3]
      ]).Should()
      .Be(63);
  }
}
