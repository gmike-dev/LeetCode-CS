using LeetCode.Common;

namespace LeetCode.LinkedLists._21._Merge_Two_Sorted_Lists;

public class Solution
{
  public ListNode MergeTwoLists(ListNode list1, ListNode list2)
  {
    var result = new ListNode(-1);
    var lastNode = result;
    while (list1 != null && list2 != null)
    {
      if (list1.val < list2.val)
      {
        lastNode.next = new ListNode(list1.val);
        list1 = list1.next;
      }
      else
      {
        lastNode.next = new ListNode(list2.val);
        list2 = list2.next;
      }
      lastNode = lastNode.next;
    }
    while (list1 != null)
    {
      lastNode.next = new ListNode(list1.val);
      lastNode = lastNode.next;
      list1 = list1.next;
    }
    while (list2 != null)
    {
      lastNode.next = new ListNode(list2.val);
      lastNode = lastNode.next;
      list2 = list2.next;
    }
    return result.next;
  }
}