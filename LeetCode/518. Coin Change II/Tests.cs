using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._518._Coin_Change_II;

[TestFixture]
public class Tests
{
  [TestCase(5, new[] { 1, 2, 5 }, 4)]
  [TestCase(3, new[] { 2 }, 0)]
  [TestCase(10, new[] { 10 }, 1)]
  public void Test1(int amount, int[] coins, int expected)
  {
    new Solution().Change(amount, coins).Should().Be(expected);
  }
}