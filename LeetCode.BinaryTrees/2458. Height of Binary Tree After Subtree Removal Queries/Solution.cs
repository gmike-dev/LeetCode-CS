using LeetCode.Common;

namespace LeetCode.BinaryTrees._2458._Height_of_Binary_Tree_After_Subtree_Removal_Queries;

public class Solution
{
  public int[] TreeQueries(TreeNode root, int[] queries)
  {
    var height = new Dictionary<int, int>();
    var highestNodesAtLevel = new Dictionary<int, List<int>>();
    var levels = new Dictionary<int, int>();
    Dfs(root, 0);
    var rootHeight = height[root.val];
    var result = new int[queries.Length];
    for (var i = 0; i < queries.Length; i++)
    {
      var q = queries[i];
      var h = height[q];
      var l = levels[q];
      if (highestNodesAtLevel[l].Count == 1)
      {
        result[i] = rootHeight - h - 1;
      }
      else
      {
        var highestNode = highestNodesAtLevel[l][0];
        if (highestNode == q)
          highestNode = highestNodesAtLevel[l][1];
        result[i] = rootHeight - Math.Max(0, h - height[highestNode]);
      }
    }
    return result;

    int Dfs(TreeNode node, int level)
    {
      levels[node.val] = level;
      var h = 0;
      if (node.left != null)
        h = Dfs(node.left, level + 1) + 1;
      if (node.right != null)
        h = Math.Max(h, Dfs(node.right, level + 1) + 1);
      height[node.val] = h;
      if (highestNodesAtLevel.TryGetValue(level, out var nodes))
      {
        if (h > height[nodes[0]])
        {
          if (nodes.Count == 1)
          {
            nodes.Insert(0, node.val);
          }
          else
          {
            nodes[1] = nodes[0];
            nodes[0] = node.val;
          }
        }
        else if (nodes.Count == 1)
        {
          nodes.Add(node.val);
        }
        else if (h > height[nodes[1]])
        {
          nodes[1] = node.val;
        }
      }
      else
      {
        highestNodesAtLevel.Add(level, [node.val]);
      }
      return h;
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("[1,3,4,2,null,6,5,null,null,null,null,null,7]", new[] { 4 }, new[] { 2 })]
  [TestCase("[5,8,9,2,1,3,7,4,6]", new[] { 3, 2, 4, 8 }, new[] { 3, 2, 3, 2 })]
  [TestCase("[1,null,5,3,null,2,4]", new[] { 3, 5, 4, 2, 4 }, new[] { 1, 0, 3, 3, 3 })]
  public void Test(string root, int[] queries, int[] expected)
  {
    new Solution().TreeQueries(TreeNode.FromString(root), queries)
      .Should()
      .BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
