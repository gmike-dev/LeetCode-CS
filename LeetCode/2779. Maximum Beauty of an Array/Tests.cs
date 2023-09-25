using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._2779._Maximum_Beauty_of_an_Array;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 4, 6, 1, 2 }, 2, 3)]
  [TestCase(new[] { 1, 1, 1, 1 }, 10, 4)]
  [TestCase(new[] { 1, 1, 1, 4, 10 }, 2, 4)]
  public void Test(int[] nums, int k, int expected)
  {
    new Solution().MaximumBeauty(nums, k).Should().Be(expected);
  }
}