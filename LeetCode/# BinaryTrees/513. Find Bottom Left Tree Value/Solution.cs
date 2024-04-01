using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.__BinaryTrees._513._Find_Bottom_Left_Tree_Value;

public class Solution
{
  private int maxHeight = -1;
  private int result;

  public int FindBottomLeftValue(TreeNode root, int height = 0)
  {
    if (root == null)
      return result;

    if (maxHeight < height)
    {
      maxHeight = height;
      result = root.val;
    }
    FindBottomLeftValue(root.left, height + 1);
    FindBottomLeftValue(root.right, height + 1);
    return result;
  }
}

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().FindBottomLeftValue(
        new TreeNode(2,
          new TreeNode(1),
          new TreeNode(3)))
      .Should().Be(1);
  }

  [Test]
  public void Test2()
  {
    new Solution().FindBottomLeftValue(
        new TreeNode(1,
          new TreeNode(2,
            new TreeNode(4)),
          new TreeNode(3,
            new TreeNode(5,
              new TreeNode(7)),
            new TreeNode(6))))
      .Should().Be(7);
  }

  [Test]
  public void Test3()
  {
    new Solution().FindBottomLeftValue(
        new TreeNode(0,
          null,
          new TreeNode(-1)))
      .Should().Be(-1);
  }
}
