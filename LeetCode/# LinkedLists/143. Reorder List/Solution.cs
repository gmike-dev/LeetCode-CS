using System.Collections.Generic;

namespace LeetCode.__LinkedLists._143._Reorder_List;

public class Solution
{
  public void ReorderList(ListNode head)
  {
    if (head?.next == null)
      return;
    var list = new List<ListNode>();
    for (var node = head; node != null; node = node.next)
      list.Add(node);
    var l = 0;
    var r = list.Count - 1;
    while (l < r)
    {
      list[l++].next = list[r];
      if (l < r)
        list[r--].next = list[l];
    }
    list[l].next = null;
  }
}