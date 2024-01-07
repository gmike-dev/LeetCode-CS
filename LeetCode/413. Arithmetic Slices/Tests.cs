using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._413._Arithmetic_Slices;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 1, 2, 3, 4 }, 3)]
  [TestCase(new[] { 1 }, 0)]
  [TestCase(new[] { 1, 2, 3, 4, 5, 6 }, 10)]
  public void Test(int[] a, int expected)
  {
    new Solution().NumberOfArithmeticSlices(a).Should().Be(expected);
  }
}