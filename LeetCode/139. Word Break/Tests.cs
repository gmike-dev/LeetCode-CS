using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._139._Word_Break;

[TestFixture]
public class Tests
{
  [TestCase("leetcode", new[] { "leet", "code" }, true)]
  [TestCase("applepenapple", new[] { "apple", "pen" }, true)]
  [TestCase("catsandog", new[] { "cats", "dog", "sand", "and", "cat" }, false)]
  public void Test1(string s, IList<string> wordDict, bool expected)
  {
    new Solution().WordBreak(s, wordDict).Should().Be(expected);
  }
}