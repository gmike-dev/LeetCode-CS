namespace LeetCode.Strings._3._Longest_Substring_Without_Repeating_Characters;

public class Solution
{
  public int LengthOfLongestSubstring(string s)
  {
    var used = new Dictionary<char, int>();
    var length = 0;
    for (int i = 0, j = 0; j < s.Length; j++)
    {
      if (used.TryGetValue(s[j], out var index))
      {
        length = Math.Max(length, used.Count);
        for (; i <= index; i++)
          used.Remove(s[i]);
      }
      used.Add(s[j], j);
    }
    length = Math.Max(length, used.Count);
    return length;
  }
}

[TestFixture]
public class Tests
{
  [TestCase("abcabcbb", 3)]
  [TestCase("bbbbb", 1)]
  [TestCase("pwwkew", 3)]
  [TestCase("", 0)]
  [TestCase("dvdf", 3)]
  public void Test1(string s, int expected)
  {
    new Solution().LengthOfLongestSubstring(s).Should().Be(expected);
  }
}
