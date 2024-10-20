namespace LeetCode.DP._1143._Longest_Common_Subsequence;

public class SolutionOptimizedDp
{
  public int LongestCommonSubsequence(string a, string b)
  {
    var n = a.Length;
    var m = b.Length;
    var dp = new int[m + 1];
    var next = new int[m + 1];
    for (var i = 1; i <= n; i++)
    {
      for (var j = 1; j <= m; j++)
        next[j] = a[i - 1] == b[j - 1] ? dp[j - 1] + 1 : Math.Max(dp[j], next[j - 1]);
      (next, dp) = (dp, next);
    }
    return dp[m];
  }
}
