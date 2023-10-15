using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._1269._Number_of_Ways_to_Stay_in_the_Same_Place;

[TestFixture]
public class Tests
{
  [TestCase(3, 2, 4)]
  [TestCase(2, 4, 2)]
  [TestCase(4, 2, 8)]
  [TestCase(438, 315977, 483475137)]
  public void Test(int steps, int arrLen, int expected)
  {
    new Solution().NumWays(steps, arrLen).Should().Be(expected);
  }
}