namespace LeetCode.__DP._221._Maximal_Square;

public class DpSolution
{
  public int MaximalSquare(char[][] matrix)
  {
    var n = matrix.Length;
    var m = matrix[0].Length;
    var dp = new int[n + 1, m + 1];
    var size = 0;
    for (var i = 0; i < n; i++)
    {
      for (var j = 0; j < m; j++)
      {
        if (matrix[i][j] == '1')
        {
          dp[i + 1, j + 1] = Math.Min(dp[i + 1, j], Math.Min(dp[i, j + 1], dp[i, j])) + 1;
          size = Math.Max(size, dp[i + 1, j + 1]);
        }
      }
    }
    return size * size;
  }
}

[TestFixture]
public class DpSolutionTests
{
  [Test]
  public void Test1()
  {
    new DpSolution().MaximalSquare([
      ['1', '0', '1', '0', '0'],
      ['1', '0', '1', '1', '1'],
      ['1', '1', '1', '1', '1'],
      ['1', '0', '0', '1', '0']
    ]).Should().Be(4);
  }

  [Test]
  public void Test2()
  {
    new DpSolution().MaximalSquare([
      ['0', '1'],
      ['1', '0']
    ]).Should().Be(1);
  }

  [Test]
  public void Test3()
  {
    new DpSolution().MaximalSquare([['0']]).Should().Be(0);
  }
}
