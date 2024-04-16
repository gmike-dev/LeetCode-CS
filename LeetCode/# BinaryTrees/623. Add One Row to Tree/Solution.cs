namespace LeetCode.__BinaryTrees._623._Add_One_Row_to_Tree;

public class Solution
{
  public TreeNode AddOneRow(TreeNode root, int val, int depth)
  {
    if (depth == 1)
      return new TreeNode(val, root);

    InsertRow(root, 1);

    void InsertRow(TreeNode parent, int level)
    {
      if (level == depth - 1)
      {
        parent.left = new TreeNode(val, parent.left, null);
        parent.right = new TreeNode(val, null, parent.right);
      }
      else
      {
        if (parent.left != null)
          InsertRow(parent.left, level + 1);
        if (parent.right != null)
          InsertRow(parent.right, level + 1);
      }
    }

    return root;
  }
}

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().AddOneRow(
        new TreeNode(4,
          new TreeNode(2,
            new TreeNode(3),
            new TreeNode(1)),
          new TreeNode(6,
            new TreeNode(5))),
        1, 2)
      .Should().BeEquivalentTo(
        new TreeNode(4,
          new TreeNode(1,
            new TreeNode(2,
              new TreeNode(3),
              new TreeNode(1))),
          new TreeNode(1,
            null,
            new TreeNode(6,
              new TreeNode(5)))));
  }

  [Test]
  public void Test2()
  {
    new Solution().AddOneRow(
        new TreeNode(4,
          new TreeNode(2,
            new TreeNode(3),
            new TreeNode(1))),
        1, 3)
      .Should().BeEquivalentTo(
        new TreeNode(4,
          new TreeNode(2,
            new TreeNode(1,
              new TreeNode(3)),
            new TreeNode(1,
              null,
              new TreeNode(1)))));
  }

  [Test]
  public void Test3()
  {
    new Solution().AddOneRow(
        new TreeNode(1,
          new TreeNode(2),
          new TreeNode(3)),
        5, 1)
      .Should().BeEquivalentTo(
        new TreeNode(5,
          new TreeNode(1,
            new TreeNode(2),
            new TreeNode(3))));
  }
}
