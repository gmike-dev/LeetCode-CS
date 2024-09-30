namespace LeetCode.__BinaryTrees._226._Invert_Binary_Tree;

public class Solution
{
  public TreeNode InvertTree(TreeNode root)
  {
    if (root == null)
      return null;
    var q = new Queue<TreeNode>();
    q.Enqueue(root);
    while (q.Count != 0)
    {
      var node = q.Dequeue();
      if (node.left != null)
        q.Enqueue(node.left);
      if (node.right != null)
        q.Enqueue(node.right);
      (node.left, node.right) = (node.right, node.left);
    }
    return root;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("[4,2,7,1,3,6,9]", "[4,7,2,9,6,3,1]")]
  [TestCase("[2,1,3]", "[2,3,1]")]
  public void Test(string root, string expected)
  {
    TreeNode.ToString(new Solution().InvertTree(TreeNode.FromString(root))).Should().Be(expected);
  }
}
