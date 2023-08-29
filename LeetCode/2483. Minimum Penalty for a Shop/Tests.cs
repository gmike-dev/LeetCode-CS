using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._2483._Minimum_Penalty_for_a_Shop;

[TestFixture]
public class Tests
{
  [TestCase("YYNY", 2)]
  [TestCase("NNNNN", 0)]
  [TestCase("YYYY", 4)]
  public void Test(string customers, int expected)
  {
    new Solution().BestClosingTime(customers).Should().Be(expected);
  }
}