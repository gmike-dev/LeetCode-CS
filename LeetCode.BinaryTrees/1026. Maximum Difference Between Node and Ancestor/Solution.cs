using LeetCode.Common;

namespace LeetCode.BinaryTrees._1026._Maximum_Difference_Between_Node_and_Ancestor;

public class Solution
{
  private int maxAncestorDiff;

  public int MaxAncestorDiff(TreeNode root)
  {
    maxAncestorDiff = 0;
    GetMinMaxAndCalculateDiff(root);
    return maxAncestorDiff;
  }

  private (int Min, int Max) GetMinMaxAndCalculateDiff(TreeNode node)
  {
    var treeMin = node.val;
    var treeMax = node.val;
    var maxDiff = 0;
    if (node.left != null)
    {
      var (leftMin, leftMax) = GetMinMaxAndCalculateDiff(node.left);
      treeMin = Math.Min(treeMin, leftMin);
      treeMax = Math.Max(treeMax, leftMax);
      maxDiff = Math.Max(Math.Abs(node.val - leftMin), Math.Abs(node.val - leftMax));
    }
    if (node.right != null)
    {
      var (rightMin, rightMax) = GetMinMaxAndCalculateDiff(node.right);
      treeMin = Math.Min(treeMin, rightMin);
      treeMax = Math.Max(treeMax, rightMax);
      maxDiff = Math.Max(maxDiff, Math.Max(Math.Abs(node.val - rightMin), Math.Abs(node.val - rightMax)));
    }
    maxAncestorDiff = Math.Max(maxAncestorDiff, maxDiff);
    return (treeMin, treeMax);
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().MaxAncestorDiff(new(8,
      new(3, new(1), new(6, new(4), new(7))),
      new(10, null, new(14, new(13))))).Should().Be(7);
  }

  [Test]
  public void Test2()
  {
    new Solution().MaxAncestorDiff(
        new(1, null, new(2, null, new(0, new(3)))))
      .Should().Be(3);
  }
}
