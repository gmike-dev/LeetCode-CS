namespace LeetCode._1405._Longest_Happy_String;

public class Solution2
{
  public string LongestDiverseString(int a, int b, int c)
  {
    var s = new StringBuilder();
    var cnt = new (int count, char ch)[] { (count: a, 'a'), (count: b, 'b'), (count: c, 'c') };
    var count = a + b + c;
    for (var i = 0; count != 0; i++)
    {
      Sort3(cnt);
      if (i == 0 || s[i - 1] != cnt[0].ch || i < 2 || s[i - 2] != cnt[0].ch)
      {
        s.Append(cnt[0].ch);
        cnt[0].count--;
      }
      else
      {
        if (cnt[1].count == 0)
          break;
        s.Append(cnt[1].ch);
        cnt[1].count--;
      }
      count--;
    }
    return s.ToString();
  }

  private static void Sort3((int count, char ch)[] a)
  {
    if (a[0].count < a[1].count)
      (a[0], a[1]) = (a[1], a[0]);
    if (a[1].count < a[2].count)
      (a[1], a[2]) = (a[2], a[1]);
    if (a[0].count < a[1].count)
      (a[0], a[1]) = (a[1], a[0]);
  }
}

[TestFixture]
public class Solution2Tests
{
  [TestCase(1, 1, 7, "ccaccbcc")]
  [TestCase(7, 1, 0, "aabaa")]
  public void Test(int a, int b, int c, string expected)
  {
    new Solution2().LongestDiverseString(a, b, c).Should().Be(expected);
  }
}
