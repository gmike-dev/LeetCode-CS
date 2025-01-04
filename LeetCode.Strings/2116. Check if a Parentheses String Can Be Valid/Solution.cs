namespace LeetCode.Strings._2116._Check_if_a_Parentheses_String_Can_Be_Valid;

public class Solution
{
  public bool CanBeValid(string s, string locked)
  {
    if (s.Length % 2 != 0)
      return false;

    var balance = 0;
    for (var i = 0; i < s.Length; i++)
    {
      if (locked[i] == '0' || s[i] == '(')
        balance++;
      else
        balance--;
      if (balance < 0)
        return false;
    }
    balance = 0;
    for (var i = s.Length - 1; i >= 0; i--)
    {
      if (locked[i] == '0' || s[i] == ')')
        balance++;
      else
        balance--;
      if (balance < 0)
        return false;
    }
    return true;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("))()))", "010100", true)]
  [TestCase("()()", "0000", true)]
  [TestCase(")", "0", false)]
  public void Test(string s, string locked, bool expected)
  {
    new Solution().CanBeValid(s, locked).Should().Be(expected);
  }
}
