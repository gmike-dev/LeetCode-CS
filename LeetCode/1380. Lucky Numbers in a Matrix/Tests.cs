using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._1380._Lucky_Numbers_in_a_Matrix;

[TestFixture]
public class Tests
{
  [TestCaseSource(nameof(testCases))]
  public void Test1(int[][] matrix, int[] expected)
  {
    new Solution().LuckyNumbers(matrix).Should().BeEquivalentTo(expected);
    new MinMaxSolution().LuckyNumbers(matrix).Should().BeEquivalentTo(expected);
  }
  
  private static IEnumerable<object[]> testCases = new[]
  {
    new object[]
    {
      new[]
      {
        new[] { 3, 7, 8 },
        new[] { 9, 11, 13 },
        new[] { 15, 16, 17 }
      },
      new[] { 15 }
    },
    new object[]
    {
      new[]
      {
        new[] { 1, 10, 4, 2 },
        new[] { 9, 3, 8, 7 },
        new[] { 15, 16, 17, 12 }
      },
      new[] { 12 }
    },
    new object[]
    {
      new[]
      {
        new[] { 7, 8 },
        new[] { 1, 2 },
      },
      new[] { 7 }
    }
  };
}