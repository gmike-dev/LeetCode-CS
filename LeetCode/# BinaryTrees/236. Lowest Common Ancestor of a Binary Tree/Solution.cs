namespace LeetCode.__BinaryTrees._236._Lowest_Common_Ancestor_of_a_Binary_Tree;

public class Solution
{
  public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
  {
    if (root == null || root.val == p.val || root.val == q.val)
      return root;
    var left = LowestCommonAncestor(root.left, p, q);
    var right = LowestCommonAncestor(root.right, p, q);
    return left != null && right != null ? root : left ?? right;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("[3,5,1,6,2,0,8,null,null,7,4]", 5, 1, 3)]
  [TestCase("[3,5,1,6,2,0,8,null,null,7,4]", 5, 4, 5)]
  [TestCase("[1,2]", 1, 2, 1)]
  public void Test(string root, int p, int q, int expected)
  {
    new Solution().LowestCommonAncestor(
        TreeNode.FromString(root), new TreeNode(p), new TreeNode(q))
      .val.Should().Be(expected);
  }
}
