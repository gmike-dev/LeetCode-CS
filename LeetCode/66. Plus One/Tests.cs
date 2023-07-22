using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._66._Plus_One;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().PlusOne(new[] { 1, 2, 3 }).Should().BeEquivalentTo(new[] { 1, 2, 4 });
    new Solution().PlusOne(new[] { 9, 9, 9 }).Should().BeEquivalentTo(new[] { 1, 0, 0, 0 });
    new Solution().PlusOne(new[] { 9 }).Should().BeEquivalentTo(new[] { 1, 0 });
  }
}