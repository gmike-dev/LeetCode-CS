namespace LeetCode.__Strings._567._Permutation_in_String;

public class Solution2
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

    var diff = 0;
    for (var i = 0; i < 26; i++)
    {
      if (c1[i] != c2[i])
        diff++;
    }

    for (var i = m - 1; i < n; i++)
    {
      var c = s2[i] - 'a';
      c2[c]++;
      if (c2[c] == c1[c])
        diff--;
      else if (c2[c] == c1[c] + 1)
        diff++;
      if (diff == 0)
        return true;
      c = s2[i - m + 1] - 'a';
      c2[c]--;
      if (c2[c] == c1[c])
        diff--;
      else if (c2[c] == c1[c] - 1)
        diff++;
    }

    return false;
  }
}

[TestFixture]
public class Solution2Tests
{
  [TestCase("ab", "eidbaooo", true)]
  [TestCase("ab", "eidboaoo", false)]
  [TestCase("abc", "dfkbjcasd", false)]
  [TestCase("abc", "dfkbcafsd", true)]
  [TestCase("abc", "abc", true)]
  [TestCase("abc", "ab", false)]
  [TestCase("a", "a", true)]
  [TestCase("abc", "bbbca", true)]
  public void Test(string s1, string s2, bool expected)
  {
    new Solution2().CheckInclusion(s1, s2).Should().Be(expected);
  }
}
