namespace LeetCode.__Strings._921._Minimum_Add_to_Make_Parentheses_Valid;

public class Solution
{
  public int MinAddToMakeValid(string s)
  {
    var open = 0;
    var close = 0;
    foreach (var c in s)
    {
      if (c == '(')
        open++;
      else if (open > 0)
        open--;
      else
        close++;
    }
    return open + close;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("())", 1)]
  [TestCase("(((", 3)]
  [TestCase("()))((", 4)]
  public void Test(string s, int expected)
  {
    new Solution().MinAddToMakeValid(s).Should().Be(expected);
  }
}
