namespace LeetCode.__Strings._1371._Find_the_Longest_Substring_Containing_Vowels_in_Even_Counts;

public class Solution
{
  public int FindTheLongestSubstring(string s)
  {
    var maxLength = 0;
    var vowel = 0;
    var mask = new int[26];
    foreach (var c in "aeiou")
      mask[c - 'a'] = 1 << (c - 'a');
    var d = new Dictionary<int, int> { { 0, -1 } };
    for (var i = 0; i < s.Length; i++)
    {
      var m = mask[s[i] - 'a'];
      if (m != 0)
      {
        vowel ^= m;
        d.TryAdd(vowel, i);
      }
      maxLength = Math.Max(maxLength, i - d.GetValueOrDefault(vowel));
    }
    return maxLength;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("eleetminicoworoep", 13)]
  [TestCase("leetcodeisgreat", 5)]
  [TestCase("bcbcbc", 6)]
  public void Test(string s, int expected)
  {
    new Solution().FindTheLongestSubstring(s).Should().Be(expected);
  }
}
