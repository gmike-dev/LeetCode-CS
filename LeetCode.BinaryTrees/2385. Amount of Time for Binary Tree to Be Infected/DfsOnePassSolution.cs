using LeetCode.Common;

namespace LeetCode.BinaryTrees._2385._Amount_of_Time_for_Binary_Tree_to_Be_Infected;

public class DfsOnePassSolution
{
  private int maxDistance;

  public int AmountOfTime(TreeNode root, int start)
  {
    maxDistance = 0;
    Traverse(root, start);
    return maxDistance;
  }

  private int Traverse(TreeNode node, int start)
  {
    if (node == null)
      return 0;

    var leftHeight = Traverse(node.left, start);
    var rightHeight = Traverse(node.right, start);

    if (node.val == start)
    {
      maxDistance = Math.Max(leftHeight, rightHeight);
      return -1;
    }

    if (leftHeight >= 0 && rightHeight >= 0)
      return Math.Max(leftHeight, rightHeight) + 1;

    var distance = Math.Abs(leftHeight) + Math.Abs(rightHeight);
    maxDistance = Math.Max(maxDistance, distance);
    return Math.Min(leftHeight, rightHeight) - 1;
  }
}

[TestFixture]
public class DfsOnePassSolutionTests
{
  [Test]
  public void Test1()
  {
    new DfsOnePassSolution().AmountOfTime(
      new TreeNode(1,
        new TreeNode(5, null, new TreeNode(4, new TreeNode(9), new TreeNode(2))),
        new TreeNode(3, new TreeNode(10), new TreeNode(6))),
      3).Should().Be(4);
  }

  [Test]
  public void Test2()
  {
    new DfsOnePassSolution().AmountOfTime(new TreeNode(1), 1).Should().Be(0);
  }
}
