using LeetCode.Common;

namespace LeetCode.BinaryTrees._1457._Pseudo_Palindromic_Paths_in_a_Binary_Tree;

public class CountingSolution
{
  public int PseudoPalindromicPaths(TreeNode root)
  {
    var digits = new int[10];
    var result = 0;
    Traverse(root);
    return result;

    void Traverse(TreeNode node)
    {
      digits[node.val]++;
      if (node.left != null)
        Traverse(node.left);
      if (node.right != null)
        Traverse(node.right);
      if (node.left == null && node.right == null && CheckPath())
        result++;
      digits[node.val]--;
    }

    bool CheckPath()
    {
      var count = 0;
      foreach (var d in digits)
      {
        if (d % 2 != 0)
        {
          count++;
          if (count > 1)
            return false;
        }
      }
      return true;
    }
  }
}

[TestFixture]
public class CountingSolutionTests
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
