namespace LeetCode.__LinkedLists._86._Partition_List;

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