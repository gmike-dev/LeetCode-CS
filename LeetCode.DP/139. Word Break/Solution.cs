namespace LeetCode.DP._139._Word_Break;

public class Solution
{
  public bool WordBreak(string s, IList<string> wordDict)
  {
    int n = s.Length;
    Span<bool> dp = stackalloc bool[n + 1];
    dp[0] = true;
    for (int i = 0; i < n; i++)
    {
      if (dp[i])
      {
        foreach (string word in wordDict)
        {
          if (s.AsSpan(i).StartsWith(word))
          {
            dp[i + word.Length] = true;
          }
        }
      }
    }
    return dp[n];
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("leetcode", new[] { "leet", "code" }, true)]
  [TestCase("applepenapple", new[] { "apple", "pen" }, true)]
  [TestCase("catsandog", new[] { "cats", "dog", "sand", "and", "cat" }, false)]
  public void Test1(string s, IList<string> wordDict, bool expected)
  {
    new Solution().WordBreak(s, wordDict).Should().Be(expected);
  }
}
