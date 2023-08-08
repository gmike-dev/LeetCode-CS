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
    var node = headA;
    while (node != null)
    {
      node.val = -node.val;
      node = node.next;
    }
    node = headB;
    while (node is { val: > 0 })
      node = node.next;
    var intersection = node;
    node = headA;
    while (node != null)
    {
      node.val = -node.val;
      node = node.next;
    }
    return intersection;
  }
  
  public ListNode GetIntersectionNode2(ListNode headA, ListNode headB)
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