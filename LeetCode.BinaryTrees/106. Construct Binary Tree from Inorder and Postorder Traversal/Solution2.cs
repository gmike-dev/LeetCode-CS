using LeetCode.Common;

namespace LeetCode.BinaryTrees._106._Construct_Binary_Tree_from_Inorder_and_Postorder_Traversal;

public class Solution2
{
  public TreeNode BuildTree(int[] inorder, int[] postorder)
  {
    var n = inorder.Length;
    var index = new Dictionary<int, int>(n);
    for (var i = 0; i < n; i++)
    {
      index[inorder[i]] = i;
    }
    return Build(0, n - 1, 0, n - 1);

    TreeNode Build(int inStart, int inEnd, int postStart, int postEnd)
    {
      if (inStart > inEnd)
      {
        return null;
      }
      var rootValue = postorder[postEnd];
      var i = index[rootValue];
      var k = i - inStart;
      return new TreeNode(rootValue,
        Build(inStart, i - 1, postStart, postStart + k - 1),
        Build(i + 1, inEnd, postStart + k, postEnd - 1));
    }
  }
}

[TestFixture]
public class Solution2Tests
{
  [TestCase("[9,3,15,20,7]", "[9,15,7,20,3]", "[3,9,20,null,null,15,7]")]
  [TestCase("[-1]", "[-1]", "[-1]")]
  public void Test(string inorder, string postorder, string expected)
  {
    var actual = TreeNode.ToString(
      new Solution2().BuildTree(inorder.Array(), postorder.Array()));
    actual.Should().Be(expected);
  }
}
