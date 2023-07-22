using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.NumberOfLongestIncreasingSubsequence;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var sln = new Solution();
    sln.FindNumberOfLIS(new[] { 1, 3, 5, 4, 7 }).Should().Be(2);
    sln.FindNumberOfLIS(new[] { 2, 2, 2, 2, 2 }).Should().Be(5);
    sln.FindNumberOfLIS(new[] { 1, 2, 4, 3, 5, 4, 7, 2 }).Should().Be(3);
  }
}