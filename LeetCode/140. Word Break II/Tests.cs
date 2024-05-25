namespace LeetCode._140._Word_Break_II;

[TestFixture]
public class Tests
{
  [TestCase("catsanddog", new[] { "cat", "cats", "and", "sand", "dog" }, new[] { "cats and dog", "cat sand dog" })]
  [TestCase("pineapplepenapple", new[] { "apple", "pen", "applepen", "pine", "pineapple" },
    new[] { "pine apple pen apple", "pineapple pen apple", "pine applepen apple" })]
  [TestCase("catsandog", new[] { "cats", "dog", "sand", "and", "cat" }, new string[0])]
  public void Test(string s, string[] wordDict, string[] expected)
  {
    new Solution().WordBreak(s, wordDict).Should().BeEquivalentTo(expected);
  }
}
