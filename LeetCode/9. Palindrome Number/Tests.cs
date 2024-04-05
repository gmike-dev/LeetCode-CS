namespace LeetCode.PalindromeNumber;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var sln = new Solution();
    sln.IsPalindrome(1221).Should().BeTrue();
    sln.IsPalindrome(1222).Should().BeFalse();
    sln.IsPalindrome(1).Should().BeTrue();
    sln.IsPalindrome(12).Should().BeFalse();
    sln.IsPalindrome(-1).Should().BeFalse();
  }
}
