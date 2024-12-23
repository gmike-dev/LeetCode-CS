using LeetCode.Common;

namespace LeetCode.BinaryTrees._2471._Minimum_Number_of_Operations_to_Sort_a_Binary_Tree_by_Level;

public class Solution
{
  public int MinimumOperations(TreeNode root)
  {
    var count = 0;
    List<TreeNode> q = [root];
    while (q.Count != 0)
    {
      var n = q.Count;
      var idx = new int[n];
      for (var i = 0; i < n; i++)
        idx[i] = i;
      idx.AsSpan().Sort((i, j) => q[i].val - q[j].val);
      for (var i = 0; i < n; i++)
      {
        while (idx[i] != i)
        {
          (q[i].val, q[idx[i]].val) = (q[idx[i]].val, q[i].val);
          (idx[i], idx[idx[i]]) = (idx[idx[i]], idx[i]);
          count++;
        }
      }
      for (var i = 0; i < n; i++)
      {
        if (q[i].left != null)
          q.Add(q[i].left);
        if (q[i].right != null)
          q.Add(q[i].right);
      }
      q.RemoveRange(0, n);
    }
    return count;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("[1,4,3,7,6,8,5,null,null,null,null,9,null,10]", 3)]
  [TestCase("[1,3,2,7,6,5,4]", 3)]
  [TestCase("[1,2,3,4,5,6]", 0)]
  [TestCase("[49,45,1,20,46,15,39,27,null,null,null,25]", 5)]
  [TestCase(
    "[332,463,103,417,150,409,41,135,129,117,474,263,null,328,456,347,167,383,null,null,422,493,489,275,72,null,null,425,89,null,null,162,18,null,null,null,null,363,290,106,260,468,null,null,null,432,null,323,null,null,null,null,null,null,36,null,null,302,190,null,280,null,null,null,null,488,null,null,null,null,446,null,null,null,null,null,75]",
    24)]
  public void Test(string root, int expected)
  {
    new Solution().MinimumOperations(TreeNode.FromString(root)).Should().Be(expected);
  }
}
