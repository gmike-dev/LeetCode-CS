using LeetCode.Common;

namespace LeetCode.BinaryTrees._1038._Binary_Search_Tree_to_Greater_Sum_Tree;

public class Solution
{
  public TreeNode BstToGst(TreeNode root)
  {
    ToGreaterSumTree(root, 0);
    return root;
  }

  private static int ToGreaterSumTree(TreeNode root, int s)
  {
    while (root != null)
    {
      root.val += ToGreaterSumTree(root.right, s);
      s = root.val;
      root = root.left;
    }
    return s;
  }
}

[TestFixture]
public class Tests
{
  [TestCase("[4,1,6,0,2,5,7,null,null,null,3,null,null,null,8]", "[30,36,21,36,35,26,15,null,null,null,33,null,null,null,8]")]
  [TestCase("[0,null,1]", "[1,null,1]")]
  public void Test(string root, string expected)
  {
    var actual = new Solution().BstToGst(TreeNode.FromString(root));
    TreeNode.ToString(actual).Should().Be(expected);
  }
}
