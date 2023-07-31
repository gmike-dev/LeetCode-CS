using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._712._Minimum_ASCII_Delete_Sum_for_Two_Strings;

[TestFixture]
public class Tests
{
  [TestCase("sea", "eat", 231)]
  [TestCase("delete", "leet", 403)]
  public void Test1(string s1, string s2, int expected)
  {
    new Solution().MinimumDeleteSum(s1, s2).Should().Be(expected);
    new Solution().MinimumDeleteSum_Recursion(s1, s2).Should().Be(expected);
  }
}