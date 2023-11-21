using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._1814._Count_Nice_Pairs_in_an_Array;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 42, 11, 1, 97 }, 2)]
  [TestCase(new[] { 13, 10, 35, 24, 76 }, 4)]
  [TestCase(new[] { 1, 1, 1, 1 }, 6)]
  public void Test(int[] nums, int expected)
  {
    new Solution().CountNicePairs(nums).Should().Be(expected);
  }
}