using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.__LinkedLists._234._Palindrome_Linked_List;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var list = new ListNode(1, new ListNode(2, new ListNode(2, new ListNode(1))));
    new Solution().IsPalindrome(list).Should().BeTrue();
  }

  [Test]
  public void Test2()
  {
    var list = new ListNode(1, new ListNode(2));
    new Solution().IsPalindrome(list).Should().BeFalse();
  }

  [Test]
  public void Test3()
  {
    var list = new ListNode(1, new ListNode(0, new ListNode(0)));
    new Solution().IsPalindrome(list).Should().BeFalse();
  }
  
  [Test]
  public void Test4()
  {
    var list = new ListNode(1);
    new Solution().IsPalindrome(list).Should().BeTrue();
  }
}