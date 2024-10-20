namespace LeetCode.DP._446._Arithmetic_Slices_II___Subsequence;

public class Solution
{
  public int NumberOfArithmeticSlices(int[] a)
  {
    var n = a.Length;
    var dp = new Dictionary<long, int>[n];
    for (var i = 0; i < n; i++)
    {
      dp[i] = new();
    }
    var sum = 0;
    for (var i = 1; i < n; i++)
    {
      for (var j = 0; j < i; j++)
      {
        var d = (long)a[i] - a[j];
        var prev = dp[j].GetValueOrDefault(d, 0);
        sum += prev;
        dp[i][d] = prev + dp[i].GetValueOrDefault(d, 0) + 1;
      }
    }
    return sum;
  }
}
