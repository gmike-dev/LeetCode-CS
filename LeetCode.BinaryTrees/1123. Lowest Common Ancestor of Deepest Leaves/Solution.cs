using LeetCode.Common;

namespace LeetCode.BinaryTrees._1123._Lowest_Common_Ancestor_of_Deepest_Leaves;

public class Solution
{
  public TreeNode LcaDeepestLeaves(TreeNode root)
  {
    var parent = new TreeNode[1001];
    BuildParents(null, root);
    var lca = FindDeepestLeaves();
    while (lca.Count != 1)
    {
      var parents = new HashSet<TreeNode>();
      foreach (var node in lca)
        parents.Add(parent[node.val]);
      lca = parents.ToList();
    }
    return lca[0];

    void BuildParents(TreeNode prev, TreeNode node)
    {
      if (node == null)
        return;
      parent[node.val] = prev;
      BuildParents(node, node.left);
      BuildParents(node, node.right);
    }

    List<TreeNode> FindDeepestLeaves()
    {
      List<TreeNode> current = [root];
      while (true)
      {
        var next = new List<TreeNode>();
        foreach (var node in current)
        {
          if (node.left != null)
            next.Add(node.left);
          if (node.right != null)
            next.Add(node.right);
        }
        if (next.Count == 0)
          return current;
        current = next;
      }
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("[3,5,1,6,2,0,8,null,null,7,4]", "[2,7,4]")]
  [TestCase("[1]", "[1]")]
  [TestCase("[0,1,3,null,2]", "[2]")]
  public void Test(string root, string expected)
  {
    var actual = new Solution().LcaDeepestLeaves(TreeNode.FromString(root));
    TreeNode.ToString(actual).Should().Be(expected);
  }
}
