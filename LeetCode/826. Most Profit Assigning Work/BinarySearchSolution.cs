namespace LeetCode._826._Most_Profit_Assigning_Work;

public class BinarySearchSolution
{
  public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker)
  {
    var n = difficulty.Length;
    var sortedDifficulty = new int[n];
    var sortedProfit = new int[n];
    var p = new int[n];
    for (var i = 0; i < n; i++)
      p[i] = i;
    Array.Sort(p, (x, y) =>
    {
      var cmp = difficulty[x] - difficulty[y];
      return cmp == 0 ? profit[y] - profit[x] : cmp;
    });
    for (var i = 0; i < n; i++)
    {
      sortedDifficulty[i] = difficulty[p[i]];
      sortedProfit[i] = profit[p[i]];
    }
    for (var i = 0; i < n - 1; i++)
      sortedProfit[i + 1] = Math.Max(sortedProfit[i + 1], sortedProfit[i]);

    var maxProfit = 0;
    foreach (var w in worker)
    {
      var i = Array.BinarySearch(sortedDifficulty, w);
      if (i < 0)
        i = ~i - 1;
      if (i >= 0)
        maxProfit += sortedProfit[i];
    }
    return maxProfit;
  }
}

[TestFixture]
public class BinarySearchSolutionTests
{
  [TestCase(new[] { 2, 4, 6, 8, 10 }, new[] { 10, 20, 30, 40, 50 }, new[] { 4, 5, 6, 7 }, 100)]
  [TestCase(new[] { 85, 47, 57 }, new[] { 24, 66, 99 }, new[] { 40, 25, 25 }, 0)]
  [TestCase(new[] { 13, 37, 58 }, new[] { 4, 90, 96 }, new[] { 34, 73, 45 }, 190)]
  [TestCase(new[] { 68, 35, 52, 47, 86 }, new[] { 67, 17, 1, 81, 3 }, new[] { 92, 10, 85, 84, 82 }, 324)]
  [TestCase(new[] { 49, 49, 76, 88, 100 }, new[] { 5, 8, 75, 89, 94 }, new[] { 98, 72, 16, 27, 76 }, 172)]
  public void Test(int[] difficulty, int[] profit, int[] worker, int expected)
  {
    new BinarySearchSolution().MaxProfitAssignment(difficulty, profit, worker).Should().Be(expected);
  }
}
