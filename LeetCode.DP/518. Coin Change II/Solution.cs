namespace LeetCode.DP._518._Coin_Change_II;

public class Solution
{
  public int Change(int amount, int[] coins)
  {
    var dp = new int[amount + 1];
    dp[0] = 1;
    foreach (var coin in coins)
    {
      for (var s = coin; s <= amount; s++)
        dp[s] += dp[s - coin];
    }
    return dp[amount];
  }
}