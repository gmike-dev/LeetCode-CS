using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._2610._Convert_an_Array_Into_a_2D_Array;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().FindMatrix(new[] { 1, 3, 4, 1, 2, 3, 1 }).Should().BeEquivalentTo(
      new[]
      {
        new[] { 1, 3, 4, 2 },
        new[] { 1, 3 },
        new[] { 1 }
      });
  }

  [Test]
  public void Test2()
  {
    new Solution().FindMatrix(new[] { 1, 2, 3, 4 }).Should().BeEquivalentTo(
      new[]
      {
        new[] { 1, 2, 3, 4 }
      });
  }
}