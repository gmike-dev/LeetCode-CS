using LeetCode.Common;

namespace LeetCode.BinaryTrees._515._Find_Largest_Value_in_Each_Tree_Row;

public class SolutionUsingBfs
{
  public IList<int> LargestValues(TreeNode root)
  {
    if (root == null)
      return Array.Empty<int>();
    var q = new Queue<TreeNode>();
    var ans = new List<int>();
    q.Enqueue(root);
    while (q.Count > 0)
    {
      var n = q.Count;
      var m = int.MinValue;
      for (var i = 0; i < n; i++)
      {
        var node = q.Dequeue();
        if (node.val > m)
          m = node.val;
        if (node.left != null)
          q.Enqueue(node.left);
        if (node.right != null)
          q.Enqueue(node.right);
      }
      ans.Add(m);
    }
    return ans;
  }
}

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new SolutionUsingBfs().LargestValues(new TreeNode(1,
        new TreeNode(3, new TreeNode(5), new TreeNode(3)),
        new TreeNode(2, null, new TreeNode(9))))
      .Should()
      .BeEquivalentTo(new[] { 1, 3, 9 }, o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new SolutionUsingBfs().LargestValues(new TreeNode(1, new TreeNode(2), new TreeNode(3)))
      .Should()
      .BeEquivalentTo(new[] { 1, 3 }, o => o.WithStrictOrdering());
  }
}
