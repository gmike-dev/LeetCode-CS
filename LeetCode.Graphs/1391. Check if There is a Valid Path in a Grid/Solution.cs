using LeetCode.Common;

namespace LeetCode.Graphs._1391._Check_if_There_is_a_Valid_Path_in_a_Grid;

/// <summary>
/// https://leetcode.com/problems/check-if-there-is-a-valid-path-in-a-grid/
/// </summary>
public class Solution
{
  public bool HasValidPath(int[][] grid)
  {
    int n = grid.Length;
    int m = grid[0].Length;
    int[][] canMove =
    [
      [1, 1, 0, 1, 0],
      [1, 0, 1, 0, 1],
      [1, 1, 0, 0, 1],
      [1, 0, 0, 1, 1],
      [1, 1, 1, 0, 0],
      [1, 0, 1, 1, 0]
    ];
    int[][] nextDir =
    [
      [1, 3],
      [2, 4],
      [3, 2],
      [1, 2],
      [3, 4],
      [1, 4]
    ];
    int[] di = [0, 0, 1, 0, -1];
    int[] dj = [0, 1, 0, -1, 0];
    return Dfs(0, 0, 0);

    bool Dfs(int i, int j, int d)
    {
      if (i < 0 || i >= n || j < 0 || j >= m)
      {
        return false;
      }
      int street = grid[i][j];
      if (street == 0)
      {
        return false;
      }
      if (canMove[street - 1][d] == 0)
      {
        return false;
      }
      if (i == n - 1 && j == m - 1)
      {
        return true;
      }
      grid[i][j] = 0;
      foreach (int dir in nextDir[street - 1])
      {
        if (Dfs(i + di[dir], j + dj[dir], dir))
        {
          return true;
        }
      }
      return false;
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("[[2,4,3],[6,5,2]]", true)]
  [TestCase("[[1,2,1],[1,2,1]]", false)]
  [TestCase("[[1,1,2]]", false)]
  [TestCase("[[4,1],[6,1]]", true)]
  public void Test(string grid, bool expected)
  {
    new Solution().HasValidPath(grid.Array2()).Should().Be(expected);
  }
}
