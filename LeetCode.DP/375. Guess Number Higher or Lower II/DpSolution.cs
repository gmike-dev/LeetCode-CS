namespace LeetCode.DP._375._Guess_Number_Higher_or_Lower_II;

public class DpSolution
{
  public int GetMoneyAmount(int n)
  {
    var dp = new int[n + 2, n + 2]; // +2 for edge cases when m + 1 > n or m - 1 < 1.
    for (var len = 2; len <= n; len++)
    {
      for (var l = 1; l <= n - len + 1; l++)
      {
        var r = l + len - 1;
        dp[l, r] = int.MaxValue;
        for (var m = l; m <= r; m++)
          dp[l, r] = Math.Min(dp[l, r], m + Math.Max(dp[l, m - 1], dp[m + 1, r]));
      }
    }
    return dp[1, n];
  }
}
