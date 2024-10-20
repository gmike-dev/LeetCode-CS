namespace LeetCode.DP._62._Unique_Paths;

public class Solution
{
  public int UniquePaths(int m, int n)
  {
    return (int)Combinations(n + m - 2, Math.Min(n - 1, m - 1));
  }

  private static long Combinations(int n, int k)
  {
    if (k < 0 || k > n)
      return 0;

    if (k > n - k)
      k = n - k;

    var c = 1L;
    for (var i = 0; i < k; i++)
    {
      c *= n - i;
      c /= i + 1;
    }
    return c;
  }
}
