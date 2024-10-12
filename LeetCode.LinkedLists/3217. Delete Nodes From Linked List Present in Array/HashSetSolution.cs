using LeetCode.Common;

namespace LeetCode.LinkedLists._3217._Delete_Nodes_From_Linked_List_Present_in_Array;

public class HashSetSolution
{
  public ListNode ModifiedList(int[] nums, ListNode head)
  {
    var s = nums.ToHashSet();
    var root = new ListNode(0, head);
    var node = root;
    while (node.next != null)
    {
      if (s.Contains(node.next.val))
        node.next = node.next.next;
      else
        node = node.next;
    }
    return root.next;
  }
}

[TestFixture]
public class HashSetSolutionTests
{
  [TestCase(new[] { 1, 2, 3 }, "[1,2,3,4,5]", "[4,5]")]
  [TestCase(new[] { 1 }, "[1,2,1,2,1,2]", "[2,2,2]")]
  [TestCase(new[] { 5 }, "[1,2,3,4]", "[1,2,3,4]")]
  public void Test(int[] nums, string head, string expected)
  {
    ListNode.ToString(new HashSetSolution().ModifiedList(nums, ListNode.FromString(head))).Should().Be(expected);
  }
}
