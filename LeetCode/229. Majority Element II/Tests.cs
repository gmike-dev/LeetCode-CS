using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._229._Majority_Element_II;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 3, 2, 3 }, new[] { 3 })]
  [TestCase(new[] { 1 }, new[] { 1 })]
  [TestCase(new[] { 1, 2 }, new[] { 1, 2 })]
  [TestCase(new[] { 1, 3, 4, 3, 3, 3, 1, 3, 5, 6, 1, 5, 3, 1, 5, 1, 1 }, new[] { 1, 3 })]
  public void Test(int[] nums, int[] expected)
  {
    new Solution().MajorityElement(nums).Should().BeEquivalentTo(expected);
  }
}