namespace LeetCode.__BinaryTrees._2385._Amount_of_Time_for_Binary_Tree_to_Be_Infected;

public class BfsTwoPassSolution
{
  private Dictionary<TreeNode, TreeNode> parent;

  public int AmountOfTime(TreeNode root, int start)
  {
    parent = new();
    parent[root] = null;
    FindParents(root);

    var startNode = parent.Keys.First(node => node.val == start);
    var infected = new HashSet<TreeNode> { startNode };
    var q = new List<TreeNode> { startNode };
    var minute = 0;
    while (q.Count != 0)
    {
      var nodes = q.ToArray();
      q.Clear();
      foreach (var node in nodes)
      {
        InfectNode(parent[node]);
        InfectNode(node.left);
        InfectNode(node.right);
      }
      minute++;
    }
    return minute - 1;

    void InfectNode(TreeNode node)
    {
      if (node != null && !infected.Contains(node))
      {
        q.Add(node);
        infected.Add(node);
      }
    }
  }

  private void FindParents(TreeNode root)
  {
    if (root.left != null)
    {
      parent[root.left] = root;
      FindParents(root.left);
    }
    if (root.right != null)
    {
      parent[root.right] = root;
      FindParents(root.right);
    }
  }
}

[TestFixture]
public class BfsTwoPassSolutionTests
{
  [Test]
  public void Test1()
  {
    new BfsTwoPassSolution().AmountOfTime(
      new TreeNode(1,
        new TreeNode(5, null, new TreeNode(4, new TreeNode(9), new TreeNode(2))),
        new TreeNode(3, new TreeNode(10), new TreeNode(6))),
      3).Should().Be(4);
  }

  [Test]
  public void Test2()
  {
    new BfsTwoPassSolution().AmountOfTime(new TreeNode(1), 1).Should().Be(0);
  }
}
