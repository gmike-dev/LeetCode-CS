namespace LeetCode.Strings._394._Decode_String;

public class Solution
{
  public string DecodeString(string s)
  {
    int pos = 0;
    return Decode(s, ref pos);
  }

  private string Decode(string s, ref int pos)
  {
    StringBuilder result = new();
    while (pos < s.Length)
    {
      if (s[pos] == ']')
      {
        break;
      }
      if (char.IsDigit(s[pos]))
      {
        int k = 0;
        do
        {
          k = 10 * k + (s[pos] - '0');
          pos++;
        }
        while (char.IsDigit(s[pos]));
        pos++; // [
        string ss = Decode(s, ref pos);
        for (int i = 0; i < k; i++)
        {
          result.Append(ss);
        }
        pos++; // ]
        continue;
      }
      result.Append(s[pos]);
      pos++;
    }
    return result.ToString();
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("3[a]2[bc]", "aaabcbc")]
  [TestCase("3[a2[c]]", "accaccacc")]
  [TestCase("2[abc]3[cd]ef", "abcabccdcdcdef")]
  [TestCase("1[a]", "a")]
  [TestCase("1[a1[a]]", "aa")]
  public void Test(string s, string expected)
  {
    new Solution().DecodeString(s).Should().Be(expected);
  }
}
