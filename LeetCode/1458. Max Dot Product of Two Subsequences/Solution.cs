using System;
using System.Linq;

namespace LeetCode._1458._Max_Dot_Product_of_Two_Subsequences;

public class Solution
{
  public int MaxDotProduct(int[] a, int[] b)
  {
    var aMax = a.Max();
    var bMin = b.Min();
    if (aMax < 0 && bMin > 0)
      return aMax * bMin;
    var aMin = a.Min();
    var bMax = b.Max();
    if (aMin > 0 && bMax < 0)
      return aMin * bMax;
    var n = a.Length;
    var m = b.Length;
    var dp = new int[n + 1, m + 1];
    for (var i = 1; i <= n; i++)
    for (var j = 1; j <= m; j++)
      dp[i, j] = Math.Max(a[i - 1] * b[j - 1] + dp[i - 1, j - 1], Math.Max(dp[i - 1, j], dp[i, j - 1]));
    return dp[n, m];
  }
}