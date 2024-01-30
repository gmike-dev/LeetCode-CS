namespace LeetCode.__LinkedLists._141._Linked_List_Cycle;

public class Solution
{
  /// <summary>
  /// Using Floyd’s Cycle-Finding Algorithm.
  /// </summary>
  public bool HasCycle(ListNode head)
  {
    var slow = head;
    var fast = head?.next;
    while (fast != null && slow != fast)
    {
      slow = slow?.next;
      fast = fast.next?.next;
    }
    return fast != null;
  }
}