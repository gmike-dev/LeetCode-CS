namespace LeetCode._63._Unique_Paths_II;

public class SolutionClassicDp
{
  public int UniquePathsWithObstacles(int[][] obstacleGrid)
  {
    var m = obstacleGrid.Length;
    var n = obstacleGrid[0].Length;

    var d = new int[m, n];

    for (var i = 0; i < n && obstacleGrid[0][i] == 0; i++)
      d[0, i] = 1;
    for (var i = 0; i < m && obstacleGrid[i][0] == 0; i++)
      d[i, 0] = 1;

    for (var i = 1; i < m; i++)
    {
      for (var j = 1; j < n; j++)
      {
        if (obstacleGrid[i][j] == 0)
        {
          if (obstacleGrid[i - 1][j] == 0)
            d[i, j] += d[i - 1, j];
          if (obstacleGrid[i][j - 1] == 0)
            d[i, j] += d[i, j - 1];
        }
      }
    }
    return d[m - 1, n - 1];
  }

}