using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.__Sliding_Window._1358._Number_of_Substrings;

public class Solution
{
  public int NumberOfSubstrings(string s)
  {
    var cnt = new int[3];
    var result = 0;
    for (int l = 0, r = 0; r < s.Length; r++)
    {
      cnt[s[r] - 'a']++;
      for (; cnt[0] > 0 && cnt[1] > 0 && cnt[2] > 0; l++)
        cnt[s[l] - 'a']--;
      result += l;
    }
    return result;
  }
}

[TestFixture]
public class Tests
{
  [TestCase("abcabc", 10)]
  [TestCase("aaacb", 3)]
  [TestCase("abc", 1)]
  [TestCase("acbbcac", 11)]
  public void Test(string s, int expected)
  {
    new Solution().NumberOfSubstrings(s).Should().Be(expected);
  }
}
