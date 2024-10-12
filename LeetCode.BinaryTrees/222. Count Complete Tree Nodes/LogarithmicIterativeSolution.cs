using LeetCode.Common;

namespace LeetCode.BinaryTrees._222._Count_Complete_Tree_Nodes;

public class LogarithmicIterativeSolution
{
  public int CountNodes(TreeNode root)
  {
    if (root == null)
      return 0;
    var count = 0;
    var leftHeight = CompleteTreeHeight(root.left);
    do
    {
      var rightHeight = CompleteTreeHeight(root.right);
      if (leftHeight == rightHeight)
      {
        count += 1 << leftHeight;
        root = root.right;
      }
      else
      {
        count += 1 << rightHeight;
        root = root.left;
      }
      leftHeight--;
    }
    while (root != null);

    return count;
  }

  private static int CompleteTreeHeight(TreeNode root)
  {
    var leftHeight = 0;
    while (root != null)
    {
      leftHeight++;
      root = root.left;
    }
    return leftHeight;
  }
}

[TestFixture]
public class LogarithmicIterativeSolutionTests
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
    new LogarithmicIterativeSolution().CountNodes(TreeNode.FromString(treeStr)).Should().Be(expected);
  }
}
