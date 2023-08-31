namespace LeetCode._206._Reverse_Linked_List;

public class Solution
{
  public ListNode ReverseList(ListNode head)
  {
    if (head == null)
      return null;

    var prev = (ListNode)null;
    var curr = head;
    var next = head.next;
    while (next != null)
    {
      curr.next = prev;
      prev = curr;
      curr = next;
      next = next.next;
    }
    curr.next = prev;
    return curr;
  }

}