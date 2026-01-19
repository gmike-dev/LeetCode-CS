using LeetCode.Common;

namespace LeetCode._1895._Largest_Magic_Square;

public class Solution
{
  public int LargestMagicSquare(int[][] grid)
  {
    var n = grid.Length;
    var m = grid[0].Length;
    var rowSum = new int[n + 1, m + 1];
    var colSum = new int[n + 1, m + 1];
    var diagSum1 = new int[n + 1, m + 1];
    var diagSum2 = new int[n + 1, m + 1];
    for (var i = 1; i <= n; i++)
    {
      for (var j = 1; j <= m; j++)
      {
        var val = grid[i - 1][j - 1];
        rowSum[i, j] = rowSum[i, j - 1] + val;
        colSum[i, j] = colSum[i - 1, j] + val;
        diagSum1[i, j] = diagSum1[i - 1, j - 1] + val;
        diagSum2[i, j - 1] = diagSum2[i - 1, j] + val;
      }
    }

    for (var k = Math.Min(n, m); k > 1; k--)
    {
      if (Find(k))
        return k;
    }
    return 1;

    bool Find(int a)
    {
      for (var i = a; i <= n; i++)
      {
        for (var j = a; j <= m; j++)
        {
          if (IsMagic(i, j, a))
            return true;
        }
      }
      return false;
    }

    bool IsMagic(int r, int c, int a)
    {
      var s0 = rowSum[r, c] - rowSum[r, c - a];
      for (var i = r - a + 1; i <= r; i++)
      {
        var s = rowSum[i, c] - rowSum[i, c - a];
        if (s != s0)
          return false;
      }

      for (var j = c - a + 1; j <= c; j++)
      {
        var s = colSum[r, j] - colSum[r - a, j];
        if (s != s0)
          return false;
      }

      if (diagSum1[r, c] - diagSum1[r - a, c - a] != s0)
        return false;

      if (diagSum2[r, c - a] - diagSum2[r - a, c] != s0)
        return false;

      return true;
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("[[7,1,4,5,6],[2,5,1,6,4],[1,5,4,3,2],[1,2,7,3,4]]", 3)]
  [TestCase("[[5,1,3,1],[9,3,3,1],[1,3,3,8]]", 2)]
  [TestCase("[[8,1,6],[3,5,7],[4,9,2],[7,10,9]]", 3)]
  public void Test(string grid, int expected)
  {
    new Solution().LargestMagicSquare(grid.Array2()).Should().Be(expected);
  }
}
