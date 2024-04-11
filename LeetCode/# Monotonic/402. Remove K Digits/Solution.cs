namespace LeetCode.__Monotonic._402._Remove_K_Digits;

public class Solution
{
  public string RemoveKdigits(string num, int k)
  {
    var s = new Stack<char>();
    foreach (var c in num)
    {
      while (k > 0 && s.Count > 0 && s.Peek() > c)
      {
        s.Pop();
        k--;
      }
      s.Push(c);
    }
    var result = string.Join("", s.Skip(k).Reverse().SkipWhile(c => c == '0'));
    return result.Length == 0 ? "0" : result;
  }
}

[TestFixture]
public class Tests
{
  [TestCase("1432219", 3, "1219")]
  [TestCase("1432291", 3, "1221")]
  [TestCase("10200", 1, "200")]
  [TestCase("43214321", 4, "1321")]
  [TestCase("10200", 2, "0")]
  [TestCase("10", 2, "0")]
  [TestCase("123454321", 4, "12321")]
  [TestCase("567654", 3, "554")]
  [TestCase("567654", 2, "5654")]
  [TestCase("111759", 2, "1115")]
  public void Test(string num, int k, string expected)
  {
    new Solution().RemoveKdigits(num, k).Should().Be(expected);
  }
}
