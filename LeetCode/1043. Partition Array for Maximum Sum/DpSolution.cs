namespace LeetCode._1043._Partition_Array_for_Maximum_Sum;

public class DpSolution
{
  public int MaxSumAfterPartitioning(int[] a, int k)
  {
    var n = a.Length;
    var dp = new int[n + 1];
    for (var i = 1; i <= n; i++)
    {
      var m = 0;
      for (var len = 1; len <= k && i - len >= 0; len++)
      {
        m = Math.Max(m, a[i - len]);
        dp[i] = Math.Max(dp[i], dp[i - len] + len * m);
      }
    }
    return dp[n];
  }
}
