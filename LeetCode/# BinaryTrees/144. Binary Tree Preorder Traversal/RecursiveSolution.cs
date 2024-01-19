using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.__BinaryTrees._144._Binary_Tree_Preorder_Traversal;

public class RecursiveSolution
{
  public IList<int> PreorderTraversal(TreeNode root)
  {
    var result = new List<int>();
    Traverse(root);
    return result;
    
    void Traverse(TreeNode node)
    {
      if (node is null)
        return;
      result.Add(node.val);
      Traverse(node.left);
      Traverse(node.right);
    }
  }
}

[TestFixture]
public class RecursiveSolutionTests
{
  [Test]
  public void Test1()
  {
    var tree = new TreeNode(1, null, new(2, new(3)));
    var solution = new RecursiveSolution();
    solution.PreorderTraversal(tree).Should().BeEquivalentTo(
      new[] { 1, 2, 3 }, o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new RecursiveSolution().PreorderTraversal(null).Should().BeEmpty();
  }

  [Test]
  public void Test3()
  {
    new RecursiveSolution().PreorderTraversal(new(1)).Should()
      .BeEquivalentTo(new[] { 1 });
  }
}