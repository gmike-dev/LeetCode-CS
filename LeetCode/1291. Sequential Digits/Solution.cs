using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._1291._Sequential_Digits;

public class Solution
{
  public IList<int> SequentialDigits(int low, int high) =>
    EnumerateDigits()
      .SkipWhile(x => x < low)
      .TakeWhile(x => x <= high)
      .ToArray();

  private static IEnumerable<int> EnumerateDigits()
  {
    var div = 1;
    for (var len = 2; len <= 9; len++)
    {
      div *= 10;
      var n = 1;
      for (var i = 2; i <= len; i++)
        n = n * 10 + i;
      yield return n;
      for (var i = len + 1; i <= 9; i++)
      {
        n = n % div * 10 + i;
        yield return n;
      }
    }
  }
}

[TestFixture]
public class Tests
{
  [TestCase(100, 300, new[] { 123, 234 })]
  [TestCase(1000, 13000, new[] { 1234, 2345, 3456, 4567, 5678, 6789, 12345 })]
  public void Test(int low, int high, int[] expected)
  {
    new Solution().SequentialDigits(low, high).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}