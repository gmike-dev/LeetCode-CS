namespace LeetCode.Strings._1544._Make_The_String_Great;

[TestFixture]
public class Tests
{
  [TestCase("leEeetcode", "leetcode")]
  [TestCase("abBAcC", "")]
  [TestCase("s", "s")]
  public void Test(string s, string expected)
  {
    new Solution1().MakeGood(s).Should().Be(expected);
    new Solution2().MakeGood(s).Should().Be(expected);
  }
}
