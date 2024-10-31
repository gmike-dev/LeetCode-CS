namespace LeetCode.DP._2463._Minimum_Total_Distance_Traveled;

public class Solution
{
  public long MinimumTotalDistance(IList<int> robot, int[][] factory)
  {
    Array.Sort(factory, (x, y) => x[0] - y[0]);
    var factories = factory.SelectMany(f => Enumerable.Repeat(f[0], f[1])).ToArray();
    var robots = robot.ToArray();
    Array.Sort(robots);
    var n = robots.Length;
    var m = factories.Length;
    var dp = new long[n][];
    for (var i = 0; i < n; i++)
    {
      dp[i] = new long[m];
      dp[i].AsSpan().Fill(-1L);
    }
    return MinDistance(0, 0);

    long MinDistance(int i, int j)
    {
      if (i == n)
        return 0L;
      if (j == m)
        return -2;
      if (dp[i][j] != -1L)
        return dp[i][j];
      var skipResult = MinDistance(i, j + 1);
      var result = MinDistance(i + 1, j + 1);
      if (result != -2)
      {
        result += Math.Abs(robots[i] - factories[j]);
        if (skipResult != -2)
          result = Math.Min(result, skipResult);
      }
      else
      {
        result = skipResult;
      }
      return dp[i][j] = result;
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().MinimumTotalDistance([0, 4, 6], [[2, 2], [6, 2]]).Should().Be(4);
  }

  [Test]
  public void Test2()
  {
    new Solution().MinimumTotalDistance([1, -1], [[-2, 1], [2, 1]]).Should().Be(2);
  }

  [Test]
  public void Test3()
  {
    new Solution().MinimumTotalDistance([9, 11, 99, 101], [[10, 1], [7, 1], [14, 1], [100, 1], [96, 1], [103, 1]])
      .Should().Be(6);
  }

  [Test]
  public void Test4()
  {
    new Solution().MinimumTotalDistance(
      [
        -333539942, 359275673, 89966494, 949684497, -733065249, 241002388, 325009248, 403868412, -390719486, -670541382,
        563735045, 119743141, 323190444, 534058139, -684109467, 425503766, 761908175
      ], [[-590277115, 0], [-80676932, 3], [396659814, 0], [480747884, 9], [118956496, 10]])
      .Should().Be(4412966458);
  }
}
