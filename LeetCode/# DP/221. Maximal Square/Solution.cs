namespace LeetCode.__DP._221._Maximal_Square;

public class Solution
{
  public int MaximalSquare(char[][] matrix)
  {
    var n = matrix.Length;
    var m = matrix[0].Length;
    var s = new int[n + 1, m + 1];
    for (var i = 0; i < n; i++)
    {
      for (var j = 0; j < m; j++)
        s[i + 1, j + 1] = s[i + 1, j] + s[i, j + 1] - s[i, j] + matrix[i][j] - '0';
    }
    var size = 0;
    while (size < Math.Min(n, m) && FindSquare(s, n, m, size + 1))
      size++;
    return size * size;
  }

  private bool FindSquare(int[,] s, int n, int m, int size)
  {
    for (var i = 0; i <= n - size; i++)
    {
      for (var j = 0; j <= m - size; j++)
      {
        var sum = s[i + size, j + size] - s[i, j + size] - s[i + size, j] + s[i, j];
        if (sum == size * size)
          return true;
      }
    }
    return false;
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().MaximalSquare([
      ['1', '0', '1', '0', '0'],
      ['1', '0', '1', '1', '1'],
      ['1', '1', '1', '1', '1'],
      ['1', '0', '0', '1', '0']
    ]).Should().Be(4);
  }

  [Test]
  public void Test2()
  {
    new Solution().MaximalSquare([
      ['0', '1'],
      ['1', '0']
    ]).Should().Be(1);
  }

  [Test]
  public void Test3()
  {
    new Solution().MaximalSquare([['0']]).Should().Be(0);
  }
}
