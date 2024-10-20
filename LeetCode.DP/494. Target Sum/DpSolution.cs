namespace LeetCode.DP._494._Target_Sum;

public class DpSolution
{
  public int FindTargetSumWays(int[] nums, int target)
  {
    var n = nums.Length;
    const int m = 2001;
    const int offset = 1000;
    var dp = new int[n, m];
    dp[0, offset - nums[0]]++;
    dp[0, offset + nums[0]]++;
    for (var i = 1; i < n; i++)
    {
      var num = nums[i];
      for (var j = 0; j < m; j++)
      {
        if (dp[i - 1, j] == 0)
          continue;
        if (j - num >= 0)
          dp[i, j - num] += dp[i - 1, j];
        if (j + num < m)
          dp[i, j + num] += dp[i - 1, j];
      }
    }
    return dp[n - 1, offset + target];
  }
}
