namespace LeetCode._206._Reverse_Linked_List;

public class SolutionUsingNewList
{
  public ListNode ReverseList(ListNode head)
  {
    if (head == null)
      return null;

    var result = new ListNode(head.val);
    var next = head.next;
    while (next != null)
    {
      result = new ListNode(next.val, result);
      next = next.next;
    }
    return result;
  }
}