using LeetCode.Common;

namespace LeetCode.Graphs._1584._Min_Cost_to_Connect_All_Points;

public class SolutionUsingPrim
{
  public int MinCostConnectPoints(int[][] points)
  {
    var n = points.Length;
    var w = new int[n][];
    for (var i = 0; i < n; i++)
      w[i] = new int[n];

    for (var i = 0; i < n - 1; i++)
    for (var j = i + 1; j < n; j++)
      w[i][j] = w[j][i] = Math.Abs(points[i][0] - points[j][0]) + Math.Abs(points[i][1] - points[j][1]);

    return Prim(w, n);
  }

  private static int Prim(int[][] g, int n)
  {
    var result = 0;
    var used = new bool[n];
    var min = new int[n];
    Array.Fill(min, int.MaxValue);
    min[0] = 0;
    for (var i = 0; i < n; i++)
    {
      var v = -1;
      for (var j = 0; j < n; j++)
      {
        if (!used[j] && (v == -1 || min[j] < min[v]))
          v = j;
      }
      result += min[v];
      used[v] = true;
      for (var j = 0; j < n; j++)
      {
        if (g[v][j] < min[j])
          min[j] = g[v][j];
      }
    }
    return result;
  }
}

[TestFixture]
public class SolutionUsingPrimTests
{
  [TestCase("[[0,0],[2,2],[3,10],[5,2],[7,0]]", 20)]
  [TestCase("[[3,12],[-2,5],[-4,1]]", 18)]
  public void Test(string points, int expected)
  {
    new SolutionUsingPrim().MinCostConnectPoints(points.Array2()).Should().Be(expected);
  }
}
