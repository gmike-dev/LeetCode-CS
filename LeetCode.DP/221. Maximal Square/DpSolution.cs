namespace LeetCode.DP._221._Maximal_Square;

/// <summary>
/// https://leetcode.com/problems/maximal-square/
/// </summary>
public class DpSolution
{
  public int MaximalSquare(char[][] matrix)
  {
    int n = matrix.Length;
    int m = matrix[0].Length;
    int[,] dp = new int[n + 1, m + 1];
    int size = 0;
    for (int i = 0; i < n; i++)
    {
      for (int j = 0; j < m; j++)
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
