using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.LongestIncreasingSubsequence;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var sln = new Solution();
    sln.LengthOfLIS(new[] { 1, 3, 5, 4, 7 }).Should().Be(4);
    sln.LengthOfLIS(new[] { 2, 2, 2, 2, 2 }).Should().Be(1);
    sln.LengthOfLIS(new[] { 1, 2, 4, 3, 5, 4, 7, 2 }).Should().Be(5);
  }
}