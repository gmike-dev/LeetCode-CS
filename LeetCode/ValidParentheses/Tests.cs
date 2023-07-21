using NUnit.Framework;

namespace LeetCode.ValidParentheses;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var sln = new Solution();
    Assert.That(sln.IsValid("()"), Is.True);
    Assert.That(sln.IsValid("()[]{}"), Is.True);
    Assert.That(sln.IsValid("(]"), Is.False);
    Assert.That(sln.IsValid("([()[][{}]])[]"), Is.True);
  }
}