using LeetCode.Binary_Trees._1367._Linked_List_in_Binary_Tree;

namespace LeetCode.__BinaryTrees._1367._Linked_List_in_Binary_Tree;

public class Solution
{
  public bool IsSubPath(ListNode head, TreeNode root)
  {
    if (TestPath(head, root))
      return true;
    
    var result = false;
    if (root.left != null)
      result = IsSubPath(head, root.left);
    if (!result && root.right != null)
      result = IsSubPath(head, root.right);
    return result;
  }
  
  private static bool TestPath(ListNode head, TreeNode root)
  {
    if (head.val != root.val)
      return false;
    if (head.next == null)
      return true;
    var result = false;
    if (root.left != null)
      result = TestPath(head.next, root.left);
    if (!result && root.right != null)
      result = TestPath(head.next, root.right);
    return result;
  }
}