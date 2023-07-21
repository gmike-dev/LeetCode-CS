using NUnit.Framework;

namespace LeetCode.RomanToInteger;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var sln = new Solution();
    Assert.That(sln.RomanToInt("III"), Is.EqualTo(3));
    Assert.That(sln.RomanToInt("LVIII"), Is.EqualTo(58));
    Assert.That(sln.RomanToInt("MCMXCIV"), Is.EqualTo(1994));
  }
}