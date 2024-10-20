namespace LeetCode.DP._712._Minimum_ASCII_Delete_Sum_for_Two_Strings;

public class RecursiveSolution
{
  private readonly Dictionary<(int, int), int> cache = new();

  public int MinimumDeleteSum(string s1, string s2)
  {
    return Dp(s1, s2);
  }

  private int Dp(ReadOnlySpan<char> s1, ReadOnlySpan<char> s2)
  {
    if (s1.IsEmpty)
      return AsciiSum(s2);
    if (s2.IsEmpty)
      return AsciiSum(s1);

    var cacheKey = (s1.Length, s2.Length);
    if (cache.TryGetValue(cacheKey, out var result))
      return result;

    if (s1[0] == s2[0])
      result = Dp(s1[1..], s2[1..]);
    else
      result = Math.Min(s1[0] + Dp(s1[1..], s2), s2[0] + Dp(s1, s2[1..]));

    cache[cacheKey] = result;
    return result;
  }

  private static int AsciiSum(ReadOnlySpan<char> s)
  {
    var result = 0;
    foreach (var c in s)
      result += c;
    return result;
  }
}

[TestFixture]
public class RecursiveSolutionTests
{
  [TestCase("sea", "eat", 231)]
  [TestCase("delete", "leet", 403)]
  public void Test1(string s1, string s2, int expected)
  {
    new RecursiveSolution().MinimumDeleteSum(s1, s2).Should().Be(expected);
  }
}
