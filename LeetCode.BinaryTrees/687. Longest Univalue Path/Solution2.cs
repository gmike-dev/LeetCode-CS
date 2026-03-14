using LeetCode.Common;

namespace LeetCode.BinaryTrees._687._Longest_Univalue_Path;

/// <summary>
/// https://leetcode.com/problems/longest-univalue-path/
/// </summary>
public class Solution2
{
  public int LongestUnivaluePath(TreeNode root)
  {
    var result = Dfs(root);
    return result.best;

    (int down, int best) Dfs(TreeNode node)
    {
      if (node == null)
      {
        return (0, 0);
      }
      (int leftDown, int leftBest) = Dfs(node.left);
      (int rightDown, int rightBest) = Dfs(node.right);
      int leftPath = 0;
      int rightPath = 0;
      if (node.left?.val == node.val)
      {
        leftPath = leftDown + 1;
      }
      if (node.right?.val == node.val)
      {
        rightPath = rightDown + 1;
      }
      int down = Math.Max(leftPath, rightPath);
      int through = leftPath + rightPath;
      int best = Math.Max(Math.Max(leftBest, rightBest), through);
      return (down, best);
    }
  }
}

[TestFixture]
public class Solution2Tests
{
  [TestCase("[5,4,5,1,1,null,5]", 2)]
  [TestCase("[1,4,5,4,4,null,5]", 2)]
  public void Test(string root, int expected)
  {
    new Solution2().LongestUnivaluePath(TreeNode.FromString(root)).Should().Be(expected);
  }
}
