namespace LeetCode.Strings._2914._Minimum_Number_of_Changes_to_Make_Binary_String_Beautiful;

public class Solution
{
  public int MinChanges(string s)
  {
    var n = s.Length;
    var minChanges = 0;
    for (var i = 0; i < n; i += 2)
    {
      if (s[i] != s[i + 1])
        minChanges++;
    }
    return minChanges;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("1001", 2)]
  [TestCase("10", 1)]
  [TestCase("0000", 0)]
  [TestCase("11000111", 1)]
  public void Test(string s, int expected)
  {
    new Solution().MinChanges(s).Should().Be(expected);
  }
}
