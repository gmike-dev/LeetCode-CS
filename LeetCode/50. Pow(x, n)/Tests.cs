using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._50._Pow_x__n_;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().MyPow(2, -2147483648).Should().Be(0);
  }
}