namespace LeetCode._1846._Maximum_Element_After_Decreasing;

public class Solution
{
  public int MaximumElementAfterDecrementingAndRearranging(int[] arr)
  {
    var n = arr.Length;
    var cnt = new int[n + 1];
    foreach (var x in arr)
    {
      cnt[Math.Min(n, x)]++;
    }
    var max = 1;
    for (int i = 2; i <= n; i++)
    {
      max = Math.Min(max + cnt[i], i);
    }
    return max;
  }
}
