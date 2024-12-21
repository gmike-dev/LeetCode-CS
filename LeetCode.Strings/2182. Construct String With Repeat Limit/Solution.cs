namespace LeetCode.Strings._2182._Construct_String_With_Repeat_Limit;

public class Solution
{
  public string RepeatLimitedString(string s, int repeatLimit)
  {
    Span<int> count = stackalloc int[26];
    foreach (var c in s)
      count[c - 'a']++;
    var resultPos = 0;
    Span<char> result = stackalloc char[s.Length];
    for (int left = 24, right = 25;;)
    {
      while (right >= 0 && count[right] == 0)
        right--;
      if (right < 0)
        break;
      if (left >= right)
        left = right - 1;
      while (left >= 0 && count[left] == 0)
        left--;
      if (resultPos == 0 || result[resultPos - 1] != (char)('a' + right))
      {
        var c = Math.Min(repeatLimit, count[right]);
        for (var i = 0; i < c; i++)
          result[resultPos++] = (char)('a' + right);
        count[right] -= c;
      }
      else if (left >= 0)
      {
        result[resultPos++] = (char)('a' + left);
        count[left]--;
      }
      else
        break;
    }
    return new string(result[..resultPos]);
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("cczazcc", 3, "zzcccac")]
  [TestCase("aababab", 2, "bbabaa")]
  public void Test(string s, int repeatLimit, string expected)
  {
    new Solution().RepeatLimitedString(s, repeatLimit).Should().Be(expected);
  }
}
