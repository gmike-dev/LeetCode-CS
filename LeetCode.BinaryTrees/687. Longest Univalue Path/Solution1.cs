using LeetCode.Common;

namespace LeetCode.BinaryTrees._687._Longest_Univalue_Path;

/// <summary>
/// https://leetcode.com/problems/longest-univalue-path/
/// </summary>
public class Solution1
{
  public int LongestUnivaluePath(TreeNode root)
  {
    int longest = 0;
    F(root);
    return longest;

    int F(TreeNode node)
    {
      if (node == null)
      {
        return 0;
      }
      int left = F(node.left);
      int right = F(node.right);
      int leftPath = 0;
      int rightPath = 0;
      if (node.left != null && node.left.val == node.val)
      {
        leftPath = left + 1;
      }
      if (node.right != null && node.right.val == node.val)
      {
        rightPath = right + 1;
      }
      longest = Math.Max(longest, leftPath + rightPath);
      return Math.Max(leftPath, rightPath);
    }
  }
}

[TestFixture]
public class Solution1Tests
{
  [TestCase("[5,4,5,1,1,null,5]", 2)]
  [TestCase("[1,4,5,4,4,null,5]", 2)]
  public void Test(string root, int expected)
  {
    new Solution1().LongestUnivaluePath(TreeNode.FromString(root)).Should().Be(expected);
  }
}
