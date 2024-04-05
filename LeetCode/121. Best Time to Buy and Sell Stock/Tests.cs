namespace LeetCode._121._Best_Time_to_Buy_and_Sell_Stock;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 7, 1, 5, 3, 6, 4 }, 5)]
  [TestCase(new[] { 7, 6, 4, 3, 1 }, 0)]
  public void Test1(int[] prices, int expected)
  {
    new Solution().MaxProfit(prices).Should().Be(expected);
  }
}
