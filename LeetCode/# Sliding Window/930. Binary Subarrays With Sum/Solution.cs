using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.__Sliding_Window._930._Binary_Subarrays_With_Sum;

public class Solution
{
  public int NumSubarraysWithSum(int[] a, int goal)
  {
    var ones = new List<int>();
    var n = a.Length;
    ones.Add(-1);
    for (var i = 0; i < n; i++)
    {
      if (a[i] != 0)
        ones.Add(i);
    }
    ones.Add(n);

    var s = 0;
    if (goal == 0)
    {
      for (var i = 1; i < ones.Count; i++)
      {
        var m = ones[i] - ones[i - 1] - 1;
        s += m * (m + 1) / 2;
      }
    }
    else
    {
      for (var i = 1; i + goal < ones.Count; i++)
        s += (ones[i] - ones[i - 1]) * (ones[i + goal] - ones[i + goal - 1]);
    }
    return s;
  }
}

[TestFixture]
public class Tests
{
  [TestCase(new[] { 1, 0, 1, 0, 1 }, 2, 4)]
  [TestCase(new[] { 0, 0, 0, 0, 0 }, 0, 15)]
  [TestCase(new[] { 0 }, 1, 0)]
  [TestCase(new[] { 0 }, 0, 1)]
  [TestCase(new[] { 1 }, 0, 0)]
  [TestCase(new[] { 1 }, 1, 1)]
  [TestCase(new[] { 1, 1, 1 }, 1, 3)]
  [TestCase(new[] { 1, 1, 1 }, 2, 2)]
  [TestCase(new[] { 1, 1, 1 }, 3, 1)]
  public void Test(int[] a, int goal, int expected)
  {
    new Solution().NumSubarraysWithSum(a, goal).Should().Be(expected);
  }
}
