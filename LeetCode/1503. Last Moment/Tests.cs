using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._1503._Last_Moment;

[TestFixture]
public class Tests
{
  [TestCase(4, new[] { 4, 3 }, new[] { 0, 1 }, 4)]
  [TestCase(7, new int[] { }, new[] { 0, 1, 2, 3, 4, 5, 6, 7 }, 7)]
  [TestCase(7, new[] { 0, 1, 2, 3, 4, 5, 6, 7 }, new int[] { }, 7)]
  [TestCase(9, new[] { 5 }, new [] { 4 }, 5)]
  [TestCase(1000, new[] { 0 }, new int[] { }, 0)]
  public void Test(int n, int[] left, int[] right, int expected)
  {
    new FirstSolution().GetLastMoment(n, left, right).Should().Be(expected);
    new Solution().GetLastMoment(n, left, right).Should().Be(expected);
  }
}