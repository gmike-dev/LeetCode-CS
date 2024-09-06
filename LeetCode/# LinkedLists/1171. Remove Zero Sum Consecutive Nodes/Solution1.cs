namespace LeetCode.__LinkedLists._1171._Remove_Zero_Sum_Consecutive_Nodes;

public class Solution1
{
  public ListNode RemoveZeroSumSublists(ListNode head)
  {
    var fakeRoot = new ListNode(0, head);
    var prefix = new Dictionary<int, ListNode> { [0] = fakeRoot };
    var prefixSum = 0;
    for (var node = head; node != null; node = node.next)
    {
      prefixSum += node.val;
      if (prefix.TryGetValue(prefixSum, out var first))
      {
        var s = prefixSum;
        for (var n = first.next; n != node; n = n.next)
        {
          s += n.val;
          prefix.Remove(s);
        }
        first.next = node.next;
      }
      else
      {
        prefix[prefixSum] = node;
      }
    }
    return fakeRoot.next;
  }
}

[TestFixture]
public class Solution1Tests
{
  [TestCase("[1,2,-3,3,1]", "[3,1]")]
  [TestCase("[1,2,3,-3,4]", "[1,2,4]")]
  [TestCase("[1,2,3,-3,-2]", "[1]")]
  [TestCase("[1,-1]", "[]")]
  [TestCase("[-1,1]", "[]")]
  [TestCase("[-1,1,2]", "[2]")]
  [TestCase("[1,3,2,-3,-2,5,5,-5,1]", "[1,5,1]")]
  [TestCase("[0,0]", "[]")]
  public void Test1(string list, string expected)
  {
    ListNode.ToString(new Solution1().RemoveZeroSumSublists(ListNode.FromString(list))).Should().Be(expected);
  }
}
