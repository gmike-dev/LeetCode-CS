using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.__Sliding_Window._713._Subarray_Product_Less_Than_K;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 10, 5, 2, 6 }, 100, 8)]
  [TestCase(new[] { 1, 2, 3 }, 0, 0)]
  [TestCase(new[] { 2, 2, 3, 1 }, 2, 1)]
  [TestCase(new[] { 2, 2, 3, 1, 1 }, 2, 3)]
  [TestCase(new[] { 2, 2, 3, 1, 2, 1 }, 2, 2)]
  [TestCase(new[] { 1, 2, 3, 4, 5 }, 1, 0)]
  public void Test(int[] nums, int k, int expected)
  {
    new Solution().NumSubarrayProductLessThanK(nums, k).Should().Be(expected);
  }
}
