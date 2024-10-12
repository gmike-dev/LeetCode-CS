using LeetCode.Common;

namespace LeetCode.BinaryTrees._988._Smallest_String_Starting_From_Leaf;

public class Solution
{
  public string SmallestFromLeaf(TreeNode root)
  {
    var result = string.Empty;
    var stack = new Stack<char>();
    Dfs(root);
    return result;

    void Dfs(TreeNode node)
    {
      stack.Push((char)('a' + node.val));
      if (node.left == null && node.right == null)
      {
        var s = new string(stack.ToArray());
        if (result == string.Empty || string.CompareOrdinal(s, result) < 0)
          result = s;
      }
      else
      {
        if (node.left != null)
          Dfs(node.left);
        if (node.right != null)
          Dfs(node.right);
      }
      stack.Pop();
    }
  }
}

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().SmallestFromLeaf(
      new TreeNode(0,
        new TreeNode(1,
          new TreeNode(3),
          new TreeNode(4)),
        new TreeNode(2,
          new TreeNode(3),
          new TreeNode(4)))).Should().Be("dba");
  }

  [Test]
  public void Test2()
  {
    new Solution().SmallestFromLeaf(
      new TreeNode(25,
        new TreeNode(1,
          new TreeNode(1),
          new TreeNode(3)),
        new TreeNode(3,
          new TreeNode(0),
          new TreeNode(2)))).Should().Be("adz");
  }

  [Test]
  public void Test3()
  {
    new Solution().SmallestFromLeaf(
      new TreeNode(2,
        new TreeNode(2,
          null,
          new TreeNode(2,
            new TreeNode(1))),
        new TreeNode(1,
          new TreeNode(0)))).Should().Be("abc");
  }
}
