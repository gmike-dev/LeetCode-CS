using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._1218._Longest_Arithmetic_Subsequence_of_Given_Difference;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().LongestSubsequence(new[] { 1, 2, 3, 4 }, 1).Should().Be(4);
    new Solution().LongestSubsequence(new[] { 1, 3, 5, 7 }, 1).Should().Be(1);
    new Solution().LongestSubsequence(new[] { 1, 3, 5, 7 }, 2).Should().Be(4);
    new Solution().LongestSubsequence(new[] { 1, 5, 7, 8, 5, 3, 4, 2, 1 }, -2).Should().Be(4);
  }
}