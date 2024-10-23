using LeetCode.Common;

namespace LeetCode.BinaryTrees._2641._Cousins_in_Binary_Tree_II;

public class Solution
{
  public TreeNode ReplaceValueInTree(TreeNode root)
  {
    root.val = 0;
    List<TreeNode> q = [root];
    while (q.Count > 0)
    {
      var qq = new List<TreeNode>();
      var s = q.Sum(node => (node.left?.val ?? 0) + (node.right?.val ?? 0));
      foreach (var node in q)
      {
        var ss = (node.left?.val ?? 0) + (node.right?.val ?? 0);
        if (node.left != null)
        {
          node.left.val = s - ss;
          qq.Add(node.left);
        }
        if (node.right != null)
        {
          node.right.val = s - ss;
          qq.Add(node.right);
        }
      }
      q = qq;
    }
    return root;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("[5,4,9,1,10,null,7]", "[0,0,0,7,7,null,11]")]
  [TestCase("[3,1,2]", "[0,0,0]")]
  public void Test(string root, string expected)
  {
    TreeNode.ToString(new Solution().ReplaceValueInTree(TreeNode.FromString(root))).Should().Be(expected);
  }
}
