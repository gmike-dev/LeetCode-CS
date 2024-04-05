namespace LeetCode._1387._Sort_Integers_by_The_Power_Value;

public class Solution
{
  public int GetKth(int lo, int hi, int k)
  {
    return Enumerable.Range(lo, hi - lo + 1)
      .Select(n => (Power(n), n))
      .OrderBy(x => x)
      .Take(k)
      .Last().n;
  }

  private static int Power(int n)
  {
    var power = 0;
    while (n != 1)
    {
      if ((n & 1) == 0)
        n >>= 1;
      else
        n = 3 * n + 1;
      power++;
    }
    return power;
  }
}
