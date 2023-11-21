using System.Collections.Generic;

namespace LeetCode._1814._Count_Nice_Pairs_in_an_Array;

public class Solution
{
  public int CountNicePairs(int[] nums)
  {
    const int mod = (int)1e9 + 7;
    var cnt = new Dictionary<int, int>(nums.Length);
    foreach (var num in nums)
    {
      var n = num - Reverse(num);
      cnt[n] = cnt.GetValueOrDefault(n, 0) + 1;
    }
    var ans = 0L;
    foreach (var count in cnt.Values)
    {
      var s = (long)count * (count - 1) / 2;
      ans = (ans + s) % mod;
    }
    return (int)ans;
  }

  private static int Reverse(int n)
  {
    if (n < 10)
      return n;
    var m = 0;
    while (n != 0)
    {
      m = m * 10 + n % 10;
      n /= 10;
    }
    return m;
  }
}