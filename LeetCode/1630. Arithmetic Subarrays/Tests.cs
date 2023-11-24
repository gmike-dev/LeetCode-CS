using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._1630._Arithmetic_Subarrays;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 4, 6, 5, 9, 3, 7 }, new[] { 0, 0, 2 }, new[] { 2, 3, 5 }, new[] { true, false, true })]
  [TestCase(new[] { -12, -9, -3, -12, -6, 15, 20, -25, -20, -15, -10 }, new[] { 0, 1, 6, 4, 8, 7 },
    new[] { 4, 4, 9, 7, 9, 10 }, new[] { false, true, false, false, true, true })]
  public void Test(int[] nums, int[] l, int[] r, bool[] expected)
  {
    new Solution().CheckArithmeticSubarrays(nums, l, r).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}