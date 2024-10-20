namespace LeetCode.DP._375._Guess_Number_Higher_or_Lower_II;

public class RecursiveSolution
{
  public int GetMoneyAmount(int n)
  {
    var dp = new int[n + 1, n + 1];
    return Guess(1, n);

    int Guess(int l, int r)
    {
      if (l >= r)
        return 0;
      var result = dp[l, r];
      if (result != 0)
        return result;
      result = int.MaxValue;
      for (var m = l; m <= r; m++)
      {
        var money = m + Math.Max(Guess(l, m - 1), Guess(m + 1, r));
        result = Math.Min(result, money);
      }
      dp[l, r] = result;
      return result;
    }
  }
}
