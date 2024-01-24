// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable InconsistentNaming
namespace LeetCode.__BinaryTrees;

public class TreeNode
{
  public int val;
  public TreeNode left;
  public TreeNode right;

  public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
  {
    this.val = val;
    this.left = left;
    this.right = right;
  }
}