using LeetCode.__BinaryTrees;

namespace LeetCode.__LinkedLists._109._Convert_Sorted_List_to_Binary_Search_Tree;

public class FastSlowSolution
{
  public TreeNode SortedListToBST(ListNode head)
  {
    if (head is null)
      return null;
    return BuildTree(head, null);
  }

  private static TreeNode BuildTree(ListNode start, ListNode end)
  {
    if (start == end)
      return null;
    var slow = start;
    var fast = start;
    while (fast != end && fast.next != end)
    {
      slow = slow.next;
      fast = fast.next.next;
    }
    return new TreeNode(slow.val, BuildTree(start, slow), BuildTree(slow.next, end));
  }
}

[TestFixture]
public class FastSlowSolutionTests
{
  [TestCase("[-10,-3,0,5,9]", "[0,-3,9,-10,null,5]")]
  [TestCase("[]", "[]")]
  public void Test(string list, string expected)
  {
    TreeNode.ToString(new FastSlowSolution().SortedListToBST(ListNode.FromString(list))).Should().Be(expected);
  }
}
