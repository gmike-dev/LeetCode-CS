namespace LeetCode._3._Longest_Substring_Without_Repeating_Characters;

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
