namespace LeetCode.__Numbers._7._Reverse_Integer;

/// <summary>
/// https://leetcode.com/problems/reverse-integer/
/// </summary>
public class Solution
{
  public int Reverse(int x)
  {
    if (x == int.MinValue)
      return 0;
    var max = int.MaxValue / 10;
    var maxD = int.MaxValue % 10;
    var neg = x < 0;
    x = Math.Abs(x);
    var y = 0;
    while (x != 0)
    {
      var d = x % 10;
      if (y > max || y == max && d > maxD)
        return 0;
      y = y * 10 + d;
      x /= 10;
    }
    return neg ? -y : y;
  }
}

[TestFixture]
public class Tests
{
  [TestCase(123, 321)]
  [TestCase(-123, -321)]
  [TestCase(120, 21)]
  [TestCase(int.MaxValue, 0)]
  [TestCase(int.MinValue, 0)]
  [TestCase(1463847412, 2147483641)]
  [TestCase(-2147483648, 0)]
  public void Test1(int value, int expected)
  {
    new Solution().Reverse(value).Should().Be(expected);
  }
}
