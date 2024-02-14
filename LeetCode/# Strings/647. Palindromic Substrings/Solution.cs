using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.__Strings._647._Palindromic_Substrings;

public class Solution
{
  public int CountSubstrings(string s)
  {
    var n = s.Length;
    var count = n;
    for (var i = 0; i < n; i++)
    {
      var l = i - 1;
      var r = i + 1;
      while (l >= 0 && r < n && s[l] == s[r])
      {
        count++;
        l--;
        r++;
      }
      l = i;
      r = i + 1;
      while (l >= 0 && r < n && s[l] == s[r])
      {
        count++;
        l--;
        r++;
      }
    }
    return count;
  }
}

[TestFixture]
public class Tests
{
  [TestCase("abc", 3)]
  [TestCase("aaa", 6)]
  public void Test(string s, int expected)
  {
    new Solution().CountSubstrings(s).Should().Be(expected);
  }
}
