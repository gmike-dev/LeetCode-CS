namespace LeetCode._63._Unique_Paths_II;

public class Solution
{
  /// <summary>
  /// https://leetcode.com/problems/unique-paths-ii/
  /// </summary>
  /// <remarks>Single array solution.</remarks>
  public int UniquePathsWithObstacles(int[][] obstacleGrid)
  {
    var n = obstacleGrid[0].Length;
    var dp = new int[n];
    dp[0] = 1;
    foreach (var row in obstacleGrid)
    {
      if (row[0] == 1)
        dp[0] = 0;
      for (var j = 1; j < n; j++)
      {
        if (row[j] == 0)
          dp[j] += dp[j - 1];
        else
          dp[j] = 0;
      }
    }
    return dp[n - 1];
  }  
}