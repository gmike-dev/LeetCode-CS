using LeetCode.Common;

namespace LeetCode.BinaryTrees._222._Count_Complete_Tree_Nodes;

public class LogarithmicIterativeSolution2
{
  public int CountNodes(TreeNode root)
  {
    var count = 0;
    var leftHeight = LeftHeight(root);
    var rightHeight = RightHeight(root);
    while (leftHeight != rightHeight)
    {
      var leftHeightOfLeft = leftHeight - 1;
      var leftHeightOfRight = LeftHeight(root.right);
      if (leftHeightOfLeft == leftHeightOfRight)
      {
        count += 1 << leftHeightOfLeft;
        root = root.right;
        rightHeight--;
      }
      else
      {
        count += 1 << leftHeightOfRight;
        root = root.left;
        rightHeight = RightHeight(root);
      }
      leftHeight--;
    }
    count += (1 << rightHeight) - 1;
    return count;
  }

  private static int LeftHeight(TreeNode root)
  {
    var leftHeight = 0;
    while (root != null)
    {
      leftHeight++;
      root = root.left;
    }
    return leftHeight;
  }

  private static int RightHeight(TreeNode root)
  {
    var leftHeight = 0;
    while (root != null)
    {
      leftHeight++;
      root = root.right;
    }
    return leftHeight;
  }
}

[TestFixture]
public class LogarithmicIterativeSolution2Tests
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
    new LogarithmicIterativeSolution2().CountNodes(TreeNode.FromString(treeStr)).Should().Be(expected);
  }
}
