using LeetCode.Common;

namespace LeetCode.BinaryTrees._1367._Linked_List_in_Binary_Tree;

public class Solution
{
  public bool IsSubPath(ListNode head, TreeNode root)
  {
    if (root is null)
      return false;
    return TestPath(head, root) || IsSubPath(head, root.left) || IsSubPath(head, root.right);
  }

  private static bool TestPath(ListNode head, TreeNode root)
  {
    if (head is null)
      return true;
    if (root is null)
      return false;
    return head.val == root.val && (TestPath(head.next, root.left) || TestPath(head.next, root.right));
  }
}

[TestFixture]
public class Tests
{
  [TestCase("[4,2,8]", "[1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3]", true)]
  [TestCase("[1,4,2,6]", "[1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3]", true)]
  [TestCase("[1,4,2,6,8]", "[1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3]", false)]
  public void Test(string list, string tree, bool expected)
  {
    new Solution().IsSubPath(ListNode.FromString(list), TreeNode.FromString(tree)).Should().Be(expected);
  }
}
