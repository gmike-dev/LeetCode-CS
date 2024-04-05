namespace LeetCode._168._Excel_Sheet_Column_Title;

[TestFixture]
public class Tests
{
  [TestCase(1, "A")]
  [TestCase(28, "AB")]
  [TestCase(701, "ZY")]
  public void Test(int columnNumber, string expected)
  {
    new Solution().ConvertToTitle(columnNumber).Should().Be(expected);
  }
}
