namespace LeetCode.__Monotonic._1475._Final_Prices_With_a_Special_Discount_in_a_Shop;

public class MonotonicStackSolution
{
  public int[] FinalPrices(int[] prices)
  {
    var n = prices.Length;
    var result = new int[n];
    prices.AsSpan().CopyTo(result);
    var stack = new Stack<int>(n);
    for (var i = 0; i < n; i++)
    {
      while (stack.TryPeek(out var j) && prices[j] >= prices[i])
      {
        result[j] -= prices[i];
        stack.Pop();
      }
      stack.Push(i);
    }
    return result;
  }
}

[TestFixture]
public class MonotonicStackSolutionTests
{
  [TestCase(new[] { 8, 4, 6, 2, 3 }, new[] { 4, 2, 4, 2, 3 })]
  [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2, 3, 4, 5 })]
  [TestCase(new[] { 10, 1, 1, 6 }, new[] { 9, 0, 1, 6 })]
  public void Test(int[] prices, int[] expected)
  {
    new MonotonicStackSolution().FinalPrices(prices)
      .Should()
      .BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
