namespace LeetCode.DP._139._Word_Break;

/// <summary>
/// https://leetcode.com/problems/word-break/
/// </summary>
public class RecursionSolution
{
  public bool WordBreak(string s, IList<string> wordDict)
  {
    int[] dp = new int[s.Length];
    return CanBuild(0);

    bool CanBuild(int start)
    {
      if (start >= s.Length)
        return true;
      if (dp[start] == 0)
      {
        bool result = wordDict.Any(
          w => s.AsSpan(start).StartsWith(w) && CanBuild(start + w.Length));
        dp[start] = result ? 1 : 2;
      }
      return dp[start] == 1;
    }
  }
}

[TestFixture]
public class RecursionSolutionTests
{
  [TestCase("leetcode", new[] { "leet", "code" }, true)]
  [TestCase("applepenapple", new[] { "apple", "pen" }, true)]
  [TestCase("catsandog", new[] { "cats", "dog", "sand", "and", "cat" }, false)]
  public void Test1(string s, IList<string> wordDict, bool expected)
  {
    new RecursionSolution().WordBreak(s, wordDict).Should().Be(expected);
  }
}
