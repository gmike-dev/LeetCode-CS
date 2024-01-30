using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.__LinkedLists._19._Remove_Nth_Node_From_End_of_List;

public class OnePassSolution
{
  public ListNode RemoveNthFromEnd(ListNode head, int n)
  {
    var fast = head;
    for (var i = 0; i < n; i++)
      fast = fast.next;
    if (fast == null)
      return head.next; // Remove first element.
    var slow = head;
    while (fast.next != null)
    {
      fast = fast.next;
      slow = slow.next;
    }
    slow.next = slow.next.next;
    return head;
  }
}

[TestFixture]
public class OnePassSolutionTests
{
  [Test]
  public void Test1()
  {
    new OnePassSolution()
      .RemoveNthFromEnd(new ListNode(1, new(2, new(3, new(4, new(5))))), 2)
      .Should()
      .BeEquivalentTo(new ListNode(1, new(2, new(3, new(5)))));
  }

  [Test]
  public void Test2()
  {
    new OnePassSolution()
      .RemoveNthFromEnd(new ListNode(1), 1)
      .Should()
      .BeNull();
  }

  [Test]
  public void Test3()
  {
    new OnePassSolution()
      .RemoveNthFromEnd(new ListNode(1, new(2)), 1)
      .Should()
      .BeEquivalentTo(new ListNode(1));
  }
  
  [Test]
  public void Test187()
  {
    new OnePassSolution()
      .RemoveNthFromEnd(new ListNode(1, new(2)), 2)
      .Should()
      .BeEquivalentTo(new ListNode(2));
  }
}