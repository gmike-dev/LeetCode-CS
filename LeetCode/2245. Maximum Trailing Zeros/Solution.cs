namespace LeetCode._2245._Maximum_Trailing_Zeros;

public class Solution
{
  public int MaxTrailingZeros(int[][] grid)
  {
    var m = grid.Length;
    var n = grid[0].Length;
    var z = new (int c2, int c5)[m, n];
    for (var i = 0; i < m; i++)
    for (var j = 0; j < n; j++)
    {
      z[i, j] = (NumCount(grid[i][j], 2), NumCount(grid[i][j], 5));
    }
    var rowSum = new (int c2, int c5)[m, n];
    var colSum = new (int c2, int c5)[m, n];
    for (var i = 0; i < m; i++)
    {
      rowSum[i, 0] = z[i, 0];
      for (var j = 1; j < n; j++)
        rowSum[i, j] = (rowSum[i, j - 1].c2 + z[i, j].c2, rowSum[i, j - 1].c5 + z[i, j].c5);
    }
    for (var j = 0; j < n; j++)
    {
      colSum[0, j] = z[0, j];
      for (var i = 1; i < m; i++)
        colSum[i, j] = (colSum[i - 1, j].c2 + z[i, j].c2, colSum[i - 1, j].c5 + z[i, j].c5);
    }
    var result = 0;
    for (var i = 0; i < m; i++)
    for (var j = 0; j < n; j++)
    {
      result = Max(result,
        Math.Min(
          rowSum[i, j].c2 + colSum[i, j].c2 - z[i, j].c2,
          rowSum[i, j].c5 + colSum[i, j].c5 - z[i, j].c5),
        Math.Min(
          rowSum[i, n - 1].c2 - rowSum[i, j].c2 + colSum[i, j].c2,
          rowSum[i, n - 1].c5 - rowSum[i, j].c5 + colSum[i, j].c5),
        Math.Min(
          rowSum[i, j].c2 + colSum[m - 1, j].c2 - colSum[i, j].c2,
          rowSum[i, j].c5 + colSum[m - 1, j].c5 - colSum[i, j].c5),
        Math.Min(
          rowSum[i, n - 1].c2 - rowSum[i, j].c2 + colSum[m - 1, j].c2 - colSum[i, j].c2 + z[i, j].c2,
          rowSum[i, n - 1].c5 - rowSum[i, j].c5 + colSum[m - 1, j].c5 - colSum[i, j].c5 + z[i, j].c5));
    }
    return result;
  }

  private static int Max(params int[] values) => values.Max();

  private static int NumCount(int n, int x)
  {
    var count = 0;
    while (n % x == 0)
    {
      count++;
      n /= x;
    }
    return count;
  }
}
