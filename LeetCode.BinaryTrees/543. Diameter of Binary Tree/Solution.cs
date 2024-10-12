using LeetCode.Common;

namespace LeetCode.BinaryTrees._543._Diameter_of_Binary_Tree;

public class Solution
{
  public int DiameterOfBinaryTree(TreeNode root)
  {
    var maxDiameter = 0;
    _ = GetHeight(root);
    return maxDiameter;

    int GetHeight(TreeNode node)
    {
      if (node == null)
        return 0;
      var leftHeight = GetHeight(node.left);
      var rightHeight = GetHeight(node.right);
      maxDiameter = Math.Max(maxDiameter, leftHeight + rightHeight);
      return Math.Max(leftHeight, rightHeight) + 1;
    }
  }
}

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().DiameterOfBinaryTree(
        new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3)))
      .Should().Be(3);
  }

  [Test]
  public void Test2()
  {
    new Solution().DiameterOfBinaryTree(new TreeNode(1, new TreeNode(2)))
      .Should().Be(1);
  }
}
