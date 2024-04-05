namespace LeetCode._2232._Minimize_Result_by_Adding_Parentheses;

[TestFixture]
public class Tests
{
  [TestCase("247+38", "2(47+38)")]
  [TestCase("12+34", "1(2+3)4")]
  [TestCase("999+999", "(999+999)")]
  [TestCase("1+1", "(1+1)")]
  public void Test(string expression, string expected)
  {
    new Solution().MinimizeResult(expression).Should().Be(expected);
  }
}
