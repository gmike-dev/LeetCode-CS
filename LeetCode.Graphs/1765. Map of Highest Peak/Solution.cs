namespace LeetCode.Graphs._1765._Map_of_Highest_Peak;

public class Solution
{
  public int[][] HighestPeak(int[][] isWater)
  {
    var n = isWater.Length;
    var m = isWater[0].Length;
    var height = new int[n][];
    for (var i = 0; i < n; i++)
    {
      height[i] = new int[m];
      height[i].AsSpan().Fill(-1);
    }
    var q = new Queue<(int, int)>();
    for (var i = 0; i < n; i++)
    {
      for (var j = 0; j < m; j++)
      {
        if (isWater[i][j] != 0)
        {
          height[i][j] = 0;
          q.Enqueue((i, j));
        }
      }
    }
    Span<int> d = [0, 1, 0, -1, 0];
    var distanceFromWater = 1;
    while (q.Count != 0)
    {
      var queueSize = q.Count;
      for (var i = 0; i < queueSize; i++)
      {
        var (r, c) = q.Dequeue();
        for (var j = 0; j < 4; j++)
        {
          var nr = r + d[j];
          var nc = c + d[j + 1];
          if (nr < 0 || nr >= n || nc < 0 || nc >= m || height[nr][nc] != -1)
            continue;
          height[nr][nc] = distanceFromWater;
          q.Enqueue((nr, nc));
        }
      }
      distanceFromWater++;
    }
    return height;
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().HighestPeak(
      [
        [0, 1],
        [0, 0]
      ])
      .Should()
      .BeEquivalentTo((int[][])
      [
        [1, 0],
        [2, 1]
      ], o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new Solution().HighestPeak(
      [
        [0, 0, 1],
        [1, 0, 0],
        [0, 0, 0]
      ])
      .Should()
      .BeEquivalentTo((int[][])
      [
        [1, 1, 0],
        [0, 1, 1],
        [1, 2, 2]
      ], o => o.WithStrictOrdering());
  }
}
