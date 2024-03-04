using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._977._Squares_of_a_Sorted_Array;

public class SortSolution
{
  public int[] SortedSquares(int[] nums) =>
    nums.Select(n => n * n).OrderBy(n => n).ToArray();
}

[TestFixture]
public class SortSolutionTests
{
  [TestCase(new[] { -4, -1, 0, 3, 10 }, new[] { 0, 1, 9, 16, 100 })]
  [TestCase(new[] { -7, -3, 2, 3, 11 }, new[] { 4, 9, 9, 49, 121 })]
  public void Test(int[] nums, int[] expected)
  {
    new SortSolution().SortedSquares(nums)
      .Should()
      .BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
