namespace LeetCode.Graphs._787._Cheapest_Flights_Within_K_Stops;

public class DpSolution
{
  public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
  {
    var costs = new int[n];
    Array.Fill(costs, int.MaxValue);
    costs[src] = 0;

    for (var i = 0; i <= k; i++)
    {
      var temp = costs.ToArray();
      foreach (var f in flights)
      {
        var (from, to, cost) = (f[0], f[1], f[2]);
        if (costs[from] != int.MaxValue)
          temp[to] = Math.Min(temp[to], costs[from] + cost);
      }
      costs = temp;
    }

    return costs[dst] == int.MaxValue ? -1 : costs[dst];
  }
}

[TestFixture]
public class DpSolutionTests
{
  [Test]
  public void Test1()
  {
    new DpSolution().FindCheapestPrice(4, new[]
      {
        new[] { 0, 1, 100 },
        new[] { 1, 2, 100 },
        new[] { 2, 0, 100 },
        new[] { 1, 3, 600 },
        new[] { 2, 3, 200 }
      },
      0, 3, 1).Should().Be(700);
  }

  [Test]
  public void Test2()
  {
    new DpSolution().FindCheapestPrice(4, new[]
      {
        new[] { 0, 1, 100 },
        new[] { 1, 2, 100 },
        new[] { 0, 2, 500 }
      },
      0, 2, 1).Should().Be(200);
  }

  [Test]
  public void Test3()
  {
    new DpSolution().FindCheapestPrice(4, new[]
      {
        new[] { 0, 1, 100 },
        new[] { 1, 2, 100 },
        new[] { 0, 2, 500 }
      },
      0, 2, 0).Should().Be(500);
  }

  [Test]
  public void Test39()
  {
    new DpSolution().FindCheapestPrice(4, new[]
      {
        new[] { 0, 1, 1 }, new[] { 0, 2, 5 }, new[] { 1, 2, 1 }, new[] { 2, 3, 1 }
      },
      0, 3, 1).Should().Be(6);
  }

  [Test]
  public void Test10()
  {
    new DpSolution().FindCheapestPrice(10, new[]
      {
        new[] { 3, 4, 4 }, new[] { 2, 5, 6 }, new[] { 4, 7, 10 }, new[] { 9, 6, 5 }, new[] { 7, 4, 4 },
        new[] { 6, 2, 10 }, new[] { 6, 8, 6 }, new[] { 7, 9, 4 }, new[] { 1, 5, 4 }, new[] { 1, 0, 4 },
        new[] { 9, 7, 3 }, new[] { 7, 0, 5 }, new[] { 6, 5, 8 }, new[] { 1, 7, 6 }, new[] { 4, 0, 9 },
        new[] { 5, 9, 1 }, new[] { 8, 7, 3 }, new[] { 1, 2, 6 }, new[] { 4, 1, 5 }, new[] { 5, 2, 4 },
        new[] { 1, 9, 1 }, new[] { 7, 8, 10 }, new[] { 0, 4, 2 }, new[] { 7, 2, 8 }
      },
      6, 0, 7).Should().Be(14);
  }
}
