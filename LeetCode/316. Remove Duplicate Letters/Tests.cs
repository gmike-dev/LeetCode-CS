using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._316._Remove_Duplicate_Letters;

[TestFixture]
public class Tests
{
  [TestCase("bcabc", "abc")]
  [TestCase("cbacdcbc", "acdb")]
  [TestCase("abacb", "abc")]
  public void Test(string s, string expected)
  {
    new Solution().RemoveDuplicateLetters(s).Should().Be(expected);
  }
}