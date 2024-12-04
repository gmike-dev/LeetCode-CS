namespace LeetCode.Strings._2825._Make_String_a_Subsequence_Using_Cyclic_Increments;

public class Solution
{
  public bool CanMakeSubsequence(string s, string t)
  {
    if (s.Length >= t.Length)
    {
      for (int i = 0, j = 0; i < s.Length; i++)
      {
        if (s[i] == t[j] || 'a' + (s[i] - 'a' + 1) % 26 == t[j])
          j++;
        if (j == t.Length)
          return true;
      }
    }
    return false;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("abc", "ad", true)]
  [TestCase("zc", "ad", true)]
  [TestCase("ab", "d", false)]
  public void Test(string s, string t, bool expected)
  {
    new Solution().CanMakeSubsequence(s, t).Should().Be(expected);
  }
}
