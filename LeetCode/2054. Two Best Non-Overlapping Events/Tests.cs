using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._2054._Two_Best_Non_Overlapping_Events;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().MaxTwoEvents(new[]
    {
      new[] { 1, 3, 2 }, new[] { 4, 5, 2 }, new[] { 2, 4, 3 }
    }).Should().Be(4);
  }

  [Test]
  public void Test2()
  {
    new Solution().MaxTwoEvents(new[]
    {
      new[] { 1, 3, 2 }, new[] { 4, 5, 2 }, new[] { 1, 5, 5 }
    }).Should().Be(5);
  }

  [Test]
  public void Test3()
  {
    new Solution().MaxTwoEvents(new[]
    {
      new[] { 1, 5, 3 }, new[] { 1, 5, 1 }, new[] { 6, 6, 5 }
    }).Should().Be(8);
  }
}