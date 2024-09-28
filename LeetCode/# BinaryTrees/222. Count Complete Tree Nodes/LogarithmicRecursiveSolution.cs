namespace LeetCode.__BinaryTrees._222._Count_Complete_Tree_Nodes;

public class LogarithmicRecursiveSolution
{
  public int CountNodes(TreeNode root)
  {
    return Count(root);
  }

  private static int Count(TreeNode root)
  {
    if (root == null)
      return 0;
    var leftHeight = CompleteTreeHeight(root.left);
    var rightHeight = CompleteTreeHeight(root.right);
    if (leftHeight == rightHeight)
      return (1 << leftHeight) + Count(root.right);
    return (1 << rightHeight) + Count(root.left);
  }

  private static int CompleteTreeHeight(TreeNode root)
  {
    var leftHeight = 0;
    var leftNode = root;
    while (leftNode != null)
    {
      leftHeight++;
      leftNode = leftNode.left;
    }
    return leftHeight;
  }
}

[TestFixture]
public class LogarithmicRecursiveSolutionTests
{
  [TestCase("[]", 0)]
  [TestCase("[1]", 1)]
  [TestCase("[1,2]", 2)]
  [TestCase("[1,2,3]", 3)]
  [TestCase("[1,2,3,4]", 4)]
  [TestCase("[1,2,3,4,5]", 5)]
  [TestCase("[1,2,3,4,5,6]", 6)]
  public void Test(string treeStr, int expected)
  {
    new LogarithmicRecursiveSolution().CountNodes(TreeNode.FromString(treeStr)).Should().Be(expected);
  }
}
