using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.RomanToInteger;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var sln = new Solution();
    sln.RomanToInt("III").Should().Be(3);
    sln.RomanToInt("LVIII").Should().Be(58);
    sln.RomanToInt("MCMXCIV").Should().Be(1994);
  }
}