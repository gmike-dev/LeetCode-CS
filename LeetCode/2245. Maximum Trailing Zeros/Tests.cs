using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._2245._Maximum_Trailing_Zeros;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().MaxTrailingZeros(new[]
    {
      new[] { 23, 17, 15, 3, 20 },
      new[] { 8, 1, 20, 27, 11 },
      new[] { 9, 4, 6, 2, 21 },
      new[] { 40, 9, 1, 10, 6 },
      new[] { 22, 7, 4, 5, 3 }
    }).Should().Be(3);
    new SolutionUsingStruct().MaxTrailingZeros(new[]
    {
      new[] { 23, 17, 15, 3, 20 },
      new[] { 8, 1, 20, 27, 11 },
      new[] { 9, 4, 6, 2, 21 },
      new[] { 40, 9, 1, 10, 6 },
      new[] { 22, 7, 4, 5, 3 }
    }).Should().Be(3);
  }

  [Test]
  public void Test2()
  {
    new Solution().MaxTrailingZeros(new[]
    {
      new[] { 4, 3, 2 },
      new[] { 7, 6, 1 },
      new[] { 8, 8, 8 }
    }).Should().Be(0);
    new SolutionUsingStruct().MaxTrailingZeros(new[]
    {
      new[] { 4, 3, 2 },
      new[] { 7, 6, 1 },
      new[] { 8, 8, 8 }
    }).Should().Be(0);
  }

  [Test]
  public void Test3()
  {
    new Solution().MaxTrailingZeros(new[]
    {
      new[] { 2, 5, 5 }
    }).Should().Be(1);
    new Solution().MaxTrailingZeros(new[]
    {
      new[] { 2 },
      new[] { 5 },
      new[] { 5 }
    }).Should().Be(1);
    new SolutionUsingStruct().MaxTrailingZeros(new[]
    {
      new[] { 2, 5, 5 }
    }).Should().Be(1);
    new SolutionUsingStruct().MaxTrailingZeros(new[]
    {
      new[] { 2 },
      new[] { 5 },
      new[] { 5 }
    }).Should().Be(1);
  }

  [Test]
  public void Test43()
  {
    new Solution().MaxTrailingZeros(new[]
    {
      new[] { 242, 921, 651, 509, 130, 857 },
      new[] { 486, 959, 4, 159, 150, 655 },
      new[] { 825, 644, 838, 771, 101, 199 },
      new[] { 781, 770, 193, 492, 930, 670 },
      new[] { 395, 474, 960, 839, 616, 652 },
      new[] { 895, 156, 833, 124, 863, 907 },
      new[] { 603, 921, 383, 279, 654, 933 }
    }).Should().Be(6);
    new SolutionUsingStruct().MaxTrailingZeros(new[]
    {
      new[] { 242, 921, 651, 509, 130, 857 },
      new[] { 486, 959, 4, 159, 150, 655 },
      new[] { 825, 644, 838, 771, 101, 199 },
      new[] { 781, 770, 193, 492, 930, 670 },
      new[] { 395, 474, 960, 839, 616, 652 },
      new[] { 895, 156, 833, 124, 863, 907 },
      new[] { 603, 921, 383, 279, 654, 933 }
    }).Should().Be(6);
  }

  [Test]
  public void Test50()
  {
    new Solution().MaxTrailingZeros(new[]
    {
      new[] { 534, 575, 625, 84, 20, 999, 35 },
      new[] { 208, 318, 96, 380, 819, 102, 669 }
    }).Should().Be(8);
    new SolutionUsingStruct().MaxTrailingZeros(new[]
    {
      new[] { 534, 575, 625, 84, 20, 999, 35 },
      new[] { 208, 318, 96, 380, 819, 102, 669 }
    }).Should().Be(8);
  }
}