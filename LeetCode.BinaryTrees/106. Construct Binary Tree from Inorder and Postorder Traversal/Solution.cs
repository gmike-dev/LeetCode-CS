using LeetCode.Common;

namespace LeetCode.BinaryTrees._106._Construct_Binary_Tree_from_Inorder_and_Postorder_Traversal;

public class Solution
{
  public TreeNode BuildTree(Span<int> inorder, Span<int> postorder)
  {
    if (inorder.Length == 0)
    {
      return null;
    }
    var rootVal = postorder[^1];
    var result = new TreeNode(rootVal);
    for (var i = 0; i < inorder.Length; i++)
    {
      if (inorder[i] == rootVal)
      {
        result.left = BuildTree(inorder[..i], postorder[..i]);
        result.right = BuildTree(inorder[(i + 1)..], postorder[i..^1]);
        return result;
      }
    }
    return result;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("[9,3,15,20,7]", "[9,15,7,20,3]", "[3,9,20,null,null,15,7]")]
  [TestCase("[-1]", "[-1]", "[-1]")]
  public void Test(string inorder, string postorder, string expected)
  {
    var actual = TreeNode.ToString(
      new Solution().BuildTree(inorder.Array(), postorder.Array()));
    actual.Should().Be(expected);
  }
}
