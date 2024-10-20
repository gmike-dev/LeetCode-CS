namespace LeetCode.DP._1043._Partition_Array_for_Maximum_Sum;

public class RecursiveSolution
{
  public int MaxSumAfterPartitioning(int[] a, int k)
  {
    var n = a.Length;
    var cache = new int[n];
    Array.Fill(cache, -1);
    return F(n - 1);

    int F(int i)
    {
      if (i < 0)
        return 0;
      if (cache[i] != -1)
        return cache[i];
      var maxSum = 0;
      for (int j = 0, m = 0; j < k && i - j >= 0; j++)
      {
        m = Math.Max(m, a[i - j]);
        maxSum = Math.Max(maxSum, F(i - j - 1) + (j + 1) * m);
      }
      cache[i] = maxSum;
      return maxSum;
    }
  }
}
