using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.__LinkedLists._143._Reorder_List;

public class InPlaceSolution
{
  public void ReorderList(ListNode head)
  {
    var middle = SplitList(head);
    var last = ReverseList(middle);
    MergeLists(head, last);
  }

  private static void MergeLists(ListNode left, ListNode right)
  {
    while (left != null && right != null)
      (left.next, right.next, left, right) =
        (right, left.next, left.next, right.next);
  }

  private static ListNode SplitList(ListNode head)
  {
    var slow = head;
    var fast = head.next;
    while (fast?.next != null)
    {
      fast = fast.next?.next;
      slow = slow.next;
    }
    var next = slow.next;
    slow.next = null;
    return next;
  }

  private static ListNode ReverseList(ListNode head)
  {
    ListNode prev = null;
    while (head != null)
      (head.next, prev, head) = (prev, head, head.next);
    return prev;
  }
}

[TestFixture]
public class InPlaceSolutionTests
{
  [Test]
  public void Test1()
  {
    var list = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4))));
    new InPlaceSolution().ReorderList(list);
    list.Should().BeEquivalentTo(new ListNode(1, new ListNode(4, new ListNode(2, new ListNode(3)))));
  }

  [Test]
  public void Test2()
  {
    var list = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
    new InPlaceSolution().ReorderList(list);
    list.Should().BeEquivalentTo(new ListNode(1, new ListNode(5, new ListNode(2, new ListNode(4, new ListNode(3))))));
  }

  [Test]
  public void Test3()
  {
    var list = new ListNode(1);
    new InPlaceSolution().ReorderList(list);
    list.Should().BeEquivalentTo(new ListNode(1));
  }

  [Test]
  public void Test4()
  {
    var list = new ListNode(1, new ListNode(2));
    new InPlaceSolution().ReorderList(list);
    list.Should().BeEquivalentTo(new ListNode(1, new ListNode(2)));
  }

  [Test]
  public void Test5()
  {
    var list = new ListNode(1, new ListNode(2, new ListNode(3)));
    new InPlaceSolution().ReorderList(list);
    list.Should().BeEquivalentTo(new ListNode(1, new ListNode(3, new ListNode(2))));
  }
}
