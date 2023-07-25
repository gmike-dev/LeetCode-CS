using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._162._Find_Peak_Element;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 0, 1, 0 }, 1)]
  [TestCase(new[] { 0, 2, 1, 0 }, 1)]
  [TestCase(new[] { 0, 10, 5, 2 }, 1)]
  [TestCase(new[] { 1, 0, 2, -1, 3, 1 }, 2)]
  [TestCase(new[] { -1, 0, 2, 4, 5, 6 }, 5)]
  public void TestLinear(int[] values, int expected)
  {
    new Solution().FindPeakElement(values).Should().Be(expected);
  }
}