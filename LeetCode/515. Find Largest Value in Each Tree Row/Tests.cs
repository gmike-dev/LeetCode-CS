using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._515._Find_Largest_Value_in_Each_Tree_Row;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new SolutionUsingBfs().LargestValues(new TreeNode(1,
        new TreeNode(3, new TreeNode(5), new TreeNode(3)),
        new TreeNode(2, null, new TreeNode(9))))
      .Should()
      .BeEquivalentTo(new[] { 1, 3, 9 }, o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new SolutionUsingBfs().LargestValues(new TreeNode(1, new TreeNode(2), new TreeNode(3)))
      .Should()
      .BeEquivalentTo(new[] { 1, 3 }, o => o.WithStrictOrdering());
  }
}