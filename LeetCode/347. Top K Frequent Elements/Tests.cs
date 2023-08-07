using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._347._Top_K_Frequent_Elements;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 1, 1, 1, 2, 2, 3 }, 2, new[] { 1, 2 })]
  [TestCase(new[] { 1 }, 1, new[] { 1 })]
  public void Test1(int[] nums, int k, int[] expected)
  {
    new Solution().TopKFrequent(nums, k).Should().BeEquivalentTo(expected);
    new Solution().TopKFrequent_Sorting(nums, k).Should().BeEquivalentTo(expected);
  }
}