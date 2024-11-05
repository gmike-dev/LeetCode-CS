namespace LeetCode.Strings._3163._String_Compression_III;

public class Solution
{
  public string CompressedString(string word)
  {
    var sb = new StringBuilder();
    var prev = '\0';
    var count = 0;
    foreach (var c in word)
    {
      if (c == prev)
      {
        count++;
        if (count == 9)
        {
          sb.Append(count);
          sb.Append(prev);
          count = 0;
        }
      }
      else
      {
        if (count > 0)
        {
          sb.Append(count);
          sb.Append(prev);
        }
        count = 1;
        prev = c;
      }
    }
    if (count > 0)
    {
      sb.Append(count);
      sb.Append(prev);
    }
    return sb.ToString();
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("abcde", "1a1b1c1d1e")]
  [TestCase("aaaaaaaaaaaaaabb", "9a5a2b")]
  public void Test(string word, string expected)
  {
    new Solution().CompressedString(word).Should().Be(expected);
  }
}
