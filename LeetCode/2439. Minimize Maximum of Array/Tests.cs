using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._2439._Minimize_Maximum_of_Array;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 3, 7, 1, 6 }, 5)]
  [TestCase(new[] { 10, 1 }, 10)]
  [TestCase(new[] { 6, 9, 3, 8, 14 }, 8)]
  public void Test1(int[] nums, int expected)
  {
    new Solution().MinimizeArrayValue(nums).Should().Be(expected);
  }
}