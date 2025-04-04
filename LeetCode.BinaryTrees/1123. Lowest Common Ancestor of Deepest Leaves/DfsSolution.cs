using LeetCode.Common;

namespace LeetCode.BinaryTrees._1123._Lowest_Common_Ancestor_of_Deepest_Leaves;

public class DfsSolution
{
  public TreeNode LcaDeepestLeaves(TreeNode root) => Dfs(root).node;

  private static (TreeNode node, int depth) Dfs(TreeNode node)
  {
    if (node is null)
      return (null, 0);

    var leftLca = Dfs(node.left);
    var rightLca = Dfs(node.right);
    if (leftLca.depth > rightLca.depth)
      return (leftLca.node, leftLca.depth + 1);
    if (leftLca.depth < rightLca.depth)
      return (rightLca.node, rightLca.depth + 1);
    return (node, leftLca.depth + 1);
  }
}

[TestFixture]
public class DfsSolutionTests
{
  [TestCase("[3,5,1,6,2,0,8,null,null,7,4]", "[2,7,4]")]
  [TestCase("[1]", "[1]")]
  [TestCase("[0,1,3,null,2]", "[2]")]
  public void Test(string root, string expected)
  {
    var actual = new DfsSolution().LcaDeepestLeaves(TreeNode.FromString(root));
    TreeNode.ToString(actual).Should().Be(expected);
  }
}
