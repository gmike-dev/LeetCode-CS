using LeetCode.Common;

namespace LeetCode.BinaryTrees._2583._Kth_Largest_Sum_in_a_Binary_Tree;

public class Solution
{
  public long KthLargestLevelSum(TreeNode root, int k)
  {
    var levelSum = new List<long>();
    FillSums(root, 1);
    if (levelSum.Count < k)
      return -1;
    levelSum.Sort((x, y) => y.CompareTo(x));
    return levelSum[k - 1];

    void FillSums(TreeNode node, int level)
    {
      if (node == null)
        return;
      if (level > levelSum.Count)
        levelSum.Add(node.val);
      else
        levelSum[level - 1] += node.val;
      FillSums(node.left, level + 1);
      FillSums(node.right, level + 1);
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("[5,8,9,2,1,3,7,4,6]", 2, 13L)]
  [TestCase("[1,2,null,3]", 1, 3)]
  public void Test(string root, int k, long expected)
  {
    new Solution().KthLargestLevelSum(TreeNode.FromString(root), k).Should().Be(expected);
  }
}
