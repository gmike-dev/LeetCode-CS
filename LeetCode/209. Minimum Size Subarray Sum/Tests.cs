using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._209._Minimum_Size_Subarray_Sum;

[TestFixture]
public class Tests
{
  [TestCase(7, new[] { 2, 3, 1, 2, 4, 3 }, 2)]
  [TestCase(4, new[] { 1, 4, 4 }, 1)]
  [TestCase(11, new[] { 1, 1, 1, 1, 1, 1, 1, 1 }, 0)]
  [TestCase(7, new[] { 2, 3, 1, 2, 4, 3 }, 2)]
  public void Test1(int target, int[] nums, int expected)
  {
    new Solution().MinSubArrayLen(target, nums).Should().Be(expected);
  }
}