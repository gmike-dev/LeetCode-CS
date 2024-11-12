namespace LeetCode._52._N_Queens_II;

public class Solution
{
  public int TotalNQueens(int n)
  {
    var colUsed = new bool[n];
    var diag1Used = new bool[2 * n - 1];
    var diag2Used = new bool[2 * n - 1];
    var result = 0;
    FillPuzzles(0);
    return result;

    void FillPuzzles(int i)
    {
      if (i == n)
      {
        result++;
        return;
      }
      for (var j = 0; j < n; j++)
      {
        var d1 = n - 1 + j - i;
        var d2 = i + j;
        if (colUsed[j] || diag1Used[d1] || diag2Used[d2])
          continue;
        colUsed[j] = diag1Used[d1] = diag2Used[d2] = true;
        FillPuzzles(i + 1);
        colUsed[j] = diag1Used[d1] = diag2Used[d2] = false;
      }
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(4, 2)]
  [TestCase(1, 1)]
  public void Test(int n, int expected)
  {
    new Solution().TotalNQueens(n).Should().Be(expected);
  }
}
