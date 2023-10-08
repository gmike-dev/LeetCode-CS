using System;
using System.Linq;

namespace LeetCode._1458._Max_Dot_Product_of_Two_Subsequences;

public class SolutionOptimizedDp
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
    var prev = new int[m + 1];
    var curr = new int[m + 1];
    for (var i = 1; i <= n; i++)
    {
      for (var j = 1; j <= m; j++)
        curr[j] = Math.Max(a[i - 1] * b[j - 1] + prev[j - 1], Math.Max(prev[j], curr[j - 1]));
      (curr, prev) = (prev, curr);
    }
    return prev[m];
  }
}