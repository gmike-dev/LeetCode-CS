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
  [TestCase(1, new[]
  {
    "1"
  })]
  [TestCase(3, new[]
  {
    "1,null,2,null,3",
    "1,null,3,2",
    "2,1,3",
    "3,2,null,1",
    "3,1,null,null,2"
  })]
  public void Test1(int n, string[] trees)
  {
    new Solution().GenerateTrees(n).Should().BeEquivalentTo(
      trees.Select(TreeNode.FromString),
      config => config.WithoutStrictOrdering());
  }
}
