using System;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._2402._Meeting_Rooms_III;

public class Solution
{
  public int MostBooked(int n, int[][] meetings)
  {
    var availableTime = new long[n];
    var usedCounter = new int[n];
    Array.Sort(meetings, (a, b) => a[0] - b[0]);
    foreach (var meeting in meetings)
    {
      var nextAvailableRoom = -1;
      for (var i = 0; i < n; i++)
      {
        if (availableTime[i] <= meeting[0])
        {
          nextAvailableRoom = i;
          break;
        }
        if (nextAvailableRoom == -1 || availableTime[i] < availableTime[nextAvailableRoom])
          nextAvailableRoom = i;
      }
      availableTime[nextAvailableRoom] = meeting[1] + Math.Max(0, availableTime[nextAvailableRoom] - meeting[0]);
      usedCounter[nextAvailableRoom]++;
    }
    var result = 0;
    for (var i = 1; i < n; i++)
    {
      if (usedCounter[i] > usedCounter[result])
        result = i;
    }
    return result;
  }
}

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().MostBooked(2, new[]
    {
      new[] { 0, 10 },
      new[] { 1, 5 },
      new[] { 2, 7 },
      new[] { 3, 4 }
    }).Should().Be(0);
  }

  [Test]
  public void Test2()
  {
    new Solution().MostBooked(3, new[]
    {
      new[] { 1, 20 },
      new[] { 2, 10 },
      new[] { 3, 5 },
      new[] { 4, 9 },
      new[] { 6, 8 }
    }).Should().Be(1);
  }

  [Test]
  public void Test67()
  {
    new Solution().MostBooked(4, new[]
    {
      new[] { 18, 19 },
      new[] { 3, 12 },
      new[] { 17, 19 },
      new[] { 2, 13 },
      new[] { 7, 10 }
    }).Should().Be(0);
  }
}
