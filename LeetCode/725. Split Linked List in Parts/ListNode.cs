namespace LeetCode._725._Split_Linked_List_in_Parts;

public class ListNode
{
  public int val;
  public ListNode next;

  public override string ToString() => $"val: {val.ToString()}, next: {next?.val.ToString() ?? "null"}";

  public ListNode(int val = 0, ListNode next = null)
  {
    this.val = val;
    this.next = next;
  }
}