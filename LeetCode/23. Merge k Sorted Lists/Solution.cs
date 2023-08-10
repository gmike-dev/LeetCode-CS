namespace LeetCode._23._Merge_k_Sorted_Lists;

public class ListNode
{
  public int val;
  public ListNode next;

  public ListNode(int val = 0, ListNode next = null)
  {
    this.val = val;
    this.next = next;
  }
}

public class Solution
{
  public ListNode MergeKLists(ListNode[] lists)
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