using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.__Sliding_Window._76._Minimum_Window_Substring;

[TestFixture]
public class Tests
{
  [TestCase("ADOBECODEBANC", "ABC", "BANC")]
  [TestCase("a", "a", "a")]
  [TestCase("a", "aa", "")]
  [TestCase("abcdefg", "bf", "bcdef")]
  [TestCase("abbbbfg", "bf", "bf")]
  [TestCase("abbbbfg", "g", "g")]
  [TestCase("ab", "a", "a")]
  [TestCase("a", "b", "")]
  public void Test(string s, string t, string expected)
  {
    new MyLotOfCodeSolution().MinWindow(s, t).Should().Be(expected);
    new ShortButTrickySolution().MinWindow(s, t).Should().Be(expected);
  }
}
