namespace LeetCode._2734._Lexicographically_Smallest_String;

[TestFixture]
public class Tests
{
  [TestCase("cbabc", "baabc")]
  [TestCase("acbbc", "abaab")]
  [TestCase("leetcode", "kddsbncd")]
  [TestCase("aaa", "aaz")]
  [TestCase("aab", "aaa")]
  [TestCase("a", "z")]
  public void Test(string s, string expected)
  {
    new Solution().SmallestString(s).Should().Be(expected);
  }
}
