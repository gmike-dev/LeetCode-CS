namespace LeetCode.__BinaryTrees._129._Sum_Root_to_Leaf_Numbers;

public class StackSolution
{
  public int SumNumbers(TreeNode root)
  {
    var result = 0;
    var s = new Stack<(TreeNode, int)>();
    s.Push((root, root.val));
    while (s.Count > 0)
    {
      var (node, number) = s.Pop();
      while (node.left != null)
      {
        if (node.right != null)
          s.Push((node.right, number * 10 + node.right.val));
        node = node.left;
        number = number * 10 + node.val;
      }
      if (node.right == null)
        result += number;
      else
        s.Push((node.right, number * 10 + node.right.val));
    }
    return result;
  }
}

[TestFixture]
public class StackSolutionTests
{
  [Test]
  public void Test1()
  {
    new StackSolution().SumNumbers(
      new TreeNode(1,
        new TreeNode(2),
        new TreeNode(3))).Should().Be(25);
  }

  [Test]
  public void Test2()
  {
    new StackSolution().SumNumbers(
      new TreeNode(4,
        new TreeNode(9,
          new TreeNode(5),
          new TreeNode(1)),
        new TreeNode(0))).Should().Be(1026);
  }
}
