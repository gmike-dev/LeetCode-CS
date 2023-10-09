using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._34._Find_First_and_Last_Position;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 5, 7, 7, 8, 8, 10 }, 8, new[] { 3, 4 })]
  [TestCase(new[] { 5, 7, 7, 8, 8, 10 }, 6, new[] { -1, -1 })]
  [TestCase(new int[0], 0, new[] { -1, -1 })]
  public void Test(int[] nums, int target, int[] expected)
  {
    new Solution().SearchRange(nums, target).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}