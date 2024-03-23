using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.__LinkedLists._143._Reorder_List;

public class InPlaceSolution2
{
  public void ReorderList(ListNode head)
  {
    // Find middle node.
    var slow = head;
    var fast = head.next;
    while (fast?.next != null)
    {
      fast = fast.next?.next;
      slow = slow.next;
    }

    // Reverse the second half.
    var prev = slow;
    slow = slow.next;
    while (slow != null)
    {
      var next = slow.next;
      slow.next = prev;
      prev = slow;
      slow = next;
    }

    // Merge first and second half.
    var l = head;
    var r = prev;
    while (l != r)
    {
      var lNext = l.next;
      l.next = r;
      l = lNext;
      if (l != r)
      {
        var rNext = r.next;
        r.next = l;
        r = rNext;
      }
    }
    l.next = null;
  }
}

[TestFixture]
public class InPlaceSolution2Tests
{
  [Test]
  public void Test1()
  {
    var list = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4))));
    new InPlaceSolution2().ReorderList(list);
    list.Should().BeEquivalentTo(new ListNode(1, new ListNode(4, new ListNode(2, new ListNode(3)))));
  }

  [Test]
  public void Test2()
  {
    var list = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
    new InPlaceSolution2().ReorderList(list);
    list.Should().BeEquivalentTo(new ListNode(1, new ListNode(5, new ListNode(2, new ListNode(4, new ListNode(3))))));
  }

  [Test]
  public void Test3()
  {
    var list = new ListNode(1);
    new InPlaceSolution2().ReorderList(list);
    list.Should().BeEquivalentTo(new ListNode(1));
  }

  [Test]
  public void Test4()
  {
    var list = new ListNode(1, new ListNode(2));
    new InPlaceSolution2().ReorderList(list);
    list.Should().BeEquivalentTo(new ListNode(1, new ListNode(2)));
  }

  [Test]
  public void Test5()
  {
    var list = new ListNode(1, new ListNode(2, new ListNode(3)));
    new InPlaceSolution2().ReorderList(list);
    list.Should().BeEquivalentTo(new ListNode(1, new ListNode(3, new ListNode(2))));
  }
}
