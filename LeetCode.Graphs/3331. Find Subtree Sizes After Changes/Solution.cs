namespace LeetCode.Graphs._3331._Find_Subtree_Sizes_After_Changes;

public class Solution
{
  public int[] FindSubtreeSizes(int[] parent, string s)
  {
    var n = s.Length;
    var child = new List<int>[n];
    BuildTree();
    var lastNode = new int[26];
    lastNode.AsSpan().Fill(-1);
    ChangeParents(0);
    BuildTree();
    var sizes = new int[n];
    FillSizes(0);
    return sizes;

    void ChangeParents(int node)
    {
      var prevLast = lastNode[s[node] - 'a'];
      if (prevLast != -1)
        parent[node] = prevLast;
      lastNode[s[node] - 'a'] = node;
      foreach (var c in child[node])
        ChangeParents(c);
      lastNode[s[node] - 'a'] = prevLast;
    }

    void FillSizes(int node)
    {
      sizes[node] = 1;
      foreach (var c in child[node])
      {
        FillSizes(c);
        sizes[node] += sizes[c];
      }
    }

    void BuildTree()
    {
      for (var i = 0; i < n; i++)
        child[i] = [];
      for (var i = 1; i < n; i++)
        child[parent[i]].Add(i);
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { -1, 0, 0, 1, 1, 1 }, "abaabc", new[] { 6, 3, 1, 1, 1, 1 })]
  [TestCase(new[] { -1, 0, 4, 0, 1 }, "abbba", new[] { 5, 2, 1, 1, 1 })]
  public void Test(int[] parent, string s, int[] expected)
  {
    new Solution().FindSubtreeSizes(parent, s).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
