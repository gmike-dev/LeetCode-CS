namespace LeetCode._51._N_Queens;

public class Solution
{
  public IList<IList<string>> SolveNQueens(int n)
  {
    var puzzle = new char[n][];
    for (var i = 0; i < n; i++)
    {
      puzzle[i] = new char[n];
      puzzle[i].AsSpan().Fill('.');
    }
    var colUsed = new bool[n];
    var diag1Used = new bool[2 * n - 1];
    var diag2Used = new bool[2 * n - 1];
    var result = new List<IList<string>>();
    FillPuzzles(0);
    return result;

    void FillPuzzles(int i)
    {
      if (i == n)
      {
        result.Add(puzzle.Select(r => string.Join("", r)).ToArray());
        return;
      }
      for (var j = 0; j < n; j++)
      {
        var d1 = n - 1 + j - i;
        var d2 = i + j;
        if (colUsed[j] || diag1Used[d1] || diag2Used[d2])
          continue;
        puzzle[i][j] = 'Q';
        colUsed[j] = diag1Used[d1] = diag2Used[d2] = true;
        FillPuzzles(i + 1);
        colUsed[j] = diag1Used[d1] = diag2Used[d2] = false;
        puzzle[i][j] = '.';
      }
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().SolveNQueens(4).Should().BeEquivalentTo([
      new[] { ".Q..", "...Q", "Q...", "..Q." },
      new[] { "..Q.", "Q...", "...Q", ".Q.." }
    ]);
  }

  [Test]
  public void Test2()
  {
    new Solution().SolveNQueens(1).Should().BeEquivalentTo([
      new[] { "Q" }
    ]);
  }
}
