using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._91._Decode_Ways;

[TestFixture]
public class Tests
{
  [TestCase("12", 2)]
  [TestCase("226", 3)]
  [TestCase("06", 0)]
  [TestCase("1234", 3)]
  public void Test(string s, int expected)
  {
    new Solution().NumDecodings(s).Should().Be(expected);
  }
}