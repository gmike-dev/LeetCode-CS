using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._823._Binary_Trees_With_Factors;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 2, 4 }, 3)]
  [TestCase(new[] { 2, 4, 5, 10 }, 7)]
  [TestCase(
    new[]
    {
      45, 42, 2, 18, 23, 1170, 12, 41, 40, 9, 47, 24, 33, 28, 10, 32, 29, 17, 46, 11, 759, 37, 6, 26, 21, 49, 31, 14,
      19, 8, 13, 7, 27, 22, 3, 36, 34, 38, 39, 30, 43, 15, 4, 16, 35, 25, 20, 44, 5, 48
    }, 777)]
  public void Test(int[] arr, int expected)
  {
    new DpSolution().NumFactoredBinaryTrees(arr).Should().Be(expected);
    new DpWithMemoizationSolution().NumFactoredBinaryTrees(arr).Should().Be(expected);
  }
}