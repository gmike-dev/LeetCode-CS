using System;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.__BinaryTrees._1026._Maximum_Difference_Between_Node_and_Ancestor;

public class ShortSolution
{
  public int MaxAncestorDiff(TreeNode root)
  {
    return GetMaxDiff(root, root.val, root.val);
  }

  private int GetMaxDiff(TreeNode node, int min, int max)
  {
    if (node == null)
      return Math.Abs(min - max);
    min = Math.Min(node.val, min);
    max = Math.Max(node.val, max);
    return Math.Max(GetMaxDiff(node.left, min, max), GetMaxDiff(node.right, min, max));
  }
}

[TestFixture]
public class ShortSolutionTests
{
  [Test]
  public void Test1()
  {
    new ShortSolution().MaxAncestorDiff(new(8,
      new(3, new(1), new(6, new(4), new(7))),
      new(10, null, new(14, new(13))))).Should().Be(7);
  }

  [Test]
  public void Test2()
  {
    new ShortSolution().MaxAncestorDiff(
        new(1, null, new(2, null, new(0, new(3)))))
      .Should().Be(3);
  }
}