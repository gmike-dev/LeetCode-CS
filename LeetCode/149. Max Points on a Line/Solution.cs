using LeetCode.Common;

namespace LeetCode._149._Max_Points_on_a_Line;

/// <summary>
/// https://leetcode.com/problems/max-points-on-a-line/
/// </summary>
public class Solution
{
  public int MaxPoints(int[][] points)
  {
    int n = points.Length;
    int maxPoints = 1;
    for (int i = 0; i < n; i++)
    {
      int x1 = points[i][0];
      int y1 = points[i][1];
      Dictionary<double, int> counter = new();
      for (int j = i + 1; j < n; j++)
      {
        int x2 = points[j][0];
        int y2 = points[j][1];
        double k = x1 == x2 ? double.PositiveInfinity : (double)(y2 - y1) / (x2 - x1);
        counter[k] = counter.GetValueOrDefault(k) + 1;
      }
      maxPoints = Math.Max(maxPoints, counter.Values.Prepend(0).Max() + 1);
    }
    return maxPoints;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("[[1,1],[2,2],[3,3]]", 3)]
  [TestCase("[[1,1],[3,2],[5,3],[4,1],[2,3],[1,4]]", 4)]
  [TestCase("[[0,0]]", 1)]
  public void Test(string points, int expected)
  {
    new Solution().MaxPoints(points.Array2()).Should().Be(expected);
  }
}
