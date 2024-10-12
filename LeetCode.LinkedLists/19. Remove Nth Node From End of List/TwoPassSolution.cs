using LeetCode.Common;

namespace LeetCode.LinkedLists._19._Remove_Nth_Node_From_End_of_List;

public class TwoPassSolution
{
  public ListNode RemoveNthFromEnd(ListNode head, int n)
  {
    var listSize = GetSize(head);
    ListNode prev = null;
    var node = head;
    for (var i = 0; i < listSize - n; i++)
      (prev, node) = (node, node.next);
    if (prev == null)
      return node.next; // Remove first element.
    prev.next = node.next;
    return head;
  }

  private static int GetSize(ListNode head)
  {
    var size = 0;
    for (var node = head; node != null; node = node.next)
      size++;
    return size;
  }
}

[TestFixture]
public class TwoPassSolutionTests
{
  [Test]
  public void Test1()
  {
    new TwoPassSolution()
      .RemoveNthFromEnd(new ListNode(1, new(2, new(3, new(4, new(5))))), 2)
      .Should()
      .BeEquivalentTo(new ListNode(1, new(2, new(3, new(5)))));
  }

  [Test]
  public void Test2()
  {
    new TwoPassSolution()
      .RemoveNthFromEnd(new ListNode(1), 1)
      .Should()
      .BeNull();
  }

  [Test]
  public void Test3()
  {
    new TwoPassSolution()
      .RemoveNthFromEnd(new ListNode(1, new(2)), 1)
      .Should()
      .BeEquivalentTo(new ListNode(1));
  }

  [Test]
  public void Test187()
  {
    new TwoPassSolution()
      .RemoveNthFromEnd(new ListNode(1, new(2)), 2)
      .Should()
      .BeEquivalentTo(new ListNode(2));
  }
}
