using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._239._Sliding_Window_Maximum;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3, new[] { 3, 3, 5, 5, 6, 7 })]
  [TestCase(new[] { 1 }, 1, new[] { 1 })]
  public void Test1(int[] nums, int k, int[] expected)
  {
    new Solution().MaxSlidingWindow(nums, k).Should().BeEquivalentTo(expected);
    new SolutionWithMinMaxQueue().MaxSlidingWindow(nums, k).Should().BeEquivalentTo(expected);
  }
}