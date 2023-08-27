using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._415._Add_Strings;

[TestFixture]
public class Tests
{
  [TestCase("0", "0", "0")]
  [TestCase("2", "3", "5")]
  [TestCase("0", "3", "3")]
  [TestCase("10", "3", "13")]
  [TestCase("9", "1", "10")]
  [TestCase("9", "8", "17")]
  [TestCase("99", "889", "988")]
  public void Test(string num1, string num2, string expected)
  {
    new Solution().AddStrings(num1, num2).Should().Be(expected);
  }
}