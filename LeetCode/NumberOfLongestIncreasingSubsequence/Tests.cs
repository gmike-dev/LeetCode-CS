using NUnit.Framework;

namespace LeetCode.NumberOfLongestIncreasingSubsequence;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var sln = new Solution();
    Assert.That(sln.FindNumberOfLIS(new[] { 1, 3, 5, 4, 7 }), Is.EqualTo(2));
    Assert.That(sln.FindNumberOfLIS(new[] { 2, 2, 2, 2, 2 }), Is.EqualTo(5));
    Assert.That(sln.FindNumberOfLIS(new[] { 1, 2, 4, 3, 5, 4, 7, 2 }), Is.EqualTo(3));
  }
}