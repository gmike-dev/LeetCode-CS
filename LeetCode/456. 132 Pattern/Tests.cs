using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._456._132_Pattern;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 1, 2, 3, 4 }, false)]
  [TestCase(new[] { 3, 1, 4, 2 }, true)]
  [TestCase(new[] { -1, 3, 2, 0 }, true)]
  [TestCase(new[] { 1, 2, 3, 4, -4, -3, -5, -1 }, false)]
  [TestCase(new[] { -2, 1, 2, -2, 1, 2 }, true)]
  [TestCase(new[] { 2, 4, 3, 1 }, true)]
  public void Test(int[] nums, bool expected)
  {
    new Solution().Find132pattern(nums).Should().Be(expected);
  }
}