using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._5._Longest_Palindromic_Substring;

[TestFixture]
public class Tests
{
  [TestCase("babad","bab")]
  [TestCase("cbbd","bb")]
  public void Test(string s, string expected)
  {
    new Solution().LongestPalindrome(s).Should().Be(expected);
  }
}