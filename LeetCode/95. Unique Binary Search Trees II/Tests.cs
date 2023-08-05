using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._95._Unique_Binary_Search_Trees_II;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().GenerateTrees(1).Should()
      .BeEquivalentTo(new[] { new TreeNode(1) });

    new Solution().GenerateTrees(3).Should()
      .BeEquivalentTo(new[]
      {
        new TreeNode(1, null, new TreeNode(2, null, new TreeNode(3))),
        new TreeNode(1, null, new TreeNode(3, new TreeNode(2))),
        new TreeNode(2, new TreeNode(1), new TreeNode(3)),
        new TreeNode(3, new TreeNode(2, new TreeNode(1))),
        new TreeNode(3, new TreeNode(1, null, new TreeNode(2)))
      }, config => config.WithoutStrictOrdering());
  }
}