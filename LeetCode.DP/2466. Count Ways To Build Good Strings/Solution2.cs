namespace LeetCode.DP._2466._Count_Ways_To_Build_Good_Strings;

public class Solution2
{
  public int CountGoodStrings(int low, int high, int zero, int one)
  {
    const int mod = (int)1e9 + 7;
    Span<int> dp = stackalloc int[high + 1];
    dp[0] = 1;
    for (var i = 0; i < high; i++)
    {
      if (dp[i] == 0)
        continue;
      if (i + zero <= high)
        dp[i + zero] = (dp[i + zero] + dp[i]) % mod;
      if (i + one <= high)
        dp[i + one] = (dp[i + one] + dp[i]) % mod;
    }
    var ans = 0;
    for (var i = low; i <= high; i++)
      ans = (ans + dp[i]) % mod;
    return ans;
  }
}

[TestFixture]
public class Solution2Tests
{
  [TestCase(3, 3, 1, 1, 8)]
  [TestCase(2, 3, 1, 2, 5)]
  [TestCase(200, 200, 10, 1, 764262396)]
  public void Test(int low, int high, int zero, int one, int expected)
  {
    new Solution2().CountGoodStrings(low, high, zero, one).Should().Be(expected);
  }
}
