namespace LeetCode.DP._1866._Number_of_Ways_to_Rearrange_Sticks_With_K_Sticks_Visible;

/// <summary>
/// https://leetcode.com/problems/number-of-ways-to-rearrange-sticks-with-k-sticks-visible/
/// </summary>
public class Solution2
{
  private const int Mod = 1_000_000_007;

  public int RearrangeSticks(int n, int k)
  {
    long[] dp = new long[k + 1];
    dp[0] = 1;

    for (int i = 1; i <= n; i++)
    {
      for (int j = k; j >= 1; j--)
      {
        dp[j] = (dp[j - 1] + dp[j] * (i - 1)) % Mod;
      }
      dp[0] = 0;
    }

    return (int)dp[k];
  }
}

[TestFixture]
public class Solution2Tests
{
  [TestCase(3, 2, 3)]
  [TestCase(5, 5, 1)]
  [TestCase(20, 11, 647427950)]
  public void Tests(int n, int k, int expected)
  {
    new Solution2().RearrangeSticks(n, k).Should().Be(expected);
  }
}
