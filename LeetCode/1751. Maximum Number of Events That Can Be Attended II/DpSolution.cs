using System;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._1751._Maximum_Number_of_Events_That_Can_Be_Attended_II;

public class DpSolution
{
  public int MaxValue(int[][] events, int k)
  {
    Array.Sort(events, (x, y) => x[1] - y[1]);

    var n = events.Length;

    var prevEvent = new int[n];
    for (var i = 0; i < n; i++)
      prevEvent[i] = UpperBound(events, i, events[i][0] - 1) - 1;

    var dp = new int[n];
    var prev = new int[n];
    
    prev[0] = events[0][2];
    for (var i = 1; i < n; i++)
      prev[i] = Math.Max(prev[i - 1], events[i][2]);

    var result = prev[n - 1];

    for (var i = 2; i <= k; i++)
    {
      for (var j = i - 1; j < n; j++)
      {
        dp[j] = Math.Max(dp[j - 1], (prevEvent[j] < 0 ? 0 : prev[prevEvent[j]]) + events[j][2]);
      }
      result = Math.Max(result, dp[n - 1]);
      (dp, prev) = (prev, dp);
      Array.Clear(dp);
    }

    return result;
  }

  private static int UpperBound(int[][] events, int n, int start)
  {
    var l = 0;
    var r = n - 1;
    while (l < r)
    {
      var m = l + (r - l) / 2;
      if (events[m][1] <= start)
        l = m + 1;
      else
        r = m;
    }
    return events[l][1] <= start ? n : l;
  }
}

[TestFixture]
public class DpSolutionTests
{
  [Test]
  public void Test1()
  {
    new DpSolution().MaxValue(new[]
    {
      new[] { 1, 2, 4 }, new[] { 3, 4, 3 }, new[] { 2, 3, 1 }
    }, 2).Should().Be(7);
  }

  [Test]
  public void Test2()
  {
    new DpSolution().MaxValue(new[]
    {
      new[] { 1, 2, 4 }, new[] { 3, 4, 3 }, new[] { 2, 3, 10 }
    }, 2).Should().Be(10);
  }

  [Test]
  public void Test3()
  {
    new DpSolution().MaxValue(new[]
    {
      new[] { 1, 1, 1 }, new[] { 2, 2, 2 }, new[] { 3, 3, 3 }, new[] { 4, 4, 4 }
    }, 3).Should().Be(9);
  }
}