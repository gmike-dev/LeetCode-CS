namespace LeetCode._2938._Separate_Black_and_White_Balls;

public class Solution2
{
  public long MinimumSteps(string s)
  {
    var swaps = 0L;
    var writePos = 0;
    for (var i = 0; i < s.Length; i++)
    {
      if (s[i] == '0')
      {
        swaps += i - writePos;
        writePos++;
      }
    }
    return swaps;
  }
}

[TestFixture]
public class Solution2Tests
{
  [TestCase("101", 1)]
  [TestCase("100", 2)]
  [TestCase("0", 0)]
  [TestCase("1", 0)]
  [TestCase("10", 1)]
  [TestCase("010101", 3)]
  public void Test(string s, int expected)
  {
    new Solution2().MinimumSteps(s).Should().Be(expected);
  }
}
