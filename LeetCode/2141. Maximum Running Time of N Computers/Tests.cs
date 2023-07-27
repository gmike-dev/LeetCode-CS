using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._2141._Maximum_Running_Time_of_N_Computers;

[TestFixture]
public class Tests
{
  [TestCase(2, new[] { 1, 1, 1, 1 }, 2)]
  [TestCase(2, new[] { 3, 3, 3 }, 4)]
  [TestCase(3, new[] { 10, 10, 3, 5 }, 8)]
  public void Test1(int n, int[] batteries, int expected)
  {
    new Solution().MaxRunTime(n, batteries).Should().Be(expected);
  }
}