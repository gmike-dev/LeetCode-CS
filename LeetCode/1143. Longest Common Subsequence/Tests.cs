namespace LeetCode._1143._Longest_Common_Subsequence;

[TestFixture]
public class Tests
{
  [TestCase("abcde", "ace", 3)]
  [TestCase("abc", "abc", 3)]
  [TestCase("abc", "def", 0)]
  public void Test(string text1, string text2, int expected)
  {
    new Solution().LongestCommonSubsequence(text1, text2).Should().Be(expected);
    new SolutionOptimizedDp().LongestCommonSubsequence(text1, text2).Should().Be(expected);
  }
}
