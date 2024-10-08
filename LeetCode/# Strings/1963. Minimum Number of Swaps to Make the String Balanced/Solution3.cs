namespace LeetCode.__Strings._1963._Minimum_Number_of_Swaps_to_Make_the_String_Balanced;

public class Solution3
{
  public int MinSwaps(string s)
  {
    var balance = 0;
    foreach (var c in s)
    {
      if (c == '[')
        balance++;
      else if (balance > 0)
        balance--;
    }
    return (balance + 1) / 2;
  }
}

[TestFixture]
public class Solution3Tests
{
  [TestCase("][][", 1)]
  [TestCase("]]][[[", 2)]
  [TestCase("[]", 0)]
  [TestCase("][", 1)]
  [TestCase("][]][[", 1)]
  [TestCase("[[[]]]][][]][[]]][[[", 2)]
  public void Test(string s, int expected)
  {
    new Solution3().MinSwaps(s).Should().Be(expected);
  }
}
