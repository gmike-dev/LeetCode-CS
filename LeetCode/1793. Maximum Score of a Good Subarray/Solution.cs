using System;

namespace LeetCode._1793._Maximum_Score_of_a_Good_Subarray;

public class Solution
{
  public int MaximumScore(int[] a, int k)
  {
    var n = a.Length;
    var l = k;
    var r = k;
    var ans = a[k];
    var min = a[k];
    while (l >= 0 || r < n)
    {
      if (l == 0)
      {
        for (r++; r < n; r++)
        {
          min = Math.Min(min, a[r]);
          ans = Math.Max(ans, (r - l + 1) * min);
        }
        break;
      }
      if (r == n - 1)
      {
        for (l--; l >= 0; l--)
        {
          min = Math.Min(min, a[l]);
          ans = Math.Max(ans, (r - l + 1) * min);
        }
        break;
      }
      if (a[l - 1] >= a[r + 1])
      {
        l--;
        min = Math.Min(min, a[l]);
      }
      else if (a[l - 1] < a[r + 1])
      {
        r++;
        min = Math.Min(min, a[r]);
      }
      ans = Math.Max(ans, (r - l + 1) * min);
    }
    return ans;
  }
}