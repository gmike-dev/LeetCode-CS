namespace LeetCode.__LinkedLists._206._Reverse_Linked_List;

public class SolutionUsingNewList
{
  public ListNode ReverseList(ListNode head)
  {
    var result = (ListNode)null;
    while (head != null)
    {
      result = new ListNode(head.val, result);
      head = head.next;
    }
    return result;
  }
}