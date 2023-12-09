using System.Collections.Generic;

namespace LeetCode._94._Binary_Tree_Inorder_Traversal;

public class IterativeSolution
{
  public IList<int> InorderTraversal(TreeNode root)
  {
    var result = new List<int>();
    var s = new Stack<TreeNode>();
    while (root != null || s.Count != 0)
    {
      while (root != null)
      {
        s.Push(root);
        root = root.left;
      }
      root = s.Pop();
      result.Add(root.val);
      root = root.right;
    }
    return result;
  }
}