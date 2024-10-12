using LeetCode.Common;

namespace LeetCode.BinaryTrees._94._Binary_Tree_Inorder_Traversal;

public class RecursiveSolution
{
  public IList<int> InorderTraversal(TreeNode root)
  {
    var result = new List<int>();
    Traverse(root, result);
    return result;
  }

  private static void Traverse(TreeNode root, List<int> result)
  {
    if (root != null)
    {
      Traverse(root.left, result);
      result.Add(root.val);
      Traverse(root.right, result);
    }
  }
}

[TestFixture]
public class RecursiveSolutionTests
{
  [Test]
  public void Test1()
  {
    new RecursiveSolution().InorderTraversal(TreeNode.FromString("1,2,3,null,4,5,6,null,null,null,null,null,7"))
      .Should().BeEquivalentTo(new[] { 2, 4, 1, 5, 3, 6, 7 }, o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new RecursiveSolution().InorderTraversal(TreeNode.FromString("")).Should().BeEmpty();
  }
}
