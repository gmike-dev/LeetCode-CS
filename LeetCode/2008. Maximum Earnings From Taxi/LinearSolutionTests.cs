namespace LeetCode._2008._Maximum_Earnings_From_Taxi;

[TestFixture]
public class LinearSolutionTests
{
  [Test]
  public void Test1()
  {
    new LinearSolution().MaxTaxiEarnings(5, new[]
    {
      new[] { 2, 5, 4 },
      new[] { 1, 5, 1 }
    }).Should().Be(7);
  }

  [Test]
  public void Test2()
  {
    new LinearSolution().MaxTaxiEarnings(20, new[]
    {
      new[] { 1, 6, 1 },
      new[] { 3, 10, 2 },
      new[] { 10, 12, 3 },
      new[] { 11, 12, 2 },
      new[] { 12, 15, 2 },
      new[] { 13, 18, 1 }
    }).Should().Be(20);
  }

  [Test]
  public void Test3()
  {
    new LinearSolution().MaxTaxiEarnings(10,
      new[]
      {
        new[] { 9, 10, 2 },
        new[] { 4, 5, 6 },
        new[] { 6, 8, 1 },
        new[] { 1, 5, 5 },
        new[] { 4, 9, 5 },
        new[] { 1, 6, 5 },
        new[] { 4, 8, 3 },
        new[] { 4, 7, 10 },
        new[] { 1, 9, 8 },
        new[] { 2, 3, 5 }
      }).Should().Be(22);
  }
}
