using LeetCode.Common;

namespace LeetCode._2033._Minimum_Operations_to_Make_a_Uni_Value_Grid;

/// <summary>
/// https://leetcode.com/problems/minimum-operations-to-make-a-uni-value-grid/
/// </summary>
public class Solution
{
  public int MinOperations(int[][] grid, int x)
  {
    int m = grid.Length;
    int n = grid[0].Length;
    List<int> list = new(m * n);
    for (int i = 0; i < m; i++)
    {
      for (int j = 0; j < n; j++)
      {
        list.Add(grid[i][j]);
      }
    }
    list.Sort();
    int median = list[list.Count / 2];
    int ans = 0;
    foreach (int item in list)
    {
      int d = Math.Abs(item - median);
      if (d % x != 0)
      {
        return -1;
      }
      ans += d / x;
    }
    return ans;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("[[2,4],[6,8]]", 2, 4)]
  [TestCase("[[1,5],[2,3]]", 1, 5)]
  [TestCase("[[1,2],[3,4]]", 2, -1)]
  [TestCase("[[146]]", 86, 0)]
  public void Test(string grid, int x, int expected)
  {
    new Solution().MinOperations(grid.Array2(), x).Should().Be(expected);
  }
}
