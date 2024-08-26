// ReSharper disable All
namespace LeetCode.__Graphs._590._N_ary_Tree_Postorder_Traversal;

public class Node
{
  public int val;
  public IList<Node> children = new List<Node>();

  public Node()
  {
  }

  public Node(int val)
  {
    this.val = val;
  }

  public Node(int val, IList<Node> children)
  {
    this.val = val;
    this.children = children;
  }
}
