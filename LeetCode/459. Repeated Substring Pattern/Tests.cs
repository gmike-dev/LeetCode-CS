using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._459._Repeated_Substring_Pattern;

[TestFixture]
public class Tests
{
  [TestCase("abab", true)]
  [TestCase("aba", false)]
  [TestCase("abcabcabcabc", true)]
  [TestCase("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", true)]
  public void Test(string s, bool expectation)
  {
    new Solution().RepeatedSubstringPattern(s).Should().Be(expectation);
  }
}