using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._135._Candy;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 1, 0, 2 }, 5)]
  [TestCase(new[] { 1, 2, 2 }, 4)]
  [TestCase(new[] { 2 }, 1)]
  [TestCase(new[] { 1, 6, 10, 8, 7, 3, 2 }, 18)]
  [TestCase(new[] { 1, 3, 4, 5, 2 }, 11)]
  [TestCase(new[] { 4, 2, 3, 4, 1 }, 9)]
  public void Test(int[] ratings, int expected)
  {
    new Solution().Candy(ratings).Should().Be(expected);
  }
}