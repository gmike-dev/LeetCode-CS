namespace LeetCode.Strings._1910._Remove_All_Occurrences_of_a_Substring;

public class Solution2
{
  public string RemoveOccurrences(string s, string part)
  {
    var ss = s.ToCharArray().AsSpan();
    for (var pos = ss.IndexOf(part); pos != -1; pos = ss.IndexOf(part))
    {
      var tail = ss[(pos + part.Length)..];
      tail.CopyTo(ss.Slice(pos, tail.Length));
      ss = ss[..^part.Length];
    }
    return new string(ss);
  }
}

[TestFixture]
public class Solution2Tests
{
  [TestCase("daabcbaabcbc", "abc", "dab")]
  [TestCase("axxxxyyyyb", "xy", "ab")]
  [TestCase("xy", "xy", "")]
  [TestCase("xyxy", "xy", "")]
  [TestCase("xxyy", "xy", "")]
  [TestCase("xxxyy", "xy", "x")]
  [TestCase("xxyyy", "xy", "y")]
  [TestCase("x", "xy", "x")]
  [TestCase("", "xy", "")]
  public void Test(string s, string part, string expected)
  {
    new Solution2().RemoveOccurrences(s, part).Should().Be(expected);
  }
}
