namespace LeetCode._1143._Longest_Common_Subsequence;

public class Solution
{
  public int LongestCommonSubsequence(string a, string b)
  {
    var n = a.Length;
    var m = b.Length;
    var dp = new int[n + 1, m + 1];
    for (var i = 1; i <= n; i++)
    for (var j = 1; j <= m; j++)
      dp[i, j] = a[i - 1] == b[j - 1] ? dp[i - 1, j - 1] + 1 : Math.Max(dp[i, j - 1], dp[i - 1, j]);
    return dp[n, m];
  }
}
