using LeetCode.Common;

namespace LeetCode.BinaryTrees._863._All_Nodes_Distance_K_in_Binary_Tree;

public class Solution
{
  public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
  {
    var result = new List<int>();
    if (k == 0)
      result.Add(target.val);
    else
      Find(root);
    return result;

    int Find(TreeNode node)
    {
      if (node == null)
        return 0;
      if (node.val == target.val)
      {
        FindDown(node.left, 1);
        FindDown(node.right, 1);
        return 1;
      }
      var depth = Find(node.left);
      if (depth > 0)
      {
        if (depth == k)
          result.Add(node.val);
        else if (depth < k)
          FindDown(node.right, depth + 1);
        return depth + 1;
      }
      depth = Find(node.right);
      if (depth > 0)
      {
        if (depth == k)
          result.Add(node.val);
        else if (depth < k)
          FindDown(node.left, depth + 1);
        return depth + 1;
      }
      return 0;
    }

    void FindDown(TreeNode node, int depth)
    {
      if (node == null)
        return;
      if (depth == k)
      {
        result.Add(node.val);
      }
      else if (depth < k)
      {
        FindDown(node.left, depth + 1);
        FindDown(node.right, depth + 1);
      }
    }
  }
}
