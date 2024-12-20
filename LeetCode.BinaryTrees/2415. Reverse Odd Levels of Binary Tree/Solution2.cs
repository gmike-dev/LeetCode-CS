using LeetCode.Common;

namespace LeetCode.BinaryTrees._2415._Reverse_Odd_Levels_of_Binary_Tree;

public class Solution2
{
  public TreeNode ReverseOddLevels(TreeNode root)
  {
    Dfs(root.left, root.right, 0);
    return root;
  }

  private static void Dfs(TreeNode node1, TreeNode node2, int level)
  {
    if (node1 == null)
      return;
    if (level % 2 == 0)
      (node1.val, node2.val) = (node2.val, node1.val);
    Dfs(node1.left, node2.right, level + 1);
    Dfs(node1.right, node2.left, level + 1);
  }
}

[TestFixture]
public class Solution2Tests
{
  [TestCase("[2,3,5,8,13,21,34]", "[2,5,3,8,13,21,34]")]
  [TestCase("[7,13,11]", "[7,11,13]")]
  [TestCase("[0,1,2,0,0,0,0,1,1,1,1,2,2,2,2]", "[0,2,1,0,0,0,0,2,2,2,2,1,1,1,1]")]
  public void Test(string root, string expected)
  {
    var actual = new Solution2().ReverseOddLevels(TreeNode.FromString(root));
    TreeNode.ToString(actual).Should().Be(expected);
  }
}
