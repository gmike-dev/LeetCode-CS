using System.Collections.Generic;

namespace LeetCode._94._Binary_Tree_Inorder_Traversal;

public class RecursiveSolution
{
  public IList<int> InorderTraversal(TreeNode root)
  {
    var result = new List<int>();
    Traverse(root, result);
    return result;
  }

  private static void Traverse(TreeNode root, List<int> result)
  {
    if (root != null)
    {
      Traverse(root.left, result);
      result.Add(root.val);
      Traverse(root.right, result);
    }
  }
}