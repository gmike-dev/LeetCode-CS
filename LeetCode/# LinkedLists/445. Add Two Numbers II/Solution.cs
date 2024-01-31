using System.Collections.Generic;

namespace LeetCode.__LinkedLists._445._Add_Two_Numbers_II;

public class Solution
{
  private static Stack<int> Reverse(ListNode node)
  {
    var s = new Stack<int>();
    while (node != null)
    {
      s.Push(node.val);
      node = node.next;
    }
    return s;
  }
  
  public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
  {
    var s1 = Reverse(l1);
    var s2 = Reverse(l2);
    ListNode result = null;
    var carry = 0;
    while (s1.Count > 0 || s2.Count > 0)
    {
      var s = carry;
      if (s1.Count > 0)
        s += s1.Pop();
      if (s2.Count > 0)
        s += s2.Pop();
      result = new ListNode(s % 10, result);
      carry = s / 10;
    }
    if (carry > 0)
      result = new ListNode(1, result);
    return result;
  }
}
