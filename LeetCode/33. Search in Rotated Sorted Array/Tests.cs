using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._33._Search_in_Rotated_Sorted_Array;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 4, 5, 6, 7, 0, 1, 2 }, 0, 4)]
  [TestCase(new[] { 4, 5, 6, 7, 0, 1, 2 }, 3, -1)]
  [TestCase(new[] { 1 }, 0, -1)]
  [TestCase(new[] { 1, 1, 2, 1, 1, 1 }, 2, 2)]
  [TestCase(new[] { 1, 1, 2, 1, 1, 1, 1 }, 2, 2)]
  [TestCase(new[] { 1, 1, 1, 1, 2, 1, 1 }, 2, 4)]
  public void Test1(int[] nums, int target, int expected)
  {
    new Solution().Search(nums, target).Should().Be(expected);
  }
}