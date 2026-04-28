using LeetCode.Common;

namespace LeetCode._2033._Minimum_Operations_to_Make_a_Uni_Value_Grid;

public class CountingSolution
{
  public int MinOperations(int[][] grid, int x)
  {
    int m = grid.Length;
    int n = grid[0].Length;
    Span<int> count = stackalloc int[10001];
    for (int i = 0; i < m; i++)
    {
      for (int j = 0; j < n; j++)
      {
        count[grid[i][j]]++;
      }
    }
    int halfCount = (m * n + 1) / 2;
    int median = 0;
    int currentCount = 0;
    for (int i = 0; i < count.Length; i++)
    {
      currentCount += count[i];
      if (currentCount >= halfCount)
      {
        median = i;
        break;
      }
    }
    int ans = 0;
    for (int i = 0; i < count.Length; i++)
    {
      if (count[i] == 0)
      {
        continue;
      }
      int d = Math.Abs(i - median);
      if (d % x != 0)
      {
        return -1;
      }
      ans += count[i] * (d / x);
    }
    return ans;
  }
}

[TestFixture]
public class CountingSolutionTests
{
  [TestCase("[[2,4],[6,8]]", 2, 4)]
  [TestCase("[[1,5],[2,3]]", 1, 5)]
  [TestCase("[[1,2],[3,4]]", 2, -1)]
  [TestCase("[[146]]", 86, 0)]
  public void Test(string grid, int x, int expected)
  {
    new CountingSolution().MinOperations(grid.Array2(), x).Should().Be(expected);
  }
}
