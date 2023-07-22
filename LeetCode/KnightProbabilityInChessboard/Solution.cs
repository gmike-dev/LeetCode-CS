namespace LeetCode.KnightProbabilityInChessboard;

public class Solution
{
  private readonly (int, int)[] _directions =
  {
    (-1, -2), (-2, -1), (-2, 1), (-1, 2),
    (1, 2), (2, 1), (2, -1), (1, -2)
  };

  private double[][][] _cache;

  private double Probability(int n, int row, int column, int k)
  {
    var result = _cache[k - 1][row][column];
    
    if (result != 0)
      return result;

    foreach (var (dr, dc) in _directions)
    {
      var nextRow = row + dr;
      var nextColumn = column + dc;
      if (nextRow >= 0 && nextColumn >= 0 && nextRow < n && nextColumn < n)
      {
        if (k == 1)
          result += 1;
        else
          result += Probability(n, nextRow, nextColumn, k - 1);
      }
    }
    result /= 8;
    
    _cache[k - 1][row][column] = result;
    return result;
  }

  public double KnightProbability(int n, int k, int row, int column)
  {
    if (k == 0)
      return 1;

    InitCache(n, k);
    return Probability(n, row, column, k);
  }

  private void InitCache(int n, int k)
  {
    _cache = new double[k][][];
    for (var i = 0; i < k; i++)
    {
      _cache[i] = new double[n][];
      for (var j = 0; j < n; j++)
        _cache[i][j] = new double[n];
    }
  }
}