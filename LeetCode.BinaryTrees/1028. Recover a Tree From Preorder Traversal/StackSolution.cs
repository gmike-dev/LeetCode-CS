using LeetCode.Common;

namespace LeetCode.BinaryTrees._1028._Recover_a_Tree_From_Preorder_Traversal;

public class StackSolution
{
  public TreeNode RecoverFromPreorder(string traversal)
  {
    var s = new Stack<TreeNode>();
    for (var i = 0; i < traversal.Length;)
    {
      var depth = 0;
      for (; i < traversal.Length && traversal[i] == '-'; i++)
        depth++;
      var value = 0;
      for (; i < traversal.Length && char.IsNumber(traversal[i]); i++)
        value = 10 * value + traversal[i] - '0';
      var node = new TreeNode(value);
      while (s.Count > depth)
        s.Pop();
      if (s.Count != 0)
      {
        var parent = s.Peek();
        if (parent.left == null)
          parent.left = node;
        else
          parent.right = node;
      }
      s.Push(node);
    }
    while (s.Count != 1)
      s.Pop();
    return s.Peek();
  }
}

[TestFixture]
public class StackSolutionTests
{
  [TestCase("1-2--3--4-5--6--7", "[1,2,5,3,4,6,7]")]
  [TestCase("1-2--3---4-5--6---7", "[1,2,5,3,null,6,null,4,null,7]")]
  [TestCase("1", "[1]")]
  [TestCase("1-2", "[1,2]")]
  public void Test(string traversal, string expected)
  {
    TreeNode.ToString(new StackSolution().RecoverFromPreorder(traversal)).Should().Be(expected);
  }
}
