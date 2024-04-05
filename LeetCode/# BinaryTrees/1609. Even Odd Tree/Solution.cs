namespace LeetCode.__BinaryTrees._1609._Even_Odd_Tree;

public class Solution
{
  private readonly List<int> prev = new();

  public bool IsEvenOddTree(TreeNode root, int depth = 0)
  {
    if (root == null)
      return true;
    if (root.val % 2 == depth % 2)
      return false;
    if (prev.Count <= depth)
    {
      prev.Add(root.val);
    }
    else
    {
      if (depth % 2 == 0 && prev[depth] >= root.val ||
          depth % 2 != 0 && prev[depth] <= root.val)
      {
        return false;
      }
      prev[depth] = root.val;
    }
    return IsEvenOddTree(root.left, depth + 1) &&
           IsEvenOddTree(root.right, depth + 1);
  }
}

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().IsEvenOddTree(
        new TreeNode(1,
          new TreeNode(10,
            new TreeNode(3,
              new TreeNode(12),
              new TreeNode(8))),
          new TreeNode(4,
            new TreeNode(7,
              new TreeNode(6)),
            new TreeNode(9,
              null,
              new TreeNode(2)))))
      .Should().BeTrue();
  }

  [Test]
  public void Test2()
  {
    new Solution().IsEvenOddTree(
        new TreeNode(5,
          new TreeNode(4,
            new TreeNode(3),
            new TreeNode(3)),
          new TreeNode(2,
            new TreeNode(7))))
      .Should().BeFalse();
  }

  [Test]
  public void Test3()
  {
    new Solution().IsEvenOddTree(
        new TreeNode(5,
          new TreeNode(9,
            new TreeNode(3),
            new TreeNode(5)),
          new TreeNode(1,
            new TreeNode(7))))
      .Should().BeFalse();
  }
}
