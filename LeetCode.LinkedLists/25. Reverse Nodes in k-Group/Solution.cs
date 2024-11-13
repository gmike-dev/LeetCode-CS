using LeetCode.Common;

namespace LeetCode.LinkedLists._25._Reverse_Nodes_in_k_Group;

public class Solution
{
  public ListNode ReverseKGroup(ListNode head, int k)
  {
    var dummy = new ListNode(0, head);
    var prev = dummy;
    var curr = head;
    for (var length = 1; curr != null; length++)
    {
      var nextCurr = curr.next;
      if (length % k == 0)
        (prev.next, prev) = (Reverse(prev.next, curr), prev.next);
      curr = nextCurr;
    }
    return dummy.next;
  }

  private static ListNode Reverse(ListNode begin, ListNode end)
  {
    var (prev, curr) = (begin, begin.next);
    while (prev != end)
      (prev, curr.next, curr) = (curr, prev, curr.next);
    begin.next = curr;
    return prev;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("[1,2,3,4,5]", 2, "[2,1,4,3,5]")]
  [TestCase("[1,2,3,4,5]", 3, "[3,2,1,4,5]")]
  [TestCase("[1,2,3,4,5]", 1, "[1,2,3,4,5]")]
  [TestCase("[1,2,3,4,5]", 5, "[5,4,3,2,1]")]
  [TestCase("[1,2,3,4,5]", 4, "[4,3,2,1,5]")]
  [TestCase("[1,2]", 2, "[2,1]")]
  [TestCase("[1]", 1, "[1]")]
  public void Test(string list, int k, string expected)
  {
    ListNode.ToString(new Solution().ReverseKGroup(ListNode.FromString(list), k)).Should().Be(expected);
  }
}
