namespace LeetCode.__Strings._791._Custom_Sort_String;

public class CountingSolution
{
  public string CustomSortString(string order, string s)
  {
    var cnt = new int[128];
    foreach (var c in s)
      cnt[c]++;
    var result = new StringBuilder(s.Length);
    foreach (var c in order.Concat(s))
    {
      result.Append(c, cnt[c]);
      cnt[c] = 0;
    }
    return result.ToString();
  }
}

[TestFixture]
public class CountingSolutionTests
{
  [TestCase("cba", "abcd", "cbad")]
  [TestCase("bcafg", "abcd", "bcad")]
  public void Test(string order, string s, string expected)
  {
    new CountingSolution().CustomSortString(order, s).Should().Be(expected);
  }
}
