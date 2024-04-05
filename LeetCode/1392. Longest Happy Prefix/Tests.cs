namespace LeetCode._1392._Longest_Happy_Prefix;

[TestFixture]
public class Tests
{
  [TestCase("level", "l")]
  [TestCase("ababab", "abab")]
  [TestCase("bba", "")]
  [TestCase("aba", "a")]
  public void Test(string s, string expected)
  {
    new Solution().LongestPrefix(s).Should().Be(expected);
  }
}
