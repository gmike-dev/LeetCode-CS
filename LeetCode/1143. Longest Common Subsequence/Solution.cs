using System;

namespace LeetCode._1143._Longest_Common_Subsequence;

public class Solution
{
  public int LongestCommonSubsequence(string a, string b)
  {
    var n = a.Length;
    var m = b.Length;
    var dp = new int[n + 1, m + 1];
    for (var i = 0; i < n; i++)
    for (var j = 0; j < m; j++)
      dp[i + 1, j + 1] = a[i] == b[j] ? dp[i, j] + 1 : Math.Max(dp[i + 1, j], dp[i, j + 1]);
    return dp[n, m];
  }
}