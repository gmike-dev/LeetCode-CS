namespace LeetCode.Strings._2707._Extra_Characters_in_a_String;

public class RecursiveSolution
{
  private string[] dict;
  private int[] cache;

  public int MinExtraChar(string s, string[] dictionary)
  {
    dict = dictionary;
    cache = new int[s.Length + 1];
    cache.AsSpan().Fill(-1);
    return MinExtraChar(s);
  }

  private int MinExtraChar(ReadOnlySpan<char> s)
  {
    if (s.Length == 0)
      return 0;

    if (cache[s.Length] != -1)
      return cache[s.Length];

    var result = s.Length;
    foreach (var word in dict)
    {
      if (s.StartsWith(word))
        result = Math.Min(result, MinExtraChar(s[word.Length..]));
      else
        result = Math.Min(result, 1 + MinExtraChar(s[1..]));
    }

    cache[s.Length] = result;
    return result;
  }
}

[TestFixture]
public class RecursiveSolutionTests
{
  [TestCase("leetcode", new[] { "leet", "code", "leetcode" }, 0)]
  [TestCase("leetscode", new[] { "leet", "code", "leetcode" }, 1)]
  [TestCase("sayhelloworld", new[] { "hello", "world" }, 3)]
  [TestCase("dwmodizxvvbosxxw", new[] { "ox","lb","diz","gu","v","ksv","o","nuq","r","txhe","e","wmo","cehy","tskz","ds","kzbu" }, 7)]
  public void Test(string s, string[] dictionary, int expected)
  {
    new RecursiveSolution().MinExtraChar(s, dictionary).Should().Be(expected);
  }
}
