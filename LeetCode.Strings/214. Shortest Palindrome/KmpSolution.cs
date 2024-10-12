namespace LeetCode.Strings._214._Shortest_Palindrome;

public class KmpSolution
{
  public string ShortestPalindrome(string s)
  {
    var n = s.Length;
    var ss = new char[n * 2 + 1];
    s.CopyTo(ss);
    ss[n] = '$';
    s.CopyTo(ss.AsSpan(n + 1));
    ss.AsSpan(n + 1).Reverse();
    var pi = PiFunc(new string(ss));
    var prefixLength = pi[^1];
    var result = new char[2 * n - prefixLength];
    s.CopyTo(result.AsSpan(n - prefixLength));
    s.AsSpan(prefixLength).CopyTo(result);
    result.AsSpan(0, n - prefixLength).Reverse();
    return new string(result);
  }

  private static int[] PiFunc(string s)
  {
    var n = s.Length;
    var pi = new int[n];
    pi[0] = 0;
    var k = 0;
    for (var i = 1; i < n; i++)
    {
      while (k != 0 && s[k] != s[i])
        k = pi[k - 1];
      if (s[k] == s[i])
        k++;
      pi[i] = k;
    }
    return pi;
  }
}

[TestFixture]
public class KmpSolutionTests
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
    new KmpSolution().ShortestPalindrome(s).Should().Be(expected);
  }
}
