using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._17._Letter_Combinations_of_a_Phone_Number;

[TestFixture]
public class Tests
{
  [TestCase("23", new[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" })]
  [TestCase("", new string[0])]
  [TestCase("2", new[] { "a", "b", "c" })]
  public void Test1(string digits, string[] expected)
  {
    new Solution().LetterCombinations(digits).Should().BeEquivalentTo(expected);
  }
}