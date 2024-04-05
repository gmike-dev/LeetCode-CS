namespace LeetCode._1814._Count_Nice_Pairs_in_an_Array;

public class Solution
{
  public int CountNicePairs(int[] nums)
  {
    const int mod = (int)1e9 + 7;
    var cnt = new Dictionary<int, int>(nums.Length);
    var ans = 0;
    foreach (var num in nums)
    {
      var n = num - Reverse(num);
      var count = cnt.GetValueOrDefault(n, 0);
      ans = (ans + count) % mod;
      cnt[n] = count + 1;
    }
    return ans;
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
