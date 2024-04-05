namespace LeetCode._1930._Unique_Length_3_Palindromic_Subsequences;

[TestFixture]
public class Tests
{
  [TestCase("aabca", 3)]
  [TestCase("acd", 0)]
  [TestCase("bbcbaba", 4)]
  public void Test(string s, int expected)
  {
    new Solution().CountPalindromicSubsequence(s).Should().Be(expected);
    new BitmasksSolution().CountPalindromicSubsequence(s).Should().Be(expected);
  }
}
