namespace LeetCode.DP._1458._Max_Dot_Product_of_Two_Subsequences;

public class SolutionUsingMemoization
{
  private int[,] _cache;

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
    _cache = new int[a.Length, b.Length];
    return Dp(a, b, 0, 0);
  }

  private int Dp(int[] a, int[] b, int i, int j)
  {
    if (i == a.Length || j == b.Length)
      return 0;

    if (_cache[i, j] != 0)
      return _cache[i, j];

    return _cache[i, j] = Max(Dp(a, b, i + 1, j), Dp(a, b, i, j + 1), a[i] * b[j] + Dp(a, b, i + 1, j + 1));
  }

  private int Max(params int[] values) => values.Max();
}
