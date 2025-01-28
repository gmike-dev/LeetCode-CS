namespace LeetCode.Graphs._2658._Maximum_Number_of_Fish_in_a_Grid;

public class DfsSolution
{
  public int FindMaxFish(int[][] grid)
  {
    var n = grid.Length;
    var m = grid[0].Length;
    var maxSum = 0;
    for (var i = 0; i < n; i++)
    {
      for (var j = 0; j < m; j++)
      {
        if (grid[i][j] != 0)
          maxSum = Math.Max(maxSum, Sum(i, j));
      }
    }
    return maxSum;

    int Sum(int i, int j)
    {
      if (i < 0 || i >= n || j < 0 || j >= m || grid[i][j] == 0)
        return 0;
      var s = grid[i][j];
      grid[i][j] = 0;
      return s + Sum(i + 1, j) + Sum(i - 1, j) + Sum(i, j - 1) + Sum(i, j + 1);
    }
  }
}

[TestFixture]
public class DfsSolutionTests
{
  [Test]
  public void Test1()
  {
    new DfsSolution().FindMaxFish([[0, 2, 1, 0], [4, 0, 0, 3], [1, 0, 0, 4], [0, 3, 2, 0]]).Should().Be(7);
  }

  [Test]
  public void Test2()
  {
    new DfsSolution().FindMaxFish([[1, 0, 0, 0], [0, 0, 0, 0], [0, 0, 0, 0], [0, 0, 0, 1]]).Should().Be(1);
  }

  [Test]
  public void Test3()
  {
    new DfsSolution().FindMaxFish([[3, 8, 0]]).Should().Be(11);
  }
}
