namespace LeetCode.SlidingWindow._1358._Number_of_Substrings;

public class Solution2
{
  public int NumberOfSubstrings(string s)
  {
    var last = new int[3];
    last.AsSpan().Fill(-1);
    var count = 0;
    for (var i = 0; i < s.Length; i++)
    {
      last[s[i] - 'a'] = i;
      count += last.Min() + 1;
    }
    return count;
  }
}

[TestFixture]
public class Solution2Tests
{
  [TestCase("abcabc", 10)]
  [TestCase("aaacb", 3)]
  [TestCase("abc", 1)]
  [TestCase("acbbcac", 11)]
  public void Test(string s, int expected)
  {
    new Solution2().NumberOfSubstrings(s).Should().Be(expected);
  }
}
