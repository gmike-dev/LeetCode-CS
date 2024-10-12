using LeetCode.Common;

namespace LeetCode.BinaryTrees._894._All_Possible_Full_Binary_Trees;

public class Solution
{
  private readonly Dictionary<int, List<TreeNode>> cache = new();

  public IList<TreeNode> AllPossibleFBT(int n)
  {
    if (n % 2 == 0)
      return Array.Empty<TreeNode>();

    if (cache.TryGetValue(n, out var result))
      return result;

    if (n == 1)
    {
      result = new List<TreeNode> { new() };
    }
    else
    {
      result = new List<TreeNode>();
      for (var i = 1; i < n - 1; i += 2)
      {
        var leftNodes = AllPossibleFBT(i);
        var rightNodes = AllPossibleFBT(n - 1 - i);
        foreach (var leftNode in leftNodes)
        {
          foreach (var rightNode in rightNodes)
          {
            result.Add(new TreeNode(0, leftNode, rightNode));
          }
        }
      }
    }
    cache[n] = result;
    return result;
  }
}
