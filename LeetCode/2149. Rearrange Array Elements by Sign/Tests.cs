using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._2149._Rearrange_Array_Elements_by_Sign;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 3, 1, -2, -5, 2, -4 }, new[] { 3, -2, 1, -5, 2, -4 })]
  [TestCase(new[] { -1, 1 }, new[] { 1, -1 })]
  [TestCase(new[] { -1, -1, 1, 1 }, new[] { 1, -1, 1, -1 })]
  [TestCase(new[] { 1, 1, -1, -1 }, new[] { 1, -1, 1, -1 })]
  [TestCase(new[] { -1, 1, -1, 1 }, new[] { 1, -1, 1, -1 })]
  [TestCase(new[] { -1, 1, 1, -1 }, new[] { 1, -1, 1, -1 })]
  [TestCase(new[] { 1, 2, -3, -4 }, new[] { 1, -3, 2, -4 })]
  [TestCase(new[] { -1, -2, 3, 4 }, new[] { 3, -1, 4, -2 })]
  public void Test(int[] nums, int[] expected)
  {
    new TwoArraysSolution().RearrangeArray(nums).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
    new TwoPointersSolution().RearrangeArray(nums).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
    new TwoPointersSolution2().RearrangeArray(nums).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
