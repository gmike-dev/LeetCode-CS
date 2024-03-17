using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._57._Insert_Interval;

public class Solution
{
  public int[][] Insert(int[][] intervals, int[] newInterval)
  {
    var n = intervals.Length;
    var result = new List<int[]>();
    var i = 0;

    for (; i < n && intervals[i][1] < newInterval[0]; i++)
      result.Add(intervals[i]);

    for (; i < n && newInterval[1] >= intervals[i][0]; i++)
    {
      newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
      newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
    }
    result.Add(newInterval);

    for (; i < n; i++)
      result.Add(intervals[i]);

    return result.ToArray();
  }
}

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution()
      .Insert(new[] { new[] { 1, 3 }, new[] { 6, 9 } }, new[] { 2, 5 })
      .Should()
      .BeEquivalentTo(new[] { new[] { 1, 5 }, new[] { 6, 9 } }, o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new Solution()
      .Insert(new[] { new[] { 1, 2 }, new[] { 3, 5 }, new[] { 6, 7 }, new[] { 8, 10 }, new[] { 12, 16 } },
        new[] { 4, 8 })
      .Should()
      .BeEquivalentTo(new[] { new[] { 1, 2 }, new[] { 3, 10 }, new[] { 12, 16 } }, o => o.WithStrictOrdering());
  }

  [Test]
  public void Test3()
  {
    new Solution()
      .Insert(new int[][] { }, new[] { 4, 8 })
      .Should()
      .BeEquivalentTo(new[] { new[] { 4, 8 } }, o => o.WithStrictOrdering());
  }

  [Test]
  public void Test4()
  {
    new Solution()
      .Insert(new[] { new[] { 1, 2 } }, new[] { 4, 8 })
      .Should()
      .BeEquivalentTo(new[] { new[] { 1, 2 }, new[] { 4, 8 } }, o => o.WithStrictOrdering());
  }
}
