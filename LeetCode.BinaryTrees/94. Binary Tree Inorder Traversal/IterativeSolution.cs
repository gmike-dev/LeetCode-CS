using LeetCode.Common;

namespace LeetCode.BinaryTrees._94._Binary_Tree_Inorder_Traversal;

public class IterativeSolution
{
  public IList<int> InorderTraversal(TreeNode root)
  {
    var result = new List<int>();
    var s = new Stack<TreeNode>();
    while (root != null || s.Count != 0)
    {
      while (root != null)
      {
        s.Push(root);
        root = root.left;
      }
      root = s.Pop();
      result.Add(root.val);
      root = root.right;
    }
    return result;
  }
}

[TestFixture]
public class IterativeSolutionTests
{
  [Test]
  public void Test1()
  {
    new IterativeSolution().InorderTraversal(TreeNode.FromString("1,2,3,null,4,5,6,null,null,null,null,null,7"))
      .Should().BeEquivalentTo(new[] { 2, 4, 1, 5, 3, 6, 7 }, o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new IterativeSolution().InorderTraversal(TreeNode.FromString("")).Should().BeEmpty();
  }

}
