namespace LeetCode._1584._Min_Cost_to_Connect_All_Points;

public class Solution
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
