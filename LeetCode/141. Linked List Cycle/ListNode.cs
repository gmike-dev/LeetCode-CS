namespace LeetCode._141._Linked_List_Cycle;

public class ListNode
{
  public int val;
  public ListNode next;

  public override string ToString()
  {
    return val.ToString();
  }

  public ListNode(int val = 0, ListNode next = null)
  {
    this.val = val;
    this.next = next;
  }
}