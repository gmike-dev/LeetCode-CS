using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.__BinaryTrees._94._Binary_Tree_Inorder_Traversal;

public class IterativeSolution
{
  public IList<int> InorderTraversal(TreeNode root)
  {
    var result = new List<int>();
    var s = new Stack<TreeNode>();
    while (root != null || s.Count != 0)
    {
      while (root != null)
      {
        s.Push(root);
        root = root.left;
      }
      root = s.Pop();
      result.Add(root.val);
      root = root.right;
    }
    return result;
  }
}

[TestFixture]
public class IterativeSolutionTests
{
  [Test]
  public void Test1()
  {
    new IterativeSolution().InorderTraversal(new TreeNode(1,
        new TreeNode(2, null, new TreeNode(4)),
        new TreeNode(3, new TreeNode(5), new TreeNode(6, null, new TreeNode(7)))))
      .Should().BeEquivalentTo(new[] { 2, 4, 1, 5, 3, 6, 7 }, o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new IterativeSolution().InorderTraversal(null).Should().BeEmpty();
  }

}