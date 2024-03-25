using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.__Strings._2707._Extra_Characters_in_a_String;

[TestFixture]
public class Tests
{
  [TestCase("leetcode", new[] { "leet", "code", "leetcode" }, 0)]
  [TestCase("leetscode", new[] { "leet", "code", "leetcode" }, 1)]
  [TestCase("sayhelloworld", new[] { "hello", "world" }, 3)]
  [TestCase("dwmodizxvvbosxxw", new[] { "ox","lb","diz","gu","v","ksv","o","nuq","r","txhe","e","wmo","cehy","tskz","ds","kzbu" }, 7)]
  public void Test(string s, string[] dictionary, int expected)
  {
    new Solution().MinExtraChar(s, dictionary).Should().Be(expected);
    new TrieSolution().MinExtraChar(s, dictionary).Should().Be(expected);
    new RecursiveSolution().MinExtraChar(s, dictionary).Should().Be(expected);
  }
}
