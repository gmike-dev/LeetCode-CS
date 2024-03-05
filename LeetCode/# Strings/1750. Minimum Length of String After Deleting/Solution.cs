using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.__Strings._1750._Minimum_Length_of_String_After_Deleting;

public class Solution
{
  public int MinimumLength(string s)
  {
    var l = 0;
    var r = s.Length - 1;
    while (l < r && s[l] == s[r])
    {
      var c = s[l];
      while (l <= r && s[l] == c)
        l++;
      while (l <= r && s[r] == c)
        r--;
    }
    return r - l + 1;
  }
}

[TestFixture]
public class Tests
{
  [TestCase("ca", 2)]
  [TestCase("cabaabac", 0)]
  [TestCase("aabccabba", 3)]
  [TestCase("bbbbbbbbbbbbbbbbbbbbbbbbbbbabbbbbbbbbbbbbbbccbcbcbccbbabbb", 1)]
  public void Test(string s, int expected)
  {
    new Solution().MinimumLength(s).Should().Be(expected);
  }
}
