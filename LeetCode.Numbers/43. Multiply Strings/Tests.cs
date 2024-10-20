namespace LeetCode.Numbers._43._Multiply_Strings;

[TestFixture]
public class Tests
{
  [TestCase("2", "3", "6")]
  [TestCase("123", "456", "56088")]
  [TestCase("123", "456", "56088")]
  [TestCase("687", "1825", "1253775")]
  [TestCase("1825", "687", "1253775")]
  [TestCase("0", "687", "0")]
  [TestCase("24", "101", "2424")]
  [TestCase("24", "100", "2400")]
  public void Test(string num1, string num2, string expected)
  {
    new Solution().Multiply(num1, num2).Should().Be(expected);
  }
}
