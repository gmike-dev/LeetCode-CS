using System;
using System.Linq;

namespace LeetCode._2245._Maximum_Trailing_Zeros;

public class SolutionUsingStruct
{
  private struct Zeroes
  {
    private readonly int _twos;
    private readonly int _fives;

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

    public static Zeroes operator +(Zeroes x, Zeroes y) => new(x._twos + y._twos, x._fives + y._fives);
    public static Zeroes operator -(Zeroes x, Zeroes y) => new(x._twos - y._twos, x._fives - y._fives);

    public static implicit operator int(Zeroes x) => Math.Min(x._twos, x._fives);

    private Zeroes(int twos, int fives)
    {
      _twos = twos;
      _fives = fives;
    }

    public Zeroes(int value)
      : this(NumCount(value, 2), NumCount(value, 5))
    {
    }
  }

  public int MaxTrailingZeros(int[][] grid)
  {
    var m = grid.Length;
    var n = grid[0].Length;
    var z = new Zeroes[m, n];
    for (var i = 0; i < m; i++)
    for (var j = 0; j < n; j++)
      z[i, j] = new Zeroes(grid[i][j]);
    var rowSum = new Zeroes[m, n];
    var colSum = new Zeroes[m, n];
    for (var i = 0; i < m; i++)
    {
      rowSum[i, 0] = z[i, 0];
      for (var j = 1; j < n; j++)
        rowSum[i, j] = rowSum[i, j - 1] + z[i, j];
    }
    for (var j = 0; j < n; j++)
    {
      colSum[0, j] = z[0, j];
      for (var i = 1; i < m; i++)
        colSum[i, j] = colSum[i - 1, j] + z[i, j];
    }
    var result = 0;
    for (var i = 0; i < m; i++)
    for (var j = 0; j < n; j++)
    {
      result = Max(result,
        rowSum[i, j] + colSum[i, j] - z[i, j],
        rowSum[i, n - 1] - rowSum[i, j] + colSum[i, j],
        rowSum[i, j] + colSum[m - 1, j] - colSum[i, j],
        rowSum[i, n - 1] - rowSum[i, j] + colSum[m - 1, j] - colSum[i, j] + z[i, j]);
    }
    return result;
  }

  private static int Max(params int[] values) => values.Max();
}