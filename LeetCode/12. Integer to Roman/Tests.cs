using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._12._Integer_to_Roman;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var sln = new Solution();
    sln.IntToRoman(3).Should().Be("III");
    sln.IntToRoman(58).Should().Be("LVIII");
    sln.IntToRoman(1994).Should().Be("MCMXCIV");
  }
}