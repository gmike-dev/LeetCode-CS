using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._2251._Number_of_Flowers_in_Full_Bloom;

[TestFixture]
public class BinarySearchSolutionTests
{
  [Test]
  public void Test1()
  {
    new BinarySearchSolution().FullBloomFlowers(
        new[]
        {
          new[] { 1, 6 },
          new[] { 3, 7 },
          new[] { 9, 12 },
          new[] { 4, 13 }
        },
        new[] { 2, 3, 7, 11 })
      .Should()
      .BeEquivalentTo(new[] { 1, 2, 2, 2 }, o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new BinarySearchSolution().FullBloomFlowers(
        new[]
        {
          new[] { 1, 10 },
          new[] { 3, 3 }
        },
        new[] { 3, 3, 2 })
      .Should()
      .BeEquivalentTo(new[] { 2, 2, 1 }, o => o.WithStrictOrdering());
  }

  [Test]
  public void Test12()
  {
    new BinarySearchSolution().FullBloomFlowers(
        new[]
        {
          new[] { 19, 37 },
          new[] { 19, 38 },
          new[] { 19, 35 }
        },
        new[] { 6, 7, 21, 1, 13, 37, 5, 37, 46, 43 })
      .Should()
      .BeEquivalentTo(new[] { 0, 0, 3, 0, 0, 2, 0, 2, 0, 0 }, o => o.WithStrictOrdering());
  }
}