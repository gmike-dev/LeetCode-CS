using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.__BinaryTrees._144._Binary_Tree_Preorder_Traversal;

public class RecursiveSolution2
{
  public IList<int> PreorderTraversal(TreeNode root)
  {
    var result = new List<int>();
    Traverse(root);
    return result;
    
    void Traverse(TreeNode node)
    {
      while (node != null)
      {
        result.Add(node.val);
        Traverse(node.left);
        node = node.right;
      }
    }
  }
}

[TestFixture]
public class RecursiveSolution2Tests
{
  [Test]
  public void Test1()
  {
    var tree = new TreeNode(1, null, new(2, new(3)));
    var solution = new RecursiveSolution2();
    solution.PreorderTraversal(tree).Should().BeEquivalentTo(
      new[] { 1, 2, 3 }, o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new RecursiveSolution2().PreorderTraversal(null).Should().BeEmpty();
  }

  [Test]
  public void Test3()
  {
    new RecursiveSolution2().PreorderTraversal(new(1)).Should()
      .BeEquivalentTo(new[] { 1 });
  }
}