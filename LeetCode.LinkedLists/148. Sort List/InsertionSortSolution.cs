using LeetCode.Common;

namespace LeetCode.LinkedLists._148._Sort_List;

public class InsertionSortSolution
{
  public ListNode SortList(ListNode head)
  {
    var fakeRoot = new ListNode();
    while (head != null)
    {
      Insert(fakeRoot, head.val);
      head = head.next;
    }
    return fakeRoot.next;
  }

  private static void Insert(ListNode root, int value)
  {
    while (root.next != null && root.next.val < value)
      root = root.next;
    root.next = new ListNode(value, root.next);
  }
}