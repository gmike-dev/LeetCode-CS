using LeetCode.Common;

namespace LeetCode.LinkedLists._3217._Delete_Nodes_From_Linked_List_Present_in_Array;

public class BitArraySolution
{
  public ListNode ModifiedList(int[] nums, ListNode head)
  {
    var s = new BitArray(100001);
    foreach (var num in nums)
      s.Set(num, true);
    var root = new ListNode(0, head);
    for (var node = root; node.next != null;)
    {
      if (s.Get(node.next.val))
        node.next = node.next.next;
      else
        node = node.next;
    }
    return root.next;
  }
}

[TestFixture]
public class BitArraySolutionTests
{
  [TestCase(new[] { 1, 2, 3 }, "[1,2,3,4,5]", "[4,5]")]
  [TestCase(new[] { 1 }, "[1,2,1,2,1,2]", "[2,2,2]")]
  [TestCase(new[] { 5 }, "[1,2,3,4]", "[1,2,3,4]")]
  public void Test(int[] nums, string head, string expected)
  {
    ListNode.ToString(new BitArraySolution().ModifiedList(nums, ListNode.FromString(head))).Should().Be(expected);
  }
}
