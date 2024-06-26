namespace LeetCode.__BinaryTrees._1382._Balance_a_Binary_Search_Tree;

public class Solution
{
  // ReSharper disable once InconsistentNaming
  public TreeNode BalanceBST(TreeNode root)
  {
    var values = InorderTraversal(root);
    return BuildTree(0, values.Count - 1);

    TreeNode BuildTree(int l, int r)
    {
      if (l > r)
        return null;
      var mid = l + (r - l) / 2;
      return new TreeNode(values[mid])
      {
        left = BuildTree(l, mid - 1),
        right = BuildTree(mid + 1, r)
      };
    }
  }

  private static List<int> InorderTraversal(TreeNode node)
  {
    var result = new List<int>();
    var s = new Stack<TreeNode>();
    while (node != null || s.Count != 0)
    {
      while (node != null)
      {
        s.Push(node);
        node = node.left;
      }
      node = s.Pop();
      result.Add(node.val);
      node = node.right;
    }
    return result;
  }
}

[TestFixture]
public class Tests
{
  [TestCase("1,null,2,null,3,null,4,null,null", "2,1,3,null,null,null,4")]
  [TestCase("2,1,3", "2,1,3")]
  [TestCase("1,null,15,14,17,7,null,null,null,2,12,null,3,9,null,null,null,null,11", "9,2,14,1,3,11,15,null,null,null,7,null,12,null,17")]
  public void Test1(string root, string expected)
  {
    var result = new Solution().BalanceBST(TreeNode.FromString(root));
    TreeNode.ToString(result).Should().Be(expected);
  }
}
