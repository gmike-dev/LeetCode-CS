using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.ValidParentheses;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var sln = new Solution();
    sln.IsValid("()").Should().BeTrue();
    sln.IsValid("()[]{}").Should().BeTrue();
    sln.IsValid("(]").Should().BeFalse();
    sln.IsValid("([()[][{}]])[]").Should().BeTrue();
  }
}