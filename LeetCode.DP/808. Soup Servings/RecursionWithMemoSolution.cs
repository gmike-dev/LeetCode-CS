namespace LeetCode.DP._808._Soup_Servings;

public class RecursionWithMemoSolution
{
  private readonly Dictionary<(int, int), double> cache = new();

  public double SoupServings(int n)
  {
    if (n > 4800)
      return 1.0;

    n = (n + 24) / 25;
    return Probability(n, n);
  }

  private double Probability(int firstServes, int secondServes)
  {
    if (firstServes <= 0 && secondServes <= 0)
      return 0.5;
    if (firstServes <= 0)
      return 1.0;
    if (secondServes <= 0)
      return 0.0;
    var cacheKey = (firstServes, secondServes);
    if (cache.TryGetValue(cacheKey, out var dp))
      return dp;
    cache[cacheKey] = (Probability(firstServes - 4, secondServes) +
                        Probability(firstServes - 3, secondServes - 1) +
                        Probability(firstServes - 2, secondServes - 2) +
                        Probability(firstServes - 1, secondServes - 3)) * 0.25;
    return cache[cacheKey];
  }
}

[TestFixture]
public class RecursionWithMemoSolutionTests
{
  [TestCase(50, 0.625)]
  [TestCase(100, 0.71875)]
  public void Test(int n, double expected)
  {
    new RecursionWithMemoSolution().SoupServings(n).Should().Be(expected);
  }
}
