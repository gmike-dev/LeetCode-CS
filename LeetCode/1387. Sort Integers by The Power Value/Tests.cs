using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._1387._Sort_Integers_by_The_Power_Value;

[TestFixture]
public class Tests
{
  [TestCase(12, 15, 2, 13)]
  [TestCase(7, 11, 4, 7)]
  public void Test(int lo, int hi, int k, int expected)
  {
    new Solution().GetKth(lo, hi, k).Should().Be(expected);
  }
}