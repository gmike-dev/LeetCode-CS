namespace LeetCode.__BinaryTrees._404._Sum_of_Left_Leaves;

public class QueueSolution
{
  public int SumOfLeftLeaves(TreeNode root)
  {
    var s = 0;
    var q = new Queue<TreeNode>();
    q.Enqueue(root);
    while (q.Count > 0)
    {
      var node = q.Dequeue();
      if (node.left != null)
      {
        if (node.left.left == null && node.left.right == null)
          s += node.left.val;
        else
          q.Enqueue(node.left);
      }
      if (node.right != null)
        q.Enqueue(node.right);
    }
    return s;
  }
}

[TestFixture]
public class QueueSolutionTests
{
  [Test]
  public void Test1()
  {
    new QueueSolution().SumOfLeftLeaves(
      new TreeNode(3,
        new TreeNode(9),
        new TreeNode(20,
          new TreeNode(15),
          new TreeNode(7)))).Should().Be(24);
  }

  [Test]
  public void Test2()
  {
    new QueueSolution().SumOfLeftLeaves(new TreeNode(1)).Should().Be(0);
  }
}
