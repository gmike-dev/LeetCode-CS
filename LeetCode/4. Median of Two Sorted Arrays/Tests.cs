using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._4._Median_of_Two_Sorted_Arrays;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 1, 3 }, new[] { 2 }, 2.0)]
  [TestCase(new[] { 1, 2 }, new[] { 3, 4 }, 2.5)]
  [TestCase(new[] { 2, 2 }, new[] { 2, 2 }, 2.0)]
  [TestCase(new[] { 2, 3 }, new[] { 2, 2 }, 2.0)]
  public void Test1(int[] nums1, int[] nums2, double expected)
  {
    new Solution().FindMedianSortedArrays(nums1, nums2).Should().Be(expected);
    new SolutionUsingQueue().FindMedianSortedArrays(nums1, nums2).Should().Be(expected);
  }
}