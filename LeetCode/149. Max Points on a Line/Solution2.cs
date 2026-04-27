using LeetCode.Common;

namespace LeetCode._149._Max_Points_on_a_Line;

/// <summary>
/// https://leetcode.com/problems/max-points-on-a-line/
/// </summary>
public class Solution2
{
  public int MaxPoints(int[][] points)
  {
    int n = points.Length;
    int maxPoints = 1;
    for (int i = 0; i < n; i++)
    {
      int x1 = points[i][0];
      int y1 = points[i][1];
      for (int j = i + 1; j < n; j++)
      {
        int x2 = points[j][0];
        int y2 = points[j][1];
        int dx = x2 - x1;
        int dy = y2 - y1;
        int cross = x1 * y2 - x2 * y1;
        int count = 2;
        for (int k = j + 1; k < n; k++)
        {
          int x3 = points[k][0];
          int y3 = points[k][1];
          if (y3 * dx - x3 * dy + cross == 0) // cross(pi, pj, pk) == 0
          {
            count++;
          }
        }
        maxPoints = Math.Max(maxPoints, count);
      }
    }

    return maxPoints;
  }
}

[TestFixture]
public class Solution2Tests
{
  [TestCase("[[1,1],[2,2],[3,3]]", 3)]
  [TestCase("[[1,1],[3,2],[5,3],[4,1],[2,3],[1,4]]", 4)]
  [TestCase("[[0,0]]", 1)]
  public void Test(string points, int expected)
  {
    new Solution2().MaxPoints(points.Array2()).Should().Be(expected);
  }
}
