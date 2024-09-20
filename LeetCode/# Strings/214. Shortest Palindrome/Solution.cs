namespace LeetCode.__Strings._214._Shortest_Palindrome;

public class Solution
{
  public string ShortestPalindrome(string s)
  {
    if (s.Length < 2)
      return s;
    for (var n = (s.Length + 1) / 2; n <= s.Length; n++)
    {
      var l = s.Length - n;
      if (CanBuildPalindrome(s, l, l))
      {
        var chars = new char[n * 2 - 1];
        s.AsSpan(l).CopyTo(chars);
        chars.AsSpan(0, n).Reverse();
        s.AsSpan(l).CopyTo(chars.AsSpan(n - 1));
        return new string(chars);
      }
      if (CanBuildPalindrome(s, l - 1, l))
      {
        var chars = new char[n * 2];
        s.AsSpan(l).CopyTo(chars);
        chars.AsSpan(0, n).Reverse();
        s.AsSpan(l).CopyTo(chars.AsSpan(n));
        return new string(chars);
      }
    }
    throw new InvalidOperationException();
  }

  private static bool CanBuildPalindrome(string s, int l, int r)
  {
    for (; l >= 0 && r < s.Length; l--, r++)
    {
      if (s[l] != s[r])
        return false;
    }
    return l < 0;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("aacecaaa", "aaacecaaa")]
  [TestCase("abcd", "dcbabcd")]
  [TestCase("cabdef", "fedbacabdef")]
  [TestCase("abcbadef", "fedabcbadef")]
  [TestCase("a", "a")]
  [TestCase("", "")]
  [TestCase("aa", "aa")]
  [TestCase("aba", "aba")]
  [TestCase("abc", "cbabc")]
  [TestCase("aab", "baab")]
  public void Test(string s, string expected)
  {
    new Solution().ShortestPalindrome(s).Should().Be(expected);
  }
}
