using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._1220._Count_Vowels_Permutation;

[TestFixture]
public class Tests
{
  [TestCase(1, 5)]
  [TestCase(2, 10)]
  [TestCase(5, 68)]
  public void Test(int n, int expected)
  {
    new Solution().CountVowelPermutation(n).Should().Be(expected);
    new FastSolution().CountVowelPermutation(n).Should().Be(expected);
  }
}