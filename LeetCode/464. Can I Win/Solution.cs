namespace LeetCode._464._Can_I_Win;

public class Solution
{
  public bool CanIWin(int maxChoosableInteger, int desiredTotal)
  {
    if (desiredTotal == 0)
      return true;

    if (maxChoosableInteger * (maxChoosableInteger + 1) / 2 < desiredTotal)
      return false;

    var dp = new int[1 << maxChoosableInteger];
    return GetWinner(1, (1 << maxChoosableInteger) - 1, desiredTotal) == 1;

    int GetWinner(int player, int mask, int target)
    {
      if (dp[mask] != 0)
        return dp[mask];

      if (mask == 0 || target <= 0)
        return dp[mask] = 3 - player;

      for (var number = 1; number <= maxChoosableInteger; number++)
      {
        var m = 1 << (number - 1);
        if ((mask & m) != 0 && GetWinner(3 - player, mask ^ m, target - number) == player)
          return dp[mask] = player;
      }
      return dp[mask] = 3 - player;
    }
  }
}