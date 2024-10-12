namespace LeetCode.Strings._1249._Minimum_Remove_to_Make_Valid_Parentheses;

public class Solution
{
  public string MinRemoveToMakeValid(string s)
  {
    var close = s.Count(c => c == ')');
    var open = 0;
    var result = new StringBuilder();
    foreach (var c in s)
    {
      if (c == '(')
      {
        if (open == close)
          continue;
        open++;
      }
      else if (c == ')')
      {
        close--;
        if (open == 0)
          continue;
        open--;
      }
      result.Append(c);
    }
    return result.ToString();
  }
}

[TestFixture]
public class Tests
{
  [TestCase("lee(t(c)o)de)", "lee(t(c)o)de")]
  [TestCase("a)b(c)d", "ab(c)d")]
  [TestCase("))((", "")]
  [TestCase("(a(b(c)d)", "(a(bc)d)")]
  public void Test(string s, string expected)
  {
    new Solution().MinRemoveToMakeValid(s).Should().Be(expected);
  }
}
