using LeetCode.Common;

namespace LeetCode.BinaryTrees._1028._Recover_a_Tree_From_Preorder_Traversal;

public class Solution
{
  public TreeNode RecoverFromPreorder(string traversal)
  {
    var pos = 0;
    return F(0);

    TreeNode F(int depth)
    {
      if (pos == traversal.Length)
        return null;
      var d = 0;
      for (var i = pos; i < traversal.Length && traversal[i] == '-'; i++)
        d++;
      if (d != depth)
        return null;
      pos += d;
      var value = 0;
      for (; pos < traversal.Length && char.IsNumber(traversal[pos]); pos++)
        value = 10 * value + traversal[pos] - '0';
      return new TreeNode(value)
      {
        left = F(depth + 1),
        right = F(depth + 1)
      };
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("1-2--3--4-5--6--7", "[1,2,5,3,4,6,7]")]
  [TestCase("1-2--3---4-5--6---7", "[1,2,5,3,null,6,null,4,null,7]")]
  [TestCase("1", "[1]")]
  [TestCase("1-2", "[1,2]")]
  public void Test(string traversal, string expected)
  {
    TreeNode.ToString(new Solution().RecoverFromPreorder(traversal)).Should().Be(expected);
  }
}
