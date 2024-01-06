using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._1235._Maximum_Profit_in_Job_Scheduling;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 1, 2, 3, 4, 6 }, new[] { 3, 5, 10, 6, 9 }, new[] { 20, 20, 100, 70, 60 }, 150)]
  [TestCase(new[] { 1, 1, 1 }, new[] { 2, 3, 4 }, new[] { 5, 6, 4 }, 6)]
  [TestCase(new[] { 1, 2, 2, 3 }, new[] { 2, 5, 3, 4 }, new[] { 3, 4, 1, 2 }, 7)]
  public void Test1(int[] startTime, int[] endTime, int[] profit, int expected)
  {
    new Solution().JobScheduling(startTime, endTime, profit).Should().Be(expected);
  }
}