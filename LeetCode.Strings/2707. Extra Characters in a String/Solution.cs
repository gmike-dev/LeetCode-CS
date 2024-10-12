namespace LeetCode.Strings._2707._Extra_Characters_in_a_String;

public class Solution
{
  public int MinExtraChar(string s, string[] dictionary)
  {
    var dp = new int[s.Length + 1];
    for (var i = 1; i <= s.Length; i++)
    {
      dp[i] = dp[i - 1] + 1;
      var prefix = s.AsSpan(0, i);
      foreach (var word in dictionary)
      {
        if (prefix.EndsWith(word))
          dp[i] = Math.Min(dp[i], dp[i - word.Length]);
      }
    }
    return dp[^1];
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("leetcode", new[] { "leet", "code", "leetcode" }, 0)]
  [TestCase("leetscode", new[] { "leet", "code", "leetcode" }, 1)]
  [TestCase("sayhelloworld", new[] { "hello", "world" }, 3)]
  [TestCase("dwmodizxvvbosxxw", new[] { "ox","lb","diz","gu","v","ksv","o","nuq","r","txhe","e","wmo","cehy","tskz","ds","kzbu" }, 7)]
  public void Test(string s, string[] dictionary, int expected)
  {
    new Solution().MinExtraChar(s, dictionary).Should().Be(expected);
  }
}
