using NUnit.Framework;

namespace LeetCode.PalindromeNumber;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var sln = new Solution();
    Assert.That(sln.IsPalindrome(1221), Is.True);
    Assert.That(sln.IsPalindrome(1222), Is.False);
    Assert.That(sln.IsPalindrome(1), Is.True);
    Assert.That(sln.IsPalindrome(12), Is.False);
    Assert.That(sln.IsPalindrome(-1), Is.False);
  }
}