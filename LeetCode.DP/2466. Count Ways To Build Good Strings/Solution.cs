namespace LeetCode.DP._2466._Count_Ways_To_Build_Good_Strings;

public class Solution
{
  public int CountGoodStrings(int low, int high, int zero, int one)
  {
    const int mod = (int)1e9 + 7;
    var dp = new int[high + 1];
    dp.AsSpan().Fill(-1);
    dp[0] = 1;
    var ans = 0;
    for (var i = low; i <= high; i++)
      ans = (ans + F(i)) % mod;
    return ans;

    int F(int pos)
    {
      if (pos < 0)
        return 0;
      if (dp[pos] != -1)
        return dp[pos];
      return dp[pos] = (F(pos - zero) + F(pos - one)) % mod;
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(3, 3, 1, 1, 8)]
  [TestCase(2, 3, 1, 2, 5)]
  [TestCase(200, 200, 10, 1, 764262396)]
  public void Test(int low, int high, int zero, int one, int expected)
  {
    new Solution().CountGoodStrings(low, high, zero, one).Should().Be(expected);
  }
}
