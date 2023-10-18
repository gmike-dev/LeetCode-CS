using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._2050._Parallel_Courses_III;

[TestFixture]
public class BfsTests
{
  [Test]
  public void Test1()
  {
    new BfsSolution().MinimumTime(3, new[]
    {
      new[] { 1, 3 },
      new[] { 2, 3 }
    }, new[] { 3, 2, 5 }).Should().Be(8);
  }

  [Test]
  public void Test2()
  {
    new BfsSolution().MinimumTime(5, new[]
    {
      new[] { 1, 5 },
      new[] { 2, 5 },
      new[] { 3, 5 },
      new[] { 3, 4 },
      new[] { 4, 5 }
    }, new[] { 1, 2, 3, 4, 5 }).Should().Be(12);
  }
}