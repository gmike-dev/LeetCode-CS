using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._1706._Where_Will_the_Ball_Fall;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().FindBall(new[]
    {
      new[] { 1, 1, 1, -1, -1 },
      new[] { 1, 1, 1, -1, -1 },
      new[] { -1, -1, -1, 1, 1 },
      new[] { 1, 1, 1, 1, -1 },
      new[] { -1, -1, -1, -1, -1 }
    }).Should().BeEquivalentTo(new[] { 1, -1, -1, -1, -1 },
      o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new Solution().FindBall(new[]
    {
      new[] { 1, 1, 1, 1, 1, 1 },
      new[] { -1, -1, -1, -1, -1, -1 },
      new[] { 1, 1, 1, 1, 1, 1 },
      new[] { -1, -1, -1, -1, -1, -1 }
    }).Should().BeEquivalentTo(new[] { 0, 1, 2, 3, 4, -1 },
      o => o.WithStrictOrdering());
  }
}