namespace LeetCode.Graphs._407._Trapping_Rain_Water_II;

public class Solution
{
  public int TrapRainWater(int[][] heightMap)
  {
    var n = heightMap.Length;
    var m = heightMap[0].Length;
    var q = new PriorityQueue<(int, int), int>();
    var visited = new bool[n][];
    for (var i = 0; i < n; i++)
      visited[i] = new bool[m];
    for (var i = 0; i < n; i++)
    {
      q.Enqueue((i, 0), heightMap[i][0]);
      q.Enqueue((i, m - 1), heightMap[i][m - 1]);
      visited[i][0] = true;
      visited[i][m - 1] = true;
    }
    for (var j = 0; j < m; j++)
    {
      q.Enqueue((0, j), heightMap[0][j]);
      q.Enqueue((n - 1, j), heightMap[n - 1][j]);
      visited[0][j] = true;
      visited[n - 1][j] = true;
    }
    Span<int> d = [0, 1, 0, -1, 0];
    var volume = 0;
    while (q.Count != 0)
    {
      q.TryDequeue(out var p, out var height);
      var (row, col) = p;
      for (var i = 0; i < 4; i++)
      {
        var nextRow = row + d[i];
        var nextCol = col + d[i + 1];
        if (nextRow < 0 || nextRow >= n || nextCol < 0 || nextCol >= m || visited[nextRow][nextCol])
          continue;
        visited[nextRow][nextCol] = true;
        volume += Math.Max(0, height - heightMap[nextRow][nextCol]);
        q.Enqueue((nextRow, nextCol), Math.Max(heightMap[nextRow][nextCol], height));
      }
    }
    return volume;
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().TrapRainWater([[1, 4, 3, 1, 3, 2], [3, 2, 1, 3, 2, 4], [2, 3, 3, 2, 3, 1]]).Should().Be(4);
  }

  [Test]
  public void Test2()
  {
    new Solution().TrapRainWater([[3, 3, 3, 3, 3], [3, 2, 2, 2, 3], [3, 2, 1, 2, 3], [3, 2, 2, 2, 3], [3, 3, 3, 3, 3]])
      .Should().Be(10);
  }
}
