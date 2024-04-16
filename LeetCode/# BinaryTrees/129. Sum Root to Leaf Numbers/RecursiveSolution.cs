namespace LeetCode.__BinaryTrees._129._Sum_Root_to_Leaf_Numbers;

public class RecursiveSolution
{
  public int SumNumbers(TreeNode root)
  {
    var result = 0;
    Sum(root, 0);
    return result;

    void Sum(TreeNode node, int s)
    {
      s = s * 10 + node.val;
      if (node.left == null && node.right == null)
      {
        result += s;
      }
      else
      {
        if (node.left != null)
          Sum(node.left, s);
        if (node.right != null)
          Sum(node.right, s);
      }
    }
  }
}

[TestFixture]
public class RecursiveSolutionTests
{
  [Test]
  public void Test1()
  {
    new RecursiveSolution().SumNumbers(
      new TreeNode(1,
        new TreeNode(2),
        new TreeNode(3))).Should().Be(25);
  }

  [Test]
  public void Test2()
  {
    new RecursiveSolution().SumNumbers(
      new TreeNode(4,
        new TreeNode(9,
          new TreeNode(5),
          new TreeNode(1)),
        new TreeNode(0))).Should().Be(1026);
  }
}
