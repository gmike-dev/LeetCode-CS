using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.__BinaryTrees._144._Binary_Tree_Preorder_Traversal;

public class IterativeSolution
{
  public IList<int> PreorderTraversal(TreeNode root)
  {
    if (root == null)
      return Array.Empty<int>();
    var result = new List<int>();
    var s = new Stack<TreeNode>();
    s.Push(root);
    while (s.Count != 0)
    {
      var node = s.Pop();
      result.Add(node.val);
      if (node.right != null)
        s.Push(node.right);
      if (node.left != null)
        s.Push(node.left);
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
    var tree = new TreeNode(1, null, new(2, new(3)));
    var solution = new IterativeSolution();
    solution.PreorderTraversal(tree).Should().BeEquivalentTo(
      new[] { 1, 2, 3 }, o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new IterativeSolution().PreorderTraversal(null).Should().BeEmpty();
  }

  [Test]
  public void Test3()
  {
    new IterativeSolution().PreorderTraversal(new(1)).Should()
      .BeEquivalentTo(new[] { 1 });
  }
}