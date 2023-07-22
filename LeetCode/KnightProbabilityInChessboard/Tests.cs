using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.KnightProbabilityInChessboard;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var sln = new Solution();
    sln.KnightProbability(3, 2, 0, 0).Should().Be(0.06250);
    sln.KnightProbability(1, 0, 0, 0).Should().Be(1);
    sln.KnightProbability(8, 30, 6, 4).Should().BeApproximately(0.00019, 0.000001);
  }
}