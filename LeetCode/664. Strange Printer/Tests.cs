using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._664._Strange_Printer;

[TestFixture]
public class Tests
{
  [TestCase("aaabbb", 2)]
  [TestCase("aba", 2)]
  [TestCase("abab", 3)]
  [TestCase("ababa", 3)]
  [TestCase("tbgtgb", 4)]
  [TestCase("baacdddaaddaaaaccbddbcabdaabdbbcdcbbbacbddcabcaaa", 19)]
  [TestCase("ccdcadbddbaddcbccdcdabcbcddbccdcbad", 17)]
  public void Test1(string s, int expected)
  {
    new Solution().StrangePrinter(s).Should().Be(expected);
  }
}