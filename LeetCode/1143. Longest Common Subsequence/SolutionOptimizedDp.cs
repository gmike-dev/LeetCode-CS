using System;

namespace LeetCode._1143._Longest_Common_Subsequence;

public class SolutionOptimizedDp
{
  public int LongestCommonSubsequence(string a, string b)
  {
    var n = a.Length;
    var m = b.Length;
    var dp = new int[m + 1];
    var prevDp = new int[m + 1];
    for (var i = 0; i < n; i++)
    {
      for (var j = 0; j < m; j++)
        dp[j + 1] = a[i] == b[j] ? prevDp[j] + 1 : Math.Max(prevDp[j + 1], dp[j]);
      (dp, prevDp) = (prevDp, dp);
    }
    return prevDp[m];
  }
}