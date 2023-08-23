using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._767._Reorganize_String;

[TestFixture]
public class Tests
{
  [TestCase("aab", "aba")]
  [TestCase("aaab", "")]
  [TestCase("ab", "ab")]
  [TestCase("a", "a")]
  public void Test(string s, string expected)
  {
    new Solution().ReorganizeString(s).Should().Be(expected);
  }
}