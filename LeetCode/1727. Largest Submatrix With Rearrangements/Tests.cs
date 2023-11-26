using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._1727._Largest_Submatrix_With_Rearrangements;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().LargestSubmatrix(new[]
    {
      new[] { 0, 0, 1 },
      new[] { 1, 1, 1 },
      new[] { 1, 0, 1 }
    }).Should().Be(4);
    new ShortSolution().LargestSubmatrix(new[]
    {
      new[] { 0, 0, 1 },
      new[] { 1, 1, 1 },
      new[] { 1, 0, 1 }
    }).Should().Be(4);
  }

  [Test]
  public void Test2()
  {
    new Solution().LargestSubmatrix(new[]
    {
      new[] { 1, 0, 1, 0, 1 }
    }).Should().Be(3);
    new ShortSolution().LargestSubmatrix(new[]
    {
      new[] { 1, 0, 1, 0, 1 }
    }).Should().Be(3);
  }

  [Test]
  public void Test3()
  {
    new Solution().LargestSubmatrix(new[]
    {
      new[] { 1, 1, 0 },
      new[] { 1, 0, 1 }
    }).Should().Be(2);
    new ShortSolution().LargestSubmatrix(new[]
    {
      new[] { 1, 1, 0 },
      new[] { 1, 0, 1 }
    }).Should().Be(2);
  }
}