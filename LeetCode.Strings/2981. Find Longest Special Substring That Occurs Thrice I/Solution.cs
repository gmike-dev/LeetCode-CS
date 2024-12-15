namespace LeetCode.Strings._2981._Find_Longest_Special_Substring_That_Occurs_Thrice_I;

public class Solution
{
  public int MaximumLength(string s)
  {
    var maxLength = -1;
    for (var c = 'a'; c <= 'z'; c++)
    {
      for (var len = 1; len <= s.Length - 2; len++)
      {
        var ss = new string(c, len);
        var count = 0;
        for (var pos = s.IndexOf(ss); pos != -1; pos = s.IndexOf(ss, pos + 1))
          count++;
        if (count < 3)
          break;
        maxLength = Math.Max(maxLength, len);
      }
    }
    return maxLength;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("aaaa", 2)]
  [TestCase("abcdef", -1)]
  [TestCase("abcaba", 1)]
  public void Test(string s, int expected)
  {
    new Solution().MaximumLength(s).Should().Be(expected);
  }
}
