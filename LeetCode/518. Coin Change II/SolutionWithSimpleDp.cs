namespace LeetCode._518._Coin_Change_II;

public class SolutionWithSimpleDp
{
  public int Change(int amount, int[] coins)
  {
    var n = coins.Length;

    var dp = new int[amount + 1][];
    for (var i = 0; i < dp.Length; i++)
      dp[i] = new int[n + 1];

    for (var s = 0; s <= amount; s += coins[0])
      dp[s][0] = 1;

    for (var i = 1; i < n; i++)
    {
      for (var s = 0; s <= amount; s++)
      {
        if (s >= coins[i])
          dp[s][i] = dp[s][i - 1] + dp[s - coins[i]][i];
        else
          dp[s][i] = dp[s][i - 1];
      }
    }
    return dp[amount][n - 1];
  }
}