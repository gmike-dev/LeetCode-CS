using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._2104._Sum_of_Subarray_Ranges;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 1, 2, 3 }, 4)]
  [TestCase(new[] { 1, 3, 3 }, 4)]
  [TestCase(new[] { 4, -2, -3, 4, 1 }, 59)]
  public void Test(int[] nums, int expected)
  {
    new BruteForceSolution().SubArrayRanges(nums).Should().Be(expected);
  }
}