namespace LeetCode.__Numbers._9._Palindrome_Number;

public class Solution
{
  public bool IsPalindrome(int x)
  {
    if (x < 0)
      return false;
    var n = x;
    var m = 0;
    while (n != 0)
    {
      m = m * 10 + n % 10;
      n /= 10;
    }
    return x == m;
  }
}

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
