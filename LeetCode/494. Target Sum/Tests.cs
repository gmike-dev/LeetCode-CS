using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._494._Target_Sum;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 1, 1, 1, 1, 1 }, 3, 5)]
  [TestCase(new[] { 1 }, 1, 1)]
  [TestCase(new[] { 1, 2, 3 }, 6, 1)]
  [TestCase(new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 10, 15504)]
  [TestCase(new[] { 0,0,0,0,0,0,0,0,1 }, 1, 256)]
  public void Test(int[] nums, int target, int expected)
  {
    new RecursiveSolution().FindTargetSumWays(nums, target).Should().Be(expected);
    new DpSolution().FindTargetSumWays(nums, target).Should().Be(expected);
  }
}