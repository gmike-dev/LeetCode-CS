using LeetCode.Common;

namespace LeetCode.LinkedLists._234._Palindrome_Linked_List;

public class SolutionUsingStackSlowFast
{
  public bool IsPalindrome(ListNode head)
  {
    var stack = new Stack<int>();
    var slow = head;
    var fast = head;
    while (fast?.next != null)
    {
      fast = fast.next?.next;
      stack.Push(slow.val);
      slow = slow.next;
    }
    if (fast != null)
      slow = slow.next;
    while (slow != null)
    {
      if (stack.Pop() != slow.val)
        return false;
      slow = slow.next;
    }
    return true;
  }
}

[TestFixture]
public class SolutionUsingStackSlowFastTests
{
  [Test]
  public void Test1()
  {
    var list = new ListNode(1, new ListNode(2, new ListNode(2, new ListNode(1))));
    new SolutionUsingStackSlowFast().IsPalindrome(list).Should().BeTrue();
  }

  [Test]
  public void Test2()
  {
    var list = new ListNode(1, new ListNode(2));
    new SolutionUsingStackSlowFast().IsPalindrome(list).Should().BeFalse();
  }

  [Test]
  public void Test3()
  {
    var list = new ListNode(1, new ListNode(0, new ListNode(0)));
    new SolutionUsingStackSlowFast().IsPalindrome(list).Should().BeFalse();
  }

  [Test]
  public void Test4()
  {
    var list = new ListNode(1);
    new SolutionUsingStackSlowFast().IsPalindrome(list).Should().BeTrue();
  }
}
