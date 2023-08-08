using System;
using System.Collections.Generic;

namespace LeetCode._160._Intersection_of_Two_Linked_Lists;

public class ListNode
{
  public int val;
  public ListNode next;

  public ListNode(int x)
  {
    val = x;
  }
}

public class Solution
{
  public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
  {
    var listA = new List<ListNode>();
    while (headA != null)
    {
      listA.Add(headA);
      headA = headA.next;
    }
    var listB = new List<ListNode>();
    while (headB != null)
    {
      listB.Add(headB);
      headB = headB.next;
    }
    listA.Reverse();
    listB.Reverse();
    ListNode intersection = null;
    for (var i = 0; i < Math.Min(listA.Count, listB.Count); i++)
    {
      if (listA[i] == listB[i])
        intersection = listA[i];
      else
        break;
    }
    return intersection;
  }
}