namespace LeetCode.Strings._796._Rotate_String;

public class Solution
{
  public bool RotateString(string s, string goal)
  {
    var n = s.Length;
    if (n != goal.Length)
      return false;
    for (var i = 0; i < n; i++)
    {
      var equals = true;
      for (var j = 0; j < n && equals; j++)
      {
        if (s[(i + j) % n] != goal[j])
          equals = false;
      }
      if (equals)
        return true;
    }
    return false;
  }
}

[TestFixture]
public class SolutionTests
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
    new Solution().RotateString(s, goal).Should().Be(expected);
  }
}
