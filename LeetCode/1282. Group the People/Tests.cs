using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._1282._Group_the_People;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().GroupThePeople(new[] { 3, 3, 3, 3, 3, 1, 3 }).Should().BeEquivalentTo(new[]
    {
      new[] { 5 },
      new[] { 0, 1, 2 },
      new[] { 3, 4, 6 },
    });
  }

  [Test]
  public void Test2()
  {
    new Solution().GroupThePeople(new[] { 2, 1, 3, 3, 3, 2 }).Should().BeEquivalentTo(new[]
    {
      new[] { 1 },
      new[] { 0, 5 },
      new[] { 2, 3, 4 },
    });
  }
}