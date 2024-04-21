namespace LeetCode.__DP._3122._Minimum_Number_of_Operations_to_Satisfy_Conditions;

public class DpSolution
{
  public int MinimumOperations(int[][] grid)
  {
    var n = grid.Length;
    var m = grid[0].Length;
    var count = new int[m, 10];
    for (var i = 0; i < n; i++)
    for (var j = 0; j < m; j++)
      count[j, grid[i][j]]++;

    var dp = new int[m][];
    for (var i = 0; i < m; i++)
      dp[i] = new int[10];

    for (var d = 0; d < 10; d++)
      dp[0][d] = n - count[0, d];

    for (var col = 1; col < m; col++)
    {
      for (var d = 0; d < 10; d++)
      {
        var prev = int.MaxValue;
        for (var i = 0; i < 10; i++)
        {
          if (i != d)
            prev = Math.Min(prev, dp[col - 1][i]);
        }
        dp[col][d] = prev + n - count[col, d];
      }
    }

    return dp[m - 1].Min();
  }
}

[TestFixture]
public class DpSolutionTests
{
  [Test]
  public void Test1()
  {
    new DpSolution().MinimumOperations(
    [
      [1, 0, 2],
      [1, 0, 2]
    ]).Should().Be(0);
  }

  [Test]
  public void Test2()
  {
    new DpSolution().MinimumOperations(
    [
      [1, 1, 1],
      [0, 0, 0]
    ]).Should().Be(3);
  }

  [Test]
  public void Test3()
  {
    new DpSolution().MinimumOperations(
    [
      [1],
      [2],
      [3]
    ]).Should().Be(2);
  }

  [Test]
  public void Test4()
  {
    new DpSolution().MinimumOperations(
    [
      [1, 1],
      [1, 1],
      [1, 0],
      [0, 0],
      [1, 1],
    ]).Should().Be(4);
  }

  [Test]
  public void Test5()
  {
    new DpSolution().MinimumOperations(
    [
      [8, 8],
      [8, 7]
    ]).Should().Be(1);
  }
}
