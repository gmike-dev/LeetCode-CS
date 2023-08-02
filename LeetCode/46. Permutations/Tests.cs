using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._46._Permutations;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().Permute(new[] { 1, 2, 3 }).Should().BeEquivalentTo(
      new[]
      {
        new[] { 1, 2, 3 },
        new[] { 1, 3, 2 },
        new[] { 2, 1, 3 }, 
        new[] { 2, 3, 1 }, 
        new[] { 3, 1, 2 }, 
        new[] { 3, 2, 1 }
      });
  }
}