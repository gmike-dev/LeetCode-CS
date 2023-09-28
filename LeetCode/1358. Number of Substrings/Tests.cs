using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._1358._Number_of_Substrings;

[TestFixture]
public class Tests
{
  [TestCase("abcabc", 10)]
  [TestCase("aaacb", 3)]
  [TestCase("abc", 1)]
  [TestCase("acbbcac", 11)]
  public void Test(string s, int expected)
  {
    new Solution().NumberOfSubstrings(s).Should().Be(expected);
  }
}