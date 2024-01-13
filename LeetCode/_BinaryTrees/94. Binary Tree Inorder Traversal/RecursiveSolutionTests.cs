using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Binary_Trees._94._Binary_Tree_Inorder_Traversal;

[TestFixture]
public class RecursiveSolutionTests
{
  [Test]
  public void Test1()
  {
    new RecursiveSolution().InorderTraversal(new TreeNode(1,
        new TreeNode(2, null, new TreeNode(4)),
        new TreeNode(3, new TreeNode(5), new TreeNode(6, null, new TreeNode(7)))))
      .Should().BeEquivalentTo(new[] { 2, 4, 1, 5, 3, 6, 7 }, o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new RecursiveSolution().InorderTraversal(null).Should().BeEmpty();
  }
}