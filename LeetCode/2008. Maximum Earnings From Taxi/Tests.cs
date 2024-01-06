using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._2008._Maximum_Earnings_From_Taxi;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().MaxTaxiEarnings(5, new[]
    {
      new[] { 2, 5, 4 },
      new[] { 1, 5, 1 }
    }).Should().Be(7);
  }

  [Test]
  public void Test2()
  {
    new Solution().MaxTaxiEarnings(20, new[]
    {
      new[] { 1, 6, 1 },
      new[] { 3, 10, 2 },
      new[] { 10, 12, 3 },
      new[] { 11, 12, 2 },
      new[] { 12, 15, 2 },
      new[] { 13, 18, 1 }
    }).Should().Be(20);
  }
}