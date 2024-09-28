namespace LeetCode.__BinaryTrees._222._Count_Complete_Tree_Nodes;

public class LinearSolution
{
  public int CountNodes(TreeNode root)
  {
    return root == null ? 0 : 1 + CountNodes(root.left) + CountNodes(root.right);
  }
}

[TestFixture]
public class LinearSolutionTests
{
  [TestCase("[]", 0)]
  [TestCase("[1]", 1)]
  [TestCase("[1,2]", 2)]
  [TestCase("[1,2,3]", 3)]
  [TestCase("[1,2,3,4]", 4)]
  [TestCase("[1,2,3,4,5]", 5)]
  [TestCase("[1,2,3,4,5,6]", 6)]
  public void Test(string treeStr, int expected)
  {
    new LinearSolution().CountNodes(TreeNode.FromString(treeStr)).Should().Be(expected);
  }
}
