using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.__LinkedLists._234._Palindrome_Linked_List;

public class SolutionSlowFast
{
  public bool IsPalindrome(ListNode head)
  {
    if (head?.next == null)
      return true;

    var slow = head;
    var fast = head;
    var reversed = (ListNode)null;
    while (fast?.next != null)
    {
      fast = fast.next?.next;
      (slow.next, reversed, slow) = (reversed, slow, slow.next);
    }
    if (fast != null)
      slow = slow.next;
    while (reversed != null && slow != null)
    {
      if (reversed.val != slow.val)
        return false;
      reversed = reversed.next;
      slow = slow.next;
    }
    return true;
  }
}

[TestFixture]
public class SolutionSlowFastTests
{
  [Test]
  public void Test1()
  {
    var list = new ListNode(1, new ListNode(2, new ListNode(2, new ListNode(1))));
    new SolutionSlowFast().IsPalindrome(list).Should().BeTrue();
  }

  [Test]
  public void Test2()
  {
    var list = new ListNode(1, new ListNode(2));
    new SolutionSlowFast().IsPalindrome(list).Should().BeFalse();
  }

  [Test]
  public void Test3()
  {
    var list = new ListNode(1, new ListNode(0, new ListNode(0)));
    new SolutionSlowFast().IsPalindrome(list).Should().BeFalse();
  }

  [Test]
  public void Test4()
  {
    var list = new ListNode(1);
    new SolutionSlowFast().IsPalindrome(list).Should().BeTrue();
  }
}
