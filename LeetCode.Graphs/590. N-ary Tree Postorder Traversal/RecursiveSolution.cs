using LeetCode.__Graphs._590._N_ary_Tree_Postorder_Traversal;

namespace LeetCode.Graphs._590._N_ary_Tree_Postorder_Traversal;

public class RecursiveSolution
{
  public IList<int> Postorder(Node root)
  {
    var result = new List<int>();
    Postorder(root, result);
    return result;
  }

  private static void Postorder(Node root, List<int> nodes)
  {
    if (root is null)
      return;
    foreach (var children in root.children)
      Postorder(children, nodes);
    nodes.Add(root.val);
  }
}

[TestFixture]
public class RecursiveSolutionTests
{
  [Test]
  public void Test1()
  {
    new RecursiveSolution().Postorder(new Node(1, new List<Node>
    {
      new(3, new List<Node> { new(5), new(6) }),
      new(2),
      new(4)
    })).Should().BeEquivalentTo([5, 6, 3, 2, 4, 1], o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new RecursiveSolution().Postorder(null).Should().BeEmpty();
  }
}
