namespace LeetCode._1335._Minimum_Difficulty_of_a_Job_Schedule;

public class RecursiveSolution
{
  private int[][] dp;

  public int MinDifficulty(int[] jobDifficulty, int n)
  {
    var m = jobDifficulty.Length;
    if (n > m)
      return -1;
    dp = new int[n + 1][];
    for (var i = 0; i <= n; i++)
    {
      dp[i] = new int[m + 1];
      Array.Fill(dp[i], -1);
    }
    return F(jobDifficulty, n, m, 0, 0);
  }

  private int F(int[] jobDifficulty, int n, int m, int day, int job)
  {
    if (dp[day][job] != -1)
      return dp[day][job];

    var maxDifficulty = 0;
    if (day == n - 1)
    {
      for (var i = job; i < m; i++)
        maxDifficulty = Math.Max(maxDifficulty, jobDifficulty[i]);
      dp[day][job] = maxDifficulty;
    }
    else
    {
      var daysLeft = n - day - 1;
      var minSum = int.MaxValue;
      for (var i = job; i < m - daysLeft; i++)
      {
        maxDifficulty = Math.Max(maxDifficulty, jobDifficulty[i]);
        minSum = Math.Min(minSum, maxDifficulty + F(jobDifficulty, n, m, day + 1, i + 1));
      }
      dp[day][job] = minSum;
    }
    return dp[day][job];
  }
}
