using LeetCode.Common;

namespace LeetCode.Graphs._743._Network_Delay_Time;

public class Solution
{
  public int NetworkDelayTime(int[][] times, int n, int k)
  {
    const int inf = int.MaxValue / 2;
    int[][] g = new int[n][];
    for (int i = 0; i < n; i++)
    {
      g[i] = new int[n];
      g[i].AsSpan().Fill(inf);
      g[i][i] = 0;
    }
    foreach (int[] time in times)
    {
      int u = time[0] - 1;
      int v = time[1] - 1;
      int t = time[2];
      g[u][v] = t;
    }
    FloydWarshall();
    int minTime = g[k - 1].Max();
    return minTime == inf ? -1 : minTime;

    void FloydWarshall()
    {
      for (var v = 0; v < n; v++)
      {
        for (var i = 0; i < n; i++)
        {
          for (var j = 0; j < n; j++)
          {
            g[i][j] = Math.Min(g[i][j], g[i][v] + g[v][j]);
          }
        }
      }
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("[[2,1,1],[2,3,1],[3,4,1]]", 4, 2, 2)]
  [TestCase("[[1,2,1]]", 2, 1, 1)]
  [TestCase("[[1,2,1]]", 2, 2, -1)]
  public void Test(string times, int n, int k, int expected)
  {
    new Solution().NetworkDelayTime(times.Array2(), n, k).Should().Be(expected);
  }
}
