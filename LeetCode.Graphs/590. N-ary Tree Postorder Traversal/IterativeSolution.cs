using LeetCode.__Graphs._590._N_ary_Tree_Postorder_Traversal;

namespace LeetCode.Graphs._590._N_ary_Tree_Postorder_Traversal;

public class IterativeSolution
{
  public IList<int> Postorder(Node root)
  {
    var result = new List<int>();
    if (root == null)
      return result;
    Stack<Node> s = new();
    s.Push(root);
    while (s.Count > 0)
    {
      var node = s.Pop();
      foreach (var child in node.children)
        s.Push(child);
      result.Add(node.val);
    }
    result.Reverse();
    return result;
  }
}

[TestFixture]
public class IterativeSolutionTests
{
  [Test]
  public void Test1()
  {
    new IterativeSolution().Postorder(new Node(1, new List<Node>
    {
      new(3, new List<Node> { new(5), new(6) }),
      new(2),
      new(4)
    })).Should().BeEquivalentTo([5, 6, 3, 2, 4, 1], o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new IterativeSolution().Postorder(null).Should().BeEmpty();
  }
}
