// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable InconsistentNaming

namespace LeetCode.__BinaryTrees;

public class TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
{
  public int val = val;
  public TreeNode left = left;
  public TreeNode right = right;

  public static TreeNode FromString(string s)
  {
    s = s.Trim('[', ']');
    if (string.IsNullOrWhiteSpace(s))
      return null;
    var values = s.Split(',');
    var root = new TreeNode(int.Parse(values[0]));
    var pos = 1;
    var q = new Queue<TreeNode>();
    q.Enqueue(root);
    while (pos < values.Length)
    {
      var node = q.Dequeue();
      if (pos < values.Length && values[pos] != "null")
      {
        var value = int.Parse(values[pos]);
        node.left = new TreeNode(value);
        q.Enqueue(node.left);
      }
      pos++;
      if (pos < values.Length && values[pos] != "null")
      {
        var value = int.Parse(values[pos]);
        node.right = new TreeNode(value);
        q.Enqueue(node.right);
      }
      pos++;
    }
    return root;
  }

  public static string ToString(TreeNode root)
  {
    if (root == null)
      return "";
    List<string> values = [];
    var q = new Queue<TreeNode>();
    q.Enqueue(root);
    while (q.Count > 0)
    {
      var node = q.Dequeue();
      if (node == null)
      {
        values.Add("null");
      }
      else
      {
        values.Add(node.val.ToString());
        q.Enqueue(node.left);
        q.Enqueue(node.right);
      }
    }
    while (values.Count > 0 && values[^1] == "null")
      values.RemoveAt(values.Count - 1);
    return string.Join(',', values);
  }

}

[TestFixture]
public class TreeNodeTests
{
  [Test]
  public void FromStringTest()
  {
    TreeNode.FromString("1,10,4,3,null,7,9,12,8,6,null,null,2").Should().BeEquivalentTo(
      new TreeNode(1,
        new TreeNode(10,
          new TreeNode(3,
            new TreeNode(12),
            new TreeNode(8))),
        new TreeNode(4,
          new TreeNode(7,
            new TreeNode(6)),
          new TreeNode(9,
            null,
            new TreeNode(2)))));
  }

  [Test]
  public void FromStringTest_Brackets()
  {
    TreeNode.FromString("[1,10,4,3,null,7,9,12,8,6,null,null,2]").Should().BeEquivalentTo(
      new TreeNode(1,
        new TreeNode(10,
          new TreeNode(3,
            new TreeNode(12),
            new TreeNode(8))),
        new TreeNode(4,
          new TreeNode(7,
            new TreeNode(6)),
          new TreeNode(9,
            null,
            new TreeNode(2)))));
  }

  [Test]
  public void FromStringTest_EmptyTree()
  {
    TreeNode.FromString("").Should().BeNull();
  }

  [Test]
  public void FromStringTest_EmptyTree_Brackets()
  {
    TreeNode.FromString("[]").Should().BeNull();
  }

  [Test]
  public void ToStringTest()
  {
    var root = new TreeNode(1,
      new TreeNode(10,
        new TreeNode(3,
          new TreeNode(12),
          new TreeNode(8))),
      new TreeNode(4,
        new TreeNode(7,
          new TreeNode(6)),
        new TreeNode(9,
          null,
          new TreeNode(2))));
    TreeNode.ToString(root).Should().Be("1,10,4,3,null,7,9,12,8,6,null,null,2");
  }

  [Test]
  public void ToStringTest_EmptyTree()
  {
    TreeNode.ToString(null).Should().Be("");
  }
}
