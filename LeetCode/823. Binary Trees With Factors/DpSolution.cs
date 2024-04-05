namespace LeetCode._823._Binary_Trees_With_Factors;

public class DpSolution
{
  public int NumFactoredBinaryTrees(int[] arr)
  {
    const int mod = 1000000007;
    Array.Sort(arr);
    var dp = arr.ToDictionary(x => x, _ => 1);
    var ans = 0;
    for (var i = 0; i < arr.Length; i++)
    {
      var a = arr[i];
      for (var j = 0; j < i; j++)
      {
        var b = arr[j];
        if (a % b == 0 && dp.TryGetValue(a / b, out var ab))
          dp[a] = (int)((dp[a] + (long)dp[b] * ab) % mod);
      }
      ans = (ans + dp[a]) % mod;
    }
    return ans;
  }
}
