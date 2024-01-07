using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._464._Can_I_Win;

[TestFixture]
public class Tests
{
  [TestCase(10, 11, false)]
  [TestCase(10, 0, true)]
  [TestCase(10, 1, true)]
  [TestCase(18, 188, false)]
  [TestCase(5, 50, false)]
  [TestCase(20, 210, false)]
  public void Test(int maxChoosableInteger, int desiredTotal, bool expected)
  {
    new Solution().CanIWin(maxChoosableInteger, desiredTotal).Should().Be(expected);
  }
}