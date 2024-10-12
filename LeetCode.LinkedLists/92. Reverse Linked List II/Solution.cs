using LeetCode.Common;

namespace LeetCode.LinkedLists._92._Reverse_Linked_List_II;

public class Solution
{
  public ListNode ReverseBetween(ListNode head, int left, int right)
  {
    if (head?.next == null || left >= right)
      return head;

    var preLeft = (ListNode)null;
    var leftNode = head;
    for (var i = 1; i < left; i++)
    {
      preLeft = leftNode;
      leftNode = leftNode.next;
    }

    var rightNode = preLeft;
    var nextRight = leftNode;
    for (var i = left; i <= right; i++)
      (nextRight.next, nextRight, rightNode) = (rightNode, nextRight.next, nextRight);

    leftNode.next = nextRight;
    
    if (preLeft == null)
      return rightNode;

    preLeft.next = rightNode;
    return head;
  }
}