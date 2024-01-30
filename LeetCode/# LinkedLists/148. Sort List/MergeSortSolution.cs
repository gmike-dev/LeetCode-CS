namespace LeetCode.__LinkedLists._148._Sort_List;

public class MergeSortSolution
{
  public ListNode SortList(ListNode head)
  {
    return MergeSort(head, ListSize(head));
  }

  private static int ListSize(ListNode list)
  {
    var count = 0;
    for (; list != null; list = list.next)
      count++;
    return count;
  }

  private static ListNode MergeSort(ListNode list, int size)
  {
    switch (size)
    {
      case 0:
        return null;
      case 1:
        return new ListNode(list.val);
      default:
      {
        var middle = list;
        for (var i = 0; i < size / 2; i++)
          middle = middle.next;

        var left = MergeSort(list, size / 2);
        var right = MergeSort(middle, (size + 1) / 2);
        return Merge(left, right);
      }
    }
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
    node.next = listA ?? listB;
    return result.next;
  }
}