using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._403._Frog_Jump;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 0, 1, 3, 5, 6, 8, 12, 17 }, true)]
  [TestCase(new[] { 0, 1, 2, 3, 4, 8, 9, 11 }, false)]
  public void Test(int[] stones, bool expected)
  {
    new Solution().CanCross(stones).Should().Be(expected);
    new SolutionUsingDp().CanCross(stones).Should().Be(expected);
  }
}