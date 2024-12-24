namespace LeetCode.Graphs._3203._Find_Minimum_Diameter_After_Merging_Two_Trees;

public class Solution
{
  public int MinimumDiameterAfterMerge(int[][] edges1, int[][] edges2)
  {
    var n = edges1.Length + 1;
    var m = edges2.Length + 1;
    var g1 = new List<int>[n];
    for (var i = 0; i < n; i++)
      g1[i] = [];
    var g2 = new List<int>[m];
    for (var i = 0; i < m; i++)
      g2[i] = [];
    foreach (var e in edges1)
    {
      g1[e[0]].Add(e[1]);
      g1[e[1]].Add(e[0]);
    }
    foreach (var e in edges2)
    {
      g2[e[0]].Add(e[1]);
      g2[e[1]].Add(e[0]);
    }
    var d1 = Diameter(g1, [], 0).diameter;
    var d2 = Diameter(g2, [], 0).diameter;
    return Math.Max(Math.Max(d1, d2), (d1 + 1) / 2 + (d2 + 1) / 2 + 1);
  }

  private static (int diameter, int depth) Diameter(List<int>[] g, HashSet<int> used, int u)
  {
    used.Add(u);
    var maxDepth1 = 0;
    var maxDepth2 = 0;
    var diameter = 0;
    foreach (var v in g[u])
    {
      if (!used.Contains(v))
      {
        var (childDiameter, depth) = Diameter(g, used, v);
        diameter = Math.Max(diameter, childDiameter);
        depth++;
        if (depth > maxDepth1)
        {
          maxDepth2 = maxDepth1;
          maxDepth1 = depth;
        }
        else if (depth > maxDepth2)
        {
          maxDepth2 = depth;
        }
      }
    }
    diameter = Math.Max(diameter, maxDepth1 + maxDepth2);
    return (diameter, maxDepth1);
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().MinimumDiameterAfterMerge(
      [[0, 1], [0, 2], [0, 3]],
      [[0, 1]]).Should().Be(3);
  }

  [Test]
  public void Test2()
  {
    new Solution().MinimumDiameterAfterMerge(
      [[0, 1], [0, 2], [0, 3], [2, 4], [2, 5], [3, 6], [2, 7]],
      [[0, 1], [0, 2], [0, 3], [2, 4], [2, 5], [3, 6], [2, 7]]).Should().Be(5);
  }

  [Test]
  public void Test3()
  {
    new Solution().MinimumDiameterAfterMerge([], []).Should().Be(1);
  }

  [Test]
  public void Test4()
  {
    new Solution().MinimumDiameterAfterMerge([], [[0, 1]]).Should().Be(2);
  }

  [Test]
  public void Test5()
  {
    new Solution().MinimumDiameterAfterMerge([], [[0, 1], [1, 2]]).Should().Be(2);
  }
}
