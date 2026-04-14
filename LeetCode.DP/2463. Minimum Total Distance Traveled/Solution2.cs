namespace LeetCode.DP._2463._Minimum_Total_Distance_Traveled;

/// <summary>
/// https://leetcode.com/problems/minimum-total-distance-traveled/
/// </summary>
public class Solution2
{
  public long MinimumTotalDistance(IList<int> robot, int[][] factory)
  {
    Array.Sort(factory, (x, y) => x[0] - y[0]);
    List<int> factories = [];
    foreach (int[] f in factory)
    {
      for (int i = 0; i < f[1]; i++)
      {
        factories.Add(f[0]);
      }
    }
    int[] robots = robot.ToArray();
    Array.Sort(robots);
    int n = robots.Length;
    int m = factories.Count;
    long[][] dp = new long[n + 1][];
    for (int i = 0; i <= n; i++)
    {
      dp[i] = new long[m + 1];
      dp[i][0] = long.MaxValue / 2;
    }
    dp[0][0] = 0;
    for (int i = 1; i <= n; i++)
    {
      for (int j = 1; j <= m; j++)
      {
        dp[i][j] = Math.Min(
          dp[i][j - 1],
          dp[i - 1][j - 1] + Math.Abs(robots[i - 1] - factories[j - 1]));
      }
    }

    return dp[n][m];
  }
}

[TestFixture]
public class Solution2Tests
{
  [Test]
  public void Test1()
  {
    new Solution2().MinimumTotalDistance([0, 4, 6], [[2, 2], [6, 2]]).Should().Be(4);
  }

  [Test]
  public void Test2()
  {
    new Solution2().MinimumTotalDistance([1, -1], [[-2, 1], [2, 1]]).Should().Be(2);
  }

  [Test]
  public void Test3()
  {
    new Solution2().MinimumTotalDistance([9, 11, 99, 101], [[10, 1], [7, 1], [14, 1], [100, 1], [96, 1], [103, 1]])
      .Should().Be(6);
  }

  [Test]
  public void Test4()
  {
    new Solution2().MinimumTotalDistance(
      [
        -333539942, 359275673, 89966494, 949684497, -733065249, 241002388, 325009248, 403868412, -390719486, -670541382,
        563735045, 119743141, 323190444, 534058139, -684109467, 425503766, 761908175
      ], [[-590277115, 0], [-80676932, 3], [396659814, 0], [480747884, 9], [118956496, 10]])
      .Should().Be(4412966458);
  }
}
