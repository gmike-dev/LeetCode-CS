using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._446._Arithmetic_Slices_II___Subsequence;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 2, 4, 6, 8, 10 }, 7)]
  [TestCase(new[] { 7, 7, 7, 7, 7 }, 16)]
  [TestCase(new[] { 1, 2, 3, 4, 5, 6 }, 12)]
  public void Test(int[] a, int expected)
  {
    new Solution().NumberOfArithmeticSlices(a).Should().Be(expected);
  }
}