namespace LeetCode.__LinkedLists._206._Reverse_Linked_List;

public class Solution
{
  public ListNode ReverseList(ListNode head)
  {
    var prev = (ListNode)null;
    var curr = head;
    while (curr != null)
    {
      var next = curr.next;
      curr.next = prev;
      prev = curr;
      curr = next;
    }
    return prev;
  }

}