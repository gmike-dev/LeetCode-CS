using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.__Graphs._787._Cheapest_Flights_Within_K_Stops;

public class BfsSolution
{
  public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
  {
    var g = new List<(int to, int cost)>[n];
    for (var i = 0; i < n; i++)
      g[i] = new List<(int to, int cost)>();
    foreach (var flight in flights)
    {
      var (from, to, cost) = (flight[0], flight[1], flight[2]);
      g[from].Add((to, cost));
    }
    var costs = new int[n];
    Array.Fill(costs, int.MaxValue);
    costs[src] = 0;

    var q = new Queue<(int v, int cost)>();
    q.Enqueue((src, 0));

    for (var i = 0; i <= k && q.Count != 0; i++)
    {
      for (var j = q.Count; j != 0; j--)
      {
        var (v, cost) = q.Dequeue();
        foreach (var (to, c) in g[v])
        {
          if (cost + c < costs[to])
          {
            costs[to] = cost + c;
            q.Enqueue((to, cost + c));
          }
        }
      }
    }

    return costs[dst] == int.MaxValue ? -1 : costs[dst];
  }
}

[TestFixture]
public class BfsSolutionTests
{
  [Test]
  public void Test1()
  {
    new BfsSolution().FindCheapestPrice(4, new[]
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
    new BfsSolution().FindCheapestPrice(4, new[]
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
    new BfsSolution().FindCheapestPrice(4, new[]
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
    new BfsSolution().FindCheapestPrice(4, new[]
      {
        new[] { 0, 1, 1 }, new[] { 0, 2, 5 }, new[] { 1, 2, 1 }, new[] { 2, 3, 1 }
      },
      0, 3, 1).Should().Be(6);
  }

  [Test]
  public void Test10()
  {
    new BfsSolution().FindCheapestPrice(10, new[]
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
