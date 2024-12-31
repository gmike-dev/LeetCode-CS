namespace LeetCode.DP._983._Minimum_Cost_For_Tickets;

public class Solution
{
  public int MincostTickets(int[] days, int[] costs)
  {
    Span<int> dp = stackalloc int[days[^1] + 1];
    for (int i = 1, j = 0; i <= days[^1]; i++)
    {
      if (i < days[j])
      {
        dp[i] = dp[i - 1];
      }
      else
      {
        j++;
        dp[i] = Math.Min(dp[i - 1] + costs[0], Math.Min(
          dp[Math.Max(0, i - 7)] + costs[1],
          dp[Math.Max(0, i - 30)] + costs[2]));
      }
    }
    return dp[days[^1]];
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 1, 4, 6, 7, 8, 20 }, new[] { 2, 7, 15 }, 11)]
  [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 30, 31 }, new[] { 2, 7, 15 }, 17)]
  public void Test(int[] days, int[] costs, int expected)
  {
    new Solution().MincostTickets(days, costs).Should().Be(expected);
  }
}
