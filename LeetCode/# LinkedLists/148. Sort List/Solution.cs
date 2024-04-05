namespace LeetCode.__LinkedLists._148._Sort_List;

public class Solution
{
  public ListNode SortList(ListNode head)
  {
    var list = ToList(head);
    list.Sort((a, b) => a.val.CompareTo(b.val));
    return ToListNode(list);
  }

  private static List<ListNode> ToList(ListNode list)
  {
    var result = new List<ListNode>();
    while (list != null)
    {
      result.Add(list);
      list = list.next;
    }
    return result;
  }

  private static ListNode ToListNode(List<ListNode> list)
  {
    if (list.Count == 0)
      return null;
    for (var i = 0; i + 1 < list.Count; i++)
      list[i].next = list[i + 1];
    list[^1].next = null;
    return list[0];
  }
}
