using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._1615._Maximal_Network_Rank;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().MaximalNetworkRank(4, new[]
    {
      new[] { 0, 1 }, new[] { 0, 3 }, new[] { 1, 2 }, new[] { 1, 3 }
    }).Should().Be(4);
  }

  [Test]
  public void Test2()
  {
    new Solution().MaximalNetworkRank(8, new[]
    {
      new[] { 0, 1 }, new[] { 0, 3 }, new[] { 1, 2 }, new[] { 1, 3 },
      new[] { 2, 3 }, new[] { 2, 4 }
    }).Should().Be(5);
  }

  [Test]
  public void Test3()
  {
    new Solution().MaximalNetworkRank(8, new[]
    {
      new[] { 0, 1 }, new[] { 1, 2 }, new[] { 2, 3 }, new[] { 2, 4 },
      new[] { 5, 6 }, new[] { 5, 7 }
    }).Should().Be(5);
  }
}