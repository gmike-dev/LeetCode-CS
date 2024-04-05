namespace LeetCode.__BinaryTrees._95._Unique_Binary_Search_Trees_II;

public class Solution
{
  public IList<TreeNode> GenerateTrees(int n)
  {
    return GenerateTrees(1, n).ToArray();
  }

  private IEnumerable<TreeNode> GenerateTrees(int begin, int end)
  {
    if (begin > end)
      yield return null;
    else if (begin == end)
      yield return new TreeNode(begin);
    else
    {
      for (var i = begin; i <= end; i++)
      {
        foreach (var leftNode in GenerateTrees(begin, i - 1))
        foreach (var rightNode in GenerateTrees(i + 1, end))
          yield return new TreeNode(i, leftNode, rightNode);
      }
    }
  }
}

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
