using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._67._Add_Binary;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().AddBinary("11", "1").Should().Be("100");
    new Solution().AddBinary("1010", "1011").Should().Be("10101");
  }
}