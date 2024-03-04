using System;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._977._Squares_of_a_Sorted_Array;

public class CountingSortSolution
{
  public int[] SortedSquares(int[] a)
  {
    var n = a.Length;
    var m = 0;
    for (var i = 0; i < n; i++)
    {
      var val = Math.Abs(a[i]);
      m = Math.Max(val, m);
      a[i] = val;
    }
    CountingSort();
    for (var i = 0; i < n; i++)
      a[i] *= a[i];
    return a;

    void CountingSort()
    {
      var cnt = new int[m + 1];
      foreach (var num in a)
        cnt[num]++;
      var len = 0;
      for (var i = 0; len < a.Length; i++)
      {
        for (var j = cnt[i]; j > 0; j--)
          a[len++] = i;
      }
    }
  }
}

[TestFixture]
public class CountingSortSolutionTests
{
  [TestCase(new[] { -4, -1, 0, 3, 10 }, new[] { 0, 1, 9, 16, 100 })]
  [TestCase(new[] { -7, -3, 2, 3, 11 }, new[] { 4, 9, 9, 49, 121 })]
  public void Test(int[] nums, int[] expected)
  {
    new CountingSortSolution().SortedSquares(nums)
      .Should()
      .BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
