using System;

namespace LeetCode._1155._Number_of_Dice_Rolls_With_Target_Sum;

public class SolutionUsingDp
{
  public int NumRollsToTarget(int n, int k, int target)
  {
    if (n == 1)
      return target <= k ? 1 : 0;
    const int mod = (int)1e9 + 7;
    var dp = new int[n + 1, target + 1];
    for (var i = 1; i <= Math.Min(k, target); i++)
      dp[1, i] = 1;
    for (var i = 1; i < n; i++)
    {
      for (var s = 1; s <= target; s++)
      {
        for (var d = 1; d <= k && s + d <= target; d++)
          dp[i + 1, s + d] = (dp[i + 1, s + d] + dp[i, s]) % mod;
      }
    }
    return dp[n, target];
  }
}