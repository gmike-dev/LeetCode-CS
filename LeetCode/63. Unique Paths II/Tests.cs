using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._63._Unique_Paths_II;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().UniquePathsWithObstacles(
      new[]
      {
        new[] { 0, 0, 0 },
        new[] { 0, 1, 0 },
        new[] { 0, 0, 0 }
      }).Should().Be(2);
  }
  
  [Test]
  public void Test2()
  {
    new Solution().UniquePathsWithObstacles(
      new[]
      {
        new[] { 0, 1 },
        new[] { 0, 0 }
      }).Should().Be(1);
  }
}