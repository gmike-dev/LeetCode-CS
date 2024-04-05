namespace LeetCode._1359._Count_All_Valid_Pickup_and_Delivery_Options;

[TestFixture]
public class Tests
{
  [TestCase(1, 1)]
  [TestCase(2, 6)]
  [TestCase(3, 90)]
  public void Test(int n, int expected)
  {
    new Solution().CountOrders(n).Should().Be(expected);
    new SolutionUsingRecursion().CountOrders(n).Should().Be(expected);
  }
}
