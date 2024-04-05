namespace LeetCode._7._Reverse_Integer;

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
