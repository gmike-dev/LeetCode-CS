using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._1420._Build_Array;

[TestFixture]
public class Tests
{
  [TestCase(2, 3, 1, 6)]
  [TestCase(5, 2, 3, 0)]
  [TestCase(9, 1, 1, 1)]
  [TestCase(50, 100, 25, 34549172)]
  public void Test(int n, int m, int k, int expected)
  {
    new Solution().NumOfArrays(n, m, k).Should().Be(expected);
  }
}