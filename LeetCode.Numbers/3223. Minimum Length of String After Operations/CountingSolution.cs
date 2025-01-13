namespace LeetCode.Numbers._3223._Minimum_Length_of_String_After_Operations;

public class CountingSolution
{
  public int MinimumLength(string s)
  {
    Span<int> cnt = stackalloc int[26];
    foreach (var c in s)
      cnt[c - 'a']++;
    var minLength = 0;
    foreach (var c in cnt)
    {
      if (c != 0)
        minLength += c % 2 == 0 ? 2 : 1;
    }
    return minLength;
  }
}

[TestFixture]
public class CountingSolutionTests
{
  [TestCase("abaacbcbb", 5)]
  [TestCase("aa", 2)]
  public void Test(string s, int expected)
  {
    new CountingSolution().MinimumLength(s).Should().Be(expected);
  }
}
