using NUnit.Framework;

namespace LeetCode.KnightProbabilityInChessboard;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var sln = new Solution();
    Assert.That(sln.KnightProbability(3, 2, 0, 0), Is.EqualTo(0.06250));
    Assert.That(sln.KnightProbability(1, 0, 0, 0), Is.EqualTo(1));
    Assert.That(sln.KnightProbability(8, 30, 6, 4), Is.EqualTo(0.00019));
  }
}