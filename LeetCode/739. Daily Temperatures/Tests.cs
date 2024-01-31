using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._739._Daily_Temperatures;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 73, 74, 75, 71, 69, 72, 76, 73 }, new[] { 1, 1, 4, 2, 1, 1, 0, 0 })]
  [TestCase(new[] { 30, 40, 50, 60 }, new[] { 1, 1, 1, 0 })]
  [TestCase(new[] { 30, 60, 90 }, new[] { 1, 1, 0 })]
  public void Test(int[] temperatures, int[] expected)
  {
    new Solution().DailyTemperatures(temperatures)
      .Should()
      .BeEquivalentTo(expected, o => o.WithStrictOrdering());
    new StackSolution().DailyTemperatures(temperatures)
      .Should()
      .BeEquivalentTo(expected, o => o.WithStrictOrdering());
    new BestSolution().DailyTemperatures(temperatures)
      .Should()
      .BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}