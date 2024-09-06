namespace LeetCode.__LinkedLists._1171._Remove_Zero_Sum_Consecutive_Nodes;

public class Solution2
{
  public ListNode RemoveZeroSumSublists(ListNode head)
  {
    var fakeRoot = new ListNode(0, head);
    var prefix = new Dictionary<int, ListNode>();
    var prefixSum = 0;
    for (var node = fakeRoot; node != null; node = node.next)
    {
      prefixSum += node.val;
      prefix[prefixSum] = node;
    }
    prefixSum = 0;
    for (var node = fakeRoot; node != null; node = node.next)
    {
      prefixSum += node.val;
      node.next = prefix[prefixSum].next;
    }
    return fakeRoot.next;
  }
}

[TestFixture]
public class Solution2Tests
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
    ListNode.ToString(new Solution2().RemoveZeroSumSublists(ListNode.FromString(list))).Should().Be(expected);
  }
}
