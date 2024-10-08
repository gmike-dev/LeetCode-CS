namespace LeetCode.__Strings._1963._Minimum_Number_of_Swaps_to_Make_the_String_Balanced;

public class Solution
{
  public int MinSwaps(string s)
  {
    var balance = new int[128];
    balance['['] = 1;
    balance[']'] = -1;
    var balanceLeft = 0;
    var balanceRight = 0;
    var swaps = 0;
    var right = s.Length;
    foreach (var c in s)
    {
      balanceLeft += balance[c];
      if (balanceLeft < 0)
      {
        while (balanceRight <= 0)
        {
          right--;
          balanceRight += balance[s[right]];
        }
        swaps++;
        balanceLeft += 2;
        balanceRight -= 2;
      }
    }
    return swaps;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("][][", 1)]
  [TestCase("]]][[[", 2)]
  [TestCase("[]", 0)]
  [TestCase("][", 1)]
  [TestCase("][]][[", 1)]
  [TestCase("[[[]]]][][]][[]]][[[", 2)]
  public void Test(string s, int expected)
  {
    new Solution().MinSwaps(s).Should().Be(expected);
  }
}
