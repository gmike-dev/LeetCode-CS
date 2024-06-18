namespace LeetCode._826._Most_Profit_Assigning_Work;

public class CountingSolution
{
  public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker)
  {
    var maxProfits = new int[100001];
    for (var i = 0; i < difficulty.Length; i++)
      maxProfits[difficulty[i]] = Math.Max(maxProfits[difficulty[i]], profit[i]);
    for (var i = 0; i < maxProfits.Length - 1; i++)
      maxProfits[i + 1] = Math.Max(maxProfits[i], maxProfits[i + 1]);
    return worker.Sum(w => maxProfits[w]);
  }
}

[TestFixture]
public class CountingSolutionTests
{
  [TestCase(new[] { 2, 4, 6, 8, 10 }, new[] { 10, 20, 30, 40, 50 }, new[] { 4, 5, 6, 7 }, 100)]
  [TestCase(new[] { 85, 47, 57 }, new[] { 24, 66, 99 }, new[] { 40, 25, 25 }, 0)]
  public void Test(int[] difficulty, int[] profit, int[] worker, int expected)
  {
    new CountingSolution().MaxProfitAssignment(difficulty, profit, worker).Should().Be(expected);
  }
}
