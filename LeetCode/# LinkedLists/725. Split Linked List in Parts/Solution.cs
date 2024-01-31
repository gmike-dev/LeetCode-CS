namespace LeetCode.__LinkedLists._725._Split_Linked_List_in_Parts;

public class Solution
{
  public ListNode[] SplitListToParts(ListNode head, int k)
  {
    var length = 0;
    for (var node = head; node != null; node = node.next)
      length++;

    var result = new ListNode[k];
    var curr = head;
    var prev = (ListNode)null;
    for (var i = 0; i < k; i++)
    {
      result[i] = curr;
      var partSize = (length + k - i - 1) / (k - i);
      for (var j = 0; j < partSize; j++)
      {
        prev = curr;
        curr = curr.next;
      }
      if (prev != null)
        prev.next = null;
      length -= partSize;
    }
    return result;
  }
}