namespace LeetCode.DP._1335._Minimum_Difficulty_of_a_Job_Schedule;

public class DpSolution
{
  public int MinDifficulty(int[] jobDifficulty, int n)
  {
    var m = jobDifficulty.Length;
    if (n > m)
      return -1;

    const int inf = (int)1e6;

    var dp = new int[m];
    dp[m - 1] = jobDifficulty[m - 1];
    for (var j = m - 2; j >= 0; j--)
      dp[j] = Math.Max(dp[j + 1], jobDifficulty[j]);

    var tmp = new int[m];
    for (var i = 2; i <= n; i++)
    {
      Array.Fill(tmp, inf);
      for (var j = 0; j <= m - i; j++)
      {
        var maxDifficulty = 0;
        for (var k = j; k <= m - i; k++)
        {
          maxDifficulty = Math.Max(maxDifficulty, jobDifficulty[k]);
          tmp[j] = Math.Min(tmp[j], maxDifficulty + dp[k + 1]);
        }
      }
      (tmp, dp) = (dp, tmp);
    }
    return dp[0];
  }
}
