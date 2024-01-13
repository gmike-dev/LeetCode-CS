using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Binary_Trees._95._Unique_Binary_Search_Trees_II;

public class TreeNode
{
  public int val;
  public TreeNode left;
  public TreeNode right;

  public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
  {
    this.val = val;
    this.left = left;
    this.right = right;
  }
}

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