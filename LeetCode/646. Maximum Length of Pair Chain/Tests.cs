using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._646._Maximum_Length_of_Pair_Chain;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().FindLongestChain(new[]
    {
      new[] { 1, 2 }, new[] { 2, 3 }, new[] { 3, 4 }
    }).Should().Be(2);
  }

  [Test]
  public void Test2()
  {
    new Solution().FindLongestChain(new[]
    {
      new[] { 1, 2 }, new[] { 7, 8 }, new[] { 4, 5 }
    }).Should().Be(3);
  }
}