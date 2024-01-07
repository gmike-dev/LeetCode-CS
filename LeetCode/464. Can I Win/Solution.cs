namespace LeetCode._464._Can_I_Win;

public class Solution
{
  private int[] dp;

  public bool CanIWin(int maxChoosableInteger, int desiredTotal)
  {
    if (desiredTotal == 0)
      return true;
    var maxSum = maxChoosableInteger * (maxChoosableInteger + 1) / 2;
    if (maxSum < desiredTotal)
      return false;
    dp = new int[1 << maxChoosableInteger];
    return F((1 << maxChoosableInteger) - 1, desiredTotal, 1) == 1;
  }

  private int F(int mask, int target, int player)
  {
    if (mask == 0 || target <= 0)
      return 3 - player;

    if (dp[mask] != 0)
      return dp[mask];

    var number = 0;
    for (var m = mask; m != 0; m >>= 1)
    {
      number++;
      if ((m & 1) == 0)
        continue;
      if (number >= target)
        return dp[mask] = player;
      var nextMask = mask ^ (1 << (number - 1));
      var winner = F(nextMask, target - number, 3 - player);
      if (winner == player)
        return dp[mask] = player;
    }
    return dp[mask] = 3 - player;
  }
}