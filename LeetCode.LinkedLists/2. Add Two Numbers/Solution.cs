using LeetCode.Common;

namespace LeetCode.LinkedLists._2._Add_Two_Numbers;

public class Solution
{
  public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
  {
    var carry = 0;
    var result = new ListNode();
    var node = result;
    while (l1 != null || l2 != null || carry != 0)
    {
      var x = l1?.val ?? 0;
      var y = l2?.val ?? 0;
      var s = x + y + carry;
      carry = s / 10;
      node.next = new ListNode(s % 10);
      node = node.next = new ListNode(s % 10);
      l1 = l1?.next;
      l2 = l2?.next;
    }
    return result.next;
  }
}