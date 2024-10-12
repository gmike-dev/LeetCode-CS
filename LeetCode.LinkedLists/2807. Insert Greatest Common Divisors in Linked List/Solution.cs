using LeetCode.Common;

namespace LeetCode.LinkedLists._2807._Insert_Greatest_Common_Divisors_in_Linked_List;

public class Solution
{
  public ListNode InsertGreatestCommonDivisors(ListNode head)
  {
    for(var node = head; node.next != null; node = node.next.next)
      node.next = new ListNode(Gcd(node.val, node.next.val), node.next);
    return head;
  }

  private static int Gcd(int a, int b)
  {
    while (b != 0)
      (b, a) = (a % b, b);
    return a;
  }
}

[TestFixture]
public class Tests
{
  [TestCase("[18,6,10,3]", "[18,6,6,2,10,1,3]")]
  [TestCase("[7]", "[7]")]
  public void Test(string head, string expected)
  {
    ListNode.ToString(new Solution().InsertGreatestCommonDivisors(ListNode.FromString(head))).Should().Be(expected);
  }
}
