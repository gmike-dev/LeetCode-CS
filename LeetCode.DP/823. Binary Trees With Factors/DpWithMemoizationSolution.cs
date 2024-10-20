namespace LeetCode.DP._823._Binary_Trees_With_Factors;

public class DpWithMemoizationSolution
{
  public int NumFactoredBinaryTrees(int[] arr)
  {
    Array.Sort(arr);
    const int mod = 1000000007;
    var nums = arr.ToHashSet();
    var dp = new Dictionary<int, int>();
    var ans = 0;
    for (var i = arr.Length - 1; i >= 0; i--)
      ans = (ans + F(arr[i])) % mod;
    return ans;

    int F(int k)
    {
      if (dp.TryGetValue(k, out var count))
        return count;
      count = 1;
      for (var i = 0; i < arr.Length && arr[i] * arr[i] <= k; i++)
      {
        var a = arr[i];
        if (k % a != 0)
          continue;
        var b = k / arr[i];
        if (a == b || nums.Contains(b))
        {
          var mul = a == b ? 1L : 2L;
          count = (int)((count + mul * F(a) * F(b)) % mod);
        }
      }
      dp[k] = count;
      return count;
    }
  }
}
