namespace LeetCode.__LinkedLists._24._Swap_Nodes_in_Pairs;

public class Solution
{
  public ListNode SwapPairs(ListNode head)
  {
    if (head?.next == null)
      return head;

    var dummy = new ListNode
    {
      next = head
    };
    var prev = dummy;
    var curr = head;
    while (curr?.next != null)
    {
      prev.next = curr.next;
      curr.next = curr.next.next;
      prev.next.next = curr;

      prev = curr;
      curr = curr.next;
    }
    return dummy.next;
  }
}

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution()
      .SwapPairs(new ListNode(1, new(2, new(3, new(4)))))
      .Should()
      .BeEquivalentTo(new ListNode(2, new(1, new(4, new(3)))));
  }

  [Test]
  public void Test2()
  {
    new Solution()
      .SwapPairs(new ListNode(1))
      .Should()
      .BeEquivalentTo(new ListNode(1));
  }

  [Test]
  public void Test3()
  {
    new Solution()
      .SwapPairs(null)
      .Should()
      .BeNull();
  }

  [Test]
  public void Test4()
  {
    new Solution()
      .SwapPairs(new ListNode(1, new(2, new(3))))
      .Should()
      .BeEquivalentTo(new ListNode(2, new(1, new(3))));
  }
}
