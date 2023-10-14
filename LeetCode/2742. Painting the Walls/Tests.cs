using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._2742._Painting_the_Walls;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 1, 2, 3, 2 }, new[] { 1, 2, 3, 2 }, 3)]
  [TestCase(new[] { 2, 3, 4, 2 }, new[] { 1, 1, 1, 1 }, 4)]
  [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 1, 1, 1, 5 }, 5)]
  [TestCase(new[] { 26, 53, 10, 24, 25, 20, 63, 51 }, new[] { 1, 1, 1, 1, 2, 2, 2, 1 }, 55)]
  [TestCase(new[] { 49, 35, 32, 20, 30, 12, 42 }, new[] { 1, 1, 2, 2, 1, 1, 2 }, 62)]
  [TestCase(
    new[]
    {
      937, 252, 716, 781, 319, 198, 273, 554, 140, 68, 694, 583, 1080, 16, 450, 229, 710, 1003, 1117, 1036, 398, 874,
      289, 664, 600, 588, 372, 1066, 375, 532, 984, 328, 1067, 746
    }, new[] { 5, 3, 1, 3, 2, 1, 3, 3, 5, 3, 5, 5, 4, 1, 3, 1, 4, 4, 4, 1, 5, 1, 2, 3, 2, 3, 3, 4, 1, 3, 4, 1, 1, 5 },
    1928)]
  public void Test(int[] cost, int[] time, int expected)
  {
    new DpWithMemoizationSolution().PaintWalls(cost, time).Should().Be(expected);
  }
}