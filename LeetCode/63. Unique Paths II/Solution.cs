namespace LeetCode._63._Unique_Paths_II;

public class Solution
{
  /// <summary>
  /// https://leetcode.com/problems/unique-paths-ii/
  /// </summary>
  /// <remarks>Single array solution.</remarks>
  public int UniquePathsWithObstacles(int[][] obstacleGrid)
  {
    var m = obstacleGrid.Length;
    var n = obstacleGrid[0].Length;

    var dp = new int[n];

    for (var i = 0; i < n && obstacleGrid[0][i] == 0; i++)
      dp[i] = 1;

    for (var i = 1; i < m; i++)
    {
      if (dp[0] != 0 && obstacleGrid[i][0] != 0)
        dp[0] = 0;
      for (var j = 1; j < n; j++)
      {
        if (obstacleGrid[i][j] != 0)
          dp[j] = 0;
        else if (obstacleGrid[i][j - 1] == 0)
          dp[j] += dp[j - 1];
      }
    }
    return dp[n - 1];
  }  
}