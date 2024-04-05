namespace LeetCode.__BinaryTrees._1457._Pseudo_Palindromic_Paths_in_a_Binary_Tree;

public class BitmasksSolution
{
  public int PseudoPalindromicPaths(TreeNode root)
  {
    var digits = 0;
    var result = 0;
    Traverse(root);
    return result;

    void Traverse(TreeNode node)
    {
      var mask = 1 << node.val;
      digits ^= mask;
      if (node.left == null && node.right == null)
      {
        if (BitOperations.PopCount((uint)digits) <= 1)
          result++;
      }
      else
      {
        if (node.left != null)
          Traverse(node.left);
        if (node.right != null)
          Traverse(node.right);
      }
      digits ^= mask;
    }
  }
}

[TestFixture]
public class BitmasksSolutionTests
{
  [Test]
  public void Test1()
  {
    new BitmasksSolution().PseudoPalindromicPaths(
        new TreeNode(2,
          new TreeNode(3,
            new TreeNode(3),
            new TreeNode(1)),
          new TreeNode(1, null, new TreeNode(1))))
      .Should().Be(2);
  }

  [Test]
  public void Test2()
  {
    new BitmasksSolution().PseudoPalindromicPaths(
        new TreeNode(2,
          new TreeNode(1,
            new TreeNode(1),
            new TreeNode(3,
              null,
              new TreeNode(1))),
          new TreeNode(1)))
      .Should().Be(1);
  }
}
