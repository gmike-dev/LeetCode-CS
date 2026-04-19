namespace LeetCode.DP._1866._Number_of_Ways_to_Rearrange_Sticks_With_K_Sticks_Visible;

/// <summary>
/// https://leetcode.com/problems/number-of-ways-to-rearrange-sticks-with-k-sticks-visible/
/// </summary>
public class Solution1
{
  public int RearrangeSticks(int n, int k)
  {
    const int mod = 1_000_000_007;

    long[,] dp = new long[n + 1, k + 1];
    dp[0, 0] = 1;

    for (int i = 1; i <= n; i++)
    {
      for (int j = 1; j <= k; j++)
      {
        long placeTallest = dp[i - 1, j - 1];
        long placeNotTallest = dp[i - 1, j] * (i - 1) % mod;
        dp[i, j] = (placeTallest + placeNotTallest) % mod;
      }
    }

    return (int)dp[n, k];
  }
}

[TestFixture]
public class Solution1Tests
{
  [TestCase(3, 2, 3)]
  [TestCase(5, 5, 1)]
  [TestCase(20, 11, 647427950)]
  public void Tests(int n, int k, int expected)
  {
    new Solution1().RearrangeSticks(n, k).Should().Be(expected);
  }
}
