namespace LeetCode._688._Knight_Probability_in_Chessboard;

public class Solution
{
  private readonly (int, int)[] directions =
  {
    (-1, -2), (-2, -1), (-2, 1), (-1, 2),
    (1, 2), (2, 1), (2, -1), (1, -2)
  };

  private double[][][] cache;

  private double Probability(int n, int row, int column, int k)
  {
    var result = cache[k - 1][row][column];

    if (result != 0)
      return result;

    foreach (var (dr, dc) in directions)
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

    cache[k - 1][row][column] = result;
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
    cache = new double[k][][];
    for (var i = 0; i < k; i++)
    {
      cache[i] = new double[n][];
      for (var j = 0; j < n; j++)
        cache[i][j] = new double[n];
    }
  }
}
