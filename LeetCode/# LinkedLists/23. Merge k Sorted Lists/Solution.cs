using System.Collections.Generic;

namespace LeetCode.__LinkedLists._23._Merge_k_Sorted_Lists;

public class Solution
{
  public ListNode MergeKLists(ListNode[] lists)
  {
    if (lists.Length == 0)
      return null;

    var result = new List<int>();
    for (var i = 0; i < lists.Length; i++)
    {
      var list = lists[i];
      while (list != null)
      {
        result.Add(list.val);
        list = list.next;
      }
    }

    if (result.Count == 0)
      return null;
    
    result.Sort();

    var root = new ListNode(result[0]);
    var current = root;
    for (var i = 1; i < result.Count; i++)
      current = current.next = new ListNode(result[i]);
    return root;
  }
  
  public ListNode MergeKLists_UseLinkedList(ListNode[] lists)
  {
    if (lists.Length == 0)
      return null;
    var result = lists[0];
    for (var i = 1; i < lists.Length; i++)
      result = MergeLists(result, lists[i]);
    return result;
  }

  private static ListNode MergeLists(ListNode firstList, ListNode secondList)
  {
    var fakeRoot = new ListNode();
    var node = fakeRoot;
    while (firstList != null && secondList != null)
    {
      if (firstList.val <= secondList.val)
      {
        node.next = new ListNode(firstList.val);
        firstList = firstList.next;
      }
      else
      {
        node.next = new ListNode(secondList.val);
        secondList = secondList.next;
      }
      node = node.next;
    }
    node.next = firstList ?? secondList;
    return fakeRoot.next;
  }
}