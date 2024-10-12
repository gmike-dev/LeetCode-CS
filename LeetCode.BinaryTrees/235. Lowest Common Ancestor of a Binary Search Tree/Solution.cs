using LeetCode.Common;

namespace LeetCode.BinaryTrees._235._Lowest_Common_Ancestor_of_a_Binary_Search_Tree;

public class Solution
{
  public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
  {
    if (p.val > q.val)
      (p, q) = (q, p);
    while (true)
    {
      if (p.val == root.val)
        return p;
      if (q.val == root.val)
        return q;
      if (q.val < root.val)
        root = root.left;
      else if (p.val > root.val)
        root = root.right;
      else
        return root;
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution()
      .LowestCommonAncestor(TreeNode.FromString("[6,2,8,0,4,7,9,null,null,3,5]"), new TreeNode(2), new TreeNode(8))
      .val
      .Should().Be(6);
  }

  [Test]
  public void Test2()
  {
    new Solution()
      .LowestCommonAncestor(TreeNode.FromString("[6,2,8,0,4,7,9,null,null,3,5]"), new TreeNode(2), new TreeNode(4))
      .val
      .Should().Be(2);
  }

  [Test]
  public void Test3()
  {
    new Solution()
      .LowestCommonAncestor(TreeNode.FromString("[2,1]"), new TreeNode(2), new TreeNode(1))
      .val
      .Should().Be(2);
  }
}
