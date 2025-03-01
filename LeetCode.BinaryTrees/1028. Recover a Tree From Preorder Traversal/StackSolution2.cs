using LeetCode.Common;

namespace LeetCode.BinaryTrees._1028._Recover_a_Tree_From_Preorder_Traversal;

public class StackSolution2
{
  public TreeNode RecoverFromPreorder(string traversal)
  {
    var levels = new TreeNode[1000];
    var levelsCount = 0;
    for (var i = 0; i < traversal.Length;)
    {
      var depth = 0;
      for (; i < traversal.Length && traversal[i] is '-'; i++)
        depth++;
      var value = 0;
      for (; i < traversal.Length && traversal[i] is >= '0' and <= '9'; i++)
        value = 10 * value + traversal[i] - '0';
      var node = new TreeNode(value);
      if (depth < levelsCount)
        levels[depth] = node;
      else
        levels[levelsCount++] = node;
      if (depth != 0)
      {
        var parent = levels[depth - 1];
        if (parent.left == null)
          parent.left = node;
        else
          parent.right = node;
      }
    }
    return levels[0];
  }
}

[TestFixture]
public class StackSolution2Tests
{
  [TestCase("1-2--3--4-5--6--7", "[1,2,5,3,4,6,7]")]
  [TestCase("1-2--3---4-5--6---7", "[1,2,5,3,null,6,null,4,null,7]")]
  [TestCase("1", "[1]")]
  [TestCase("1-2", "[1,2]")]
  public void Test(string traversal, string expected)
  {
    TreeNode.ToString(new StackSolution2().RecoverFromPreorder(traversal)).Should().Be(expected);
  }
}
