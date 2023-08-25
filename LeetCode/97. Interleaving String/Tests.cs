using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._97._Interleaving_String;

[TestFixture]
public class Tests
{
  [TestCase("aabcc", "dbbca", "aadbbcbcac", true)]
  [TestCase("aabcc", "dbbca", "aadbbbaccc", false)]
  [TestCase("", "", "", true)]
  [TestCase("aabcc", "dbbca", "aadbbcbacc", true)]
  [TestCase("abababababababababababababababababababababababababababababababababababababababababababababababababbb",
    "babababababababababababababababababababababababababababababababababababababababababababababababaaaba",
    "abababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababbb",
    false)]
  public void Test(string s1, string s2, string s3, bool expected)
  {
    new Solution().IsInterleave(s1, s2, s3).Should().Be(expected);
    new SolutionUsingMemoization().IsInterleave(s1, s2, s3).Should().Be(expected);
  }
}