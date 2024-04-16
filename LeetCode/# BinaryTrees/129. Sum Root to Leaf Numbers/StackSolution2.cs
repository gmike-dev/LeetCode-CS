namespace LeetCode.__BinaryTrees._129._Sum_Root_to_Leaf_Numbers;

public class StackSolution2
{
  public int SumNumbers(TreeNode root)
  {
    var result = 0;
    var s = new Stack<(TreeNode, int)>();
    s.Push((root, 0));
    while (s.Count > 0)
    {
      var (node, number) = s.Pop();
      number = number * 10 + node.val;
      if (node.left == null && node.right == null)
      {
        result += number;
      }
      else
      {
        if (node.right != null)
          s.Push((node.right, number));
        if (node.left != null)
          s.Push((node.left, number));
      }
    }
    return result;
  }
}

[TestFixture]
public class StackSolution2Tests
{
  [Test]
  public void Test1()
  {
    new StackSolution2().SumNumbers(
      new TreeNode(1,
        new TreeNode(2),
        new TreeNode(3))).Should().Be(25);
  }

  [Test]
  public void Test2()
  {
    new StackSolution2().SumNumbers(
      new TreeNode(4,
        new TreeNode(9,
          new TreeNode(5),
          new TreeNode(1)),
        new TreeNode(0))).Should().Be(1026);
  }
}
