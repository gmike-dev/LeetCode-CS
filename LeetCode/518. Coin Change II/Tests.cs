using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._518._Coin_Change_II;

[TestFixture]
public class Tests
{
  [TestCase(5, new[] { 1, 2, 5 }, 4)]
  [TestCase(3, new[] { 2 }, 0)]
  [TestCase(10, new[] { 10 }, 1)]
  [TestCase(0, new[] { 1, 2, 5 }, 1)]
  [TestCase(500, new[] { 1, 2, 5 }, 12701)]
  public void Test1(int amount, int[] coins, int expected)
  {
    new Solution().Change(amount, coins).Should().Be(expected);
    new SolutionWithMemoization().Change(amount, coins).Should().Be(expected);
    new SolutionWithSimpleDp().Change(amount, coins).Should().Be(expected);
  }
}