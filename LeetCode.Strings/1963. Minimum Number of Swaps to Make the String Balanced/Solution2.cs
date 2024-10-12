namespace LeetCode.Strings._1963._Minimum_Number_of_Swaps_to_Make_the_String_Balanced;

public class Solution2
{
  public int MinSwaps(string s)
  {
    var value = new int[128];
    value['['] = -1;
    value[']'] = 1;
    var maxUnbalance = 0;
    var balance = 0;
    foreach (var c in s)
    {
      balance += value[c];
      maxUnbalance = Math.Max(maxUnbalance, balance);
    }
    return (maxUnbalance + 1) / 2;
  }
}

[TestFixture]
public class Solution2Tests
{
  [TestCase("][][", 1)]
  [TestCase("]]][[[", 2)]
  [TestCase("[]", 0)]
  [TestCase("][", 1)]
  [TestCase("][]][[", 1)]
  [TestCase("[[[]]]][][]][[]]][[[", 2)]
  public void Test(string s, int expected)
  {
    new Solution2().MinSwaps(s).Should().Be(expected);
  }
}
