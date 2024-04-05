namespace LeetCode._799._Champagne_Tower;

public class Solution
{
  public double ChampagneTower(int poured, int queryRow, int queryGlass)
  {
    var prev = new double[queryRow + 1];
    var next = new double[queryRow + 1];
    prev[0] = poured;
    for (var i = 1; i <= queryRow; i++)
    {
      next.AsSpan().Clear();
      for (var j = 0; j < Math.Min(i, queryGlass + 1); j++)
      {
        if (prev[j] > 1)
        {
          next[j] += (prev[j] - 1) / 2.0;
          next[j + 1] += (prev[j] - 1) / 2.0;
        }
      }
      (prev, next) = (next, prev);
    }
    return Math.Min(1.0, prev[queryGlass]);
  }
}
