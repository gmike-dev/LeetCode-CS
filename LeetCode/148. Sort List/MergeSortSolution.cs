namespace LeetCode._148._Sort_List;

public class MergeSortSolution
{
  public ListNode SortList(ListNode head)
  {
    return MergeSort(head);
  }

  private static ListNode MergeSort(ListNode list, ListNode endNode = null)
  {
    if (list == endNode)
      return null;
    
    if (list.next == endNode)
      return new ListNode(list.val);
    
    var middle = list;
    var count = 0;
    for (var node = list; node != endNode; node = node.next)
    {
      count++;
      if (count % 2 == 0)
        middle = middle.next;
    }

    var left = MergeSort(list, middle);
    var right = MergeSort(middle, endNode);
    return Merge(left, right);
  }

  private static ListNode Merge(ListNode listA, ListNode listB)
  {
    var result = new ListNode();
    var node = result;
    while (listA != null && listB != null)
    {
      if (listA.val <= listB.val)
      {
        node.next = listA;
        listA = listA.next;
      }
      else
      {
        node.next = listB;
        listB = listB.next;
      }
      node = node.next;
    }
    if (listA == null)
      node.next = listB;
    if (listB == null)
      node.next = listA;
    return result.next;
  }
}