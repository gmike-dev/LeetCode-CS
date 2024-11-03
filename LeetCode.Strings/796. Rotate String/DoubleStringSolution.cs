namespace LeetCode.Strings._796._Rotate_String;

public class DoubleStringSolution
{
  public bool RotateString(string s, string goal)
  {
    return s.Length == goal.Length && (s + s).Contains(goal);
  }
}

[TestFixture]
public class DoubleStringSolutionTests
{
  [TestCase("abcde", "cdeab", true)]
  [TestCase("abcde", "abced", false)]
  [TestCase("a", "ab", false)]
  [TestCase("a", "a", true)]
  [TestCase("ab", "ba", true)]
  [TestCase("ab", "ca", false)]
  [TestCase("abcdefghijklmnopqrstuvwxyz", "bcdefghijklmnopqrstuvwxyza", true)]
  public void Test(string s, string goal, bool expected)
  {
    new DoubleStringSolution().RotateString(s, goal).Should().Be(expected);
  }
}
