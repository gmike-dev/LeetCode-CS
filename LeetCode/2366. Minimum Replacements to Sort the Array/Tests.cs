using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._2366._Minimum_Replacements_to_Sort_the_Array;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 3, 9, 3 }, 2)]
  [TestCase(new[] { 1, 2, 3, 4, 5 }, 0)]
  public void Test(int[] nums, int expected)
  {
    new Solution().MinimumReplacement(nums).Should().Be(expected);
  }
}