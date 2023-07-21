using NUnit.Framework;

namespace LeetCode.IntegerToRoman;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var sln = new Solution();
    Assert.That(sln.IntToRoman(3), Is.EqualTo("III"));
    Assert.That(sln.IntToRoman(58), Is.EqualTo("LVIII"));
    Assert.That(sln.IntToRoman(1994), Is.EqualTo("MCMXCIV"));
  }
}