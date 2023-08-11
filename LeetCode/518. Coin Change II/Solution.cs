namespace LeetCode._518._Coin_Change_II;

public class Solution
{
  public int Change(int amount, int[] coins)
  {
    var dp = new int[amount + 1];
    for (var s = 0; s <= amount; s += coins[0])
      dp[s] = 1;
    for (var i = 1; i < coins.Length; i++)
    {
      for (var s = coins[i]; s <= amount; s++)
        dp[s] += dp[s - coins[i]];
    }
    return dp[amount];
  }
}