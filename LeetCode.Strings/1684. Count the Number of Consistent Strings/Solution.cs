namespace LeetCode.Strings._1684._Count_the_Number_of_Consistent_Strings;

public class Solution
{
  public int CountConsistentStrings(string allowed, string[] words)
  {
    var allowedMask = GetMask(allowed);
    var count = 0;
    foreach (var word in words)
    {
      var wordMask = GetMask(word);
      if ((allowedMask & wordMask) == wordMask)
        count++;
    }
    return count;
  }

  private static int GetMask(string s)
  {
    var mask = 0;
    foreach (var c in s)
      mask |= 1 << (c - 'a');
    return mask;
  }
}

[TestFixture]
public class Tests
{
  [TestCase("ab", new[] { "ad", "bd", "aaab", "baa", "badab" }, 2)]
  [TestCase("abc", new[] { "a", "b", "c", "ab", "ac", "bc", "abc" }, 7)]
  [TestCase("cad", new[] { "cc", "acd", "b", "ba", "bac", "bad", "ac", "d" }, 4)]
  public void Test(string allowed, string[] words, int expected)
  {
    new Solution().CountConsistentStrings(allowed, words).Should().Be(expected);
  }
}
