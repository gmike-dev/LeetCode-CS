namespace LeetCode.__Strings._567._Permutation_in_String;

public class Solution
{
  public bool CheckInclusion(string s1, string s2)
  {
    var m = s1.Length;
    var n = s2.Length;

    if (m > n)
      return false;

    var c1 = new int[26];
    for (var i = 0; i < m; i++)
      c1[s1[i] - 'a']++;

    var c2 = new int[26];
    for (var i = 0; i < m - 1; i++)
      c2[s2[i] - 'a']++;

    for (var i = m - 1; i < n; i++)
    {
      c2[s2[i] - 'a']++;
      if (c1.AsSpan().SequenceEqual(c2))
        return true;
      c2[s2[i - m + 1] - 'a']--;
    }

    return false;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("ab", "eidbaooo", true)]
  [TestCase("ab", "eidboaoo", false)]
  [TestCase("abc", "dfkbjcasd", false)]
  [TestCase("abc", "dfkbcafsd", true)]
  [TestCase("abc", "abc", true)]
  [TestCase("abc", "ab", false)]
  [TestCase("a", "a", true)]
  public void Test(string s1, string s2, bool expected)
  {
    new Solution().CheckInclusion(s1, s2).Should().Be(expected);
  }
}
