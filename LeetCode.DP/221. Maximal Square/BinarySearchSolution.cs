namespace LeetCode.DP._221._Maximal_Square;

public class BinarySearchSolution
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
    var l = 1;
    var r = Math.Min(n, m);
    while (l <= r)
    {
      var size = l + (r - l) / 2;
      if (FindSquare(s, n, m, size))
        l = size + 1;
      else
        r = size - 1;
    }
    return r * r;
  }

  private static bool FindSquare(int[,] s, int n, int m, int size)
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
public class BinarySearchSolutionTests
{
  [Test]
  public void Test1()
  {
    new BinarySearchSolution().MaximalSquare([
      ['1', '0', '1', '0', '0'],
      ['1', '0', '1', '1', '1'],
      ['1', '1', '1', '1', '1'],
      ['1', '0', '0', '1', '0']
    ]).Should().Be(4);
  }

  [Test]
  public void Test2()
  {
    new BinarySearchSolution().MaximalSquare([
      ['0', '1'],
      ['1', '0']
    ]).Should().Be(1);
  }

  [Test]
  public void Test3()
  {
    new BinarySearchSolution().MaximalSquare([['0']]).Should().Be(0);
  }
}
