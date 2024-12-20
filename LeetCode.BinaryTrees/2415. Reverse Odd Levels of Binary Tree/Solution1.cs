using LeetCode.Common;

namespace LeetCode.BinaryTrees._2415._Reverse_Odd_Levels_of_Binary_Tree;

public class Solution1
{
  public TreeNode ReverseOddLevels(TreeNode root)
  {
    var t = new List<List<TreeNode>>();
    Build(root, 0, t);
    for (var i = 1; i < t.Count; i += 2)
      t[i].Reverse();
    CreateResult(t[0][0], 1);
    return t[0][0];

    void CreateResult(TreeNode node, int level)
    {
      if (level >= t.Count)
        return;
      node.right = t[level].Last();
      t[level].RemoveAt(t[level].Count - 1);
      CreateResult(node.right, level + 1);
      node.left = t[level].Last();
      t[level].RemoveAt(t[level].Count - 1);
      CreateResult(node.left, level + 1);
    }
  }

  private void Build(TreeNode root, int level, List<List<TreeNode>> t)
  {
    var node = new TreeNode(root.val);
    if (level >= t.Count)
      t.Add([node]);
    else
      t[level].Add(node);
    if (root.left != null)
      Build(root.left, level + 1, t);
    if (root.right != null)
      Build(root.right, level + 1, t);
  }
}

[TestFixture]
public class Solution1Tests
{
  [TestCase("[2,3,5,8,13,21,34]", "[2,5,3,8,13,21,34]")]
  [TestCase("[7,13,11]", "[7,11,13]")]
  [TestCase("[0,1,2,0,0,0,0,1,1,1,1,2,2,2,2]", "[0,2,1,0,0,0,0,2,2,2,2,1,1,1,1]")]
  public void Test(string root, string expected)
  {
    var actual = new Solution1().ReverseOddLevels(TreeNode.FromString(root));
    TreeNode.ToString(actual).Should().Be(expected);
  }
}
