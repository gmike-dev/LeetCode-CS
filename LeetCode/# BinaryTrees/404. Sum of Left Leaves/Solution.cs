namespace LeetCode.__BinaryTrees._404._Sum_of_Left_Leaves;

public class Solution
{
  public int SumOfLeftLeaves(TreeNode root, bool left = false)
  {
    if (root == null)
      return 0;
    if (left && root.left == null && root.right == null)
      return root.val;
    return SumOfLeftLeaves(root.left, true) + SumOfLeftLeaves(root.right);
  }
}

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().SumOfLeftLeaves(
      new TreeNode(3,
        new TreeNode(9),
        new TreeNode(20,
          new TreeNode(15),
          new TreeNode(7)))).Should().Be(24);
  }

  [Test]
  public void Test2()
  {
    new Solution().SumOfLeftLeaves(new TreeNode(1)).Should().Be(0);
  }
}
