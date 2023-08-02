using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._77._Combinations;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().Combine(4, 2).Should().BeEquivalentTo(
      new[]
      {
        new[] { 1, 2 },
        new[] { 1, 3 },
        new[] { 1, 4 },
        new[] { 2, 3 },
        new[] { 2, 4 },
        new[] { 3, 4 }
      });
  }

  [Test]
  public void Test2()
  {
    new Solution().Combine(1, 1).Should().BeEquivalentTo(
      new[]
      {
        new[] { 1 }
      });
  }
  
  [Test]
  public void Test3()
  {
    new Solution().Combine(20, 10).Should().HaveCount(184756);
  }
}