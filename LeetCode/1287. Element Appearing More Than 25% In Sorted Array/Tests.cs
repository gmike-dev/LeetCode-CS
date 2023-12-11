using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._1287._Element_Appearing_More_Than_25__In_Sorted_Array;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 1, 2, 2, 6, 6, 6, 6, 7, 10 }, 6)]
  [TestCase(new[] { 1, 1 }, 1)]
  [TestCase(new[] { 1, 2, 2, 6, 6, 6, 6, 7, 10 }, 6)]
  [TestCase(new[] { 1, 1, 2, 2, 3, 3, 3, 3 }, 3)]
  [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 12, 12, 12 }, 12)]
  public void Test(int[] arr, int expected)
  {
    new LinearSolution().FindSpecialInteger(arr).Should().Be(expected);
    new FastLinearSolution().FindSpecialInteger(arr).Should().Be(expected);
    new BinarySearchSolution().FindSpecialInteger(arr).Should().Be(expected);
  }
}