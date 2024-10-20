namespace LeetCode.Strings._20._Valid_Parentheses;

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
