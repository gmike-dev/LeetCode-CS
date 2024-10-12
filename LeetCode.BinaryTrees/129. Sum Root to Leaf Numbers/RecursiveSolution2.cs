using LeetCode.Common;

namespace LeetCode.BinaryTrees._129._Sum_Root_to_Leaf_Numbers;

public class RecursiveSolution2
{
  public int SumNumbers(TreeNode node, int s = 0)
  {
    s = s * 10 + node.val;
    
    if (node.left == null && node.right == null)
      return s;

    var result = 0;
    if (node.left != null)
      result += SumNumbers(node.left, s);
    if (node.right != null)
      result += SumNumbers(node.right, s);
    return result;
  }
}

[TestFixture]
public class RecursiveSolution2Tests
{
  [Test]
  public void Test1()
  {
    new RecursiveSolution2().SumNumbers(
      new TreeNode(1,
        new TreeNode(2),
        new TreeNode(3))).Should().Be(25);
  }

  [Test]
  public void Test2()
  {
    new RecursiveSolution2().SumNumbers(
      new TreeNode(4,
        new TreeNode(9,
          new TreeNode(5),
          new TreeNode(1)),
        new TreeNode(0))).Should().Be(1026);
  }
}
