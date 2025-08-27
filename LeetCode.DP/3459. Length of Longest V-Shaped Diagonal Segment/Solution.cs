using System.IO;
using LeetCode.Common;

namespace LeetCode.DP._3459._Length_of_Longest_V_Shaped_Diagonal_Segment;

public class Solution
{
  private static readonly int[] dr = [1, 1, -1, -1];
  private static readonly int[] dc = [1, -1, -1, 1];

  public int LenOfVDiagonal(int[][] grid)
  {
    var n = grid.Length;
    var m = grid[0].Length;
    var used = new bool[n, m];
    var res = 0;
    var cache = new int[n * m * 4 * 2 * 2];
    Array.Fill(cache, -1);
    for (var i = 0; i < n; i++)
    {
      for (var j = 0; j < m; j++)
      {
        if (grid[i][j] == 1)
        {
          used[i, j] = true;
          for (var d = 0; d < 4; d++)
          {
            res = Math.Max(res, F(i + dr[d], j + dc[d], d, 1, 1) + 1);
          }
          used[i, j] = false;
        }
      }
    }
    return res;

    bool OutOfBounds(int r, int c)
    {
      return r < 0 || c < 0 || r >= n || c >= m;
    }

    int GetCacheKey(int r, int c, int d, int two, int canTurn)
    {
      return (((r * m + c) * 4 + d) * 2 + two) * 2 + canTurn;
    }

    int F(int r, int c, int d, int two, int canTurn)
    {
      if (OutOfBounds(r, c) || used[r, c] || two != 0 && grid[r][c] != 2 || two == 0 && grid[r][c] != 0)
        return 0;

      var key = GetCacheKey(r, c, d, two, canTurn);
      var result = cache[key];
      if (result != -1)
        return result;

      used[r, c] = true;
      result = F(r + dr[d], c + dc[d], d, 1 - two, canTurn) + 1;
      if (canTurn != 0)
      {
        d = (d + 1) % 4; // CW turn
        result = Math.Max(result, F(r + dr[d], c + dc[d], d, 1 - two, 0) + 1);
      }
      used[r, c] = false;
      cache[key] = result;
      return result;
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("[[2,2,1,2,2],[2,0,2,2,0],[2,0,1,1,0],[1,0,2,2,2],[2,0,0,2,2]]", 5)]
  [TestCase("[[2,2,2,2,2],[2,0,2,2,0],[2,0,1,1,0],[1,0,2,2,2],[2,0,0,2,2]]", 4)]
  [TestCase("[[1,2,2,2,2],[2,2,2,2,0],[2,0,0,0,0],[0,0,2,2,2],[2,0,0,2,0]]", 5)]
  [TestCase(
    "[[1,1,0,1,1,1,0,2,1,2],[0,1,0,0,2,1,2,1,2,0],[2,0,2,0,2,1,0,2,0,1],[2,2,2,0,2,0,2,0,1,0],[1,0,1,0,1,0,1,0,1,1]]",
    6)]
  [TestCase("[[1]]", 1)]
  [TestCase("[" +
            "[2,0,2,0,2,0,2,0,2,0,1,1,2,2,2,1,2,0,0,0]," +
            "[2,0,2,0,2,0,2,0,2,0,2,0,2,1,2,0,2,2,2,0]," +
            "[2,0,2,0,2,0,1,0,2,0,2,0,2,0,2,0,2,0,2,0]," +
            "[0,0,0,0,2,0,2,0,2,0,2,0,2,0,2,0,2,0,2,0]," +
            "[2,0,2,0,2,0,2,2,2,0,1,0,2,0,2,0,2,0,2,0]," +
            "[2,0,2,0,2,0,2,0,1,0,2,0,2,0,2,0,2,0,2,0]," +
            "[1,1,2,0,2,0,2,0,2,0,2,0,2,0,2,0,2,2,2,0]]", 13)]
  public void Test(string grid, int expected)
  {
    new Solution().LenOfVDiagonal(grid.Array2()).Should().Be(expected);
  }

  public static IEnumerable<object> GetTestCases()
  {
    var source = Path.Join(TestContext.CurrentContext.WorkDirectory,
      "3459. Length of Longest V-Shaped Diagonal Segment", "TestCases.txt");
    using var sr = new StreamReader(source);
    while (!sr.EndOfStream)
    {
      yield return new object[] { sr.ReadLine(), int.Parse(sr.ReadLine()) };
    }
  }

  [TestCaseSource(nameof(GetTestCases))]
  public void TestLargeInput(string grid, int expected)
  {
    new Solution().LenOfVDiagonal(grid.Array2()).Should().Be(expected);
  }
}
