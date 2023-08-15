namespace LeetCode._86._Partition_List;

public class ListNode
{
  public int val;
  public ListNode next;

  public ListNode(int val = 0, ListNode next = null)
  {
    this.val = val;
    this.next = next;
  }
}

public class Solution
{
  public ListNode Partition(ListNode head, int x)
  {
    var leftFakeHead = new ListNode();
    var rightFakeHead = new ListNode();
    var left = leftFakeHead;
    var right = rightFakeHead;
    while (head != null)
    {
      var node = new ListNode(head.val);
      if (head.val < x)
        left = left.next = node;
      else
        right = right.next = node;
      head = head.next;
    }
    left.next = rightFakeHead.next;
    return leftFakeHead.next;
  }
}