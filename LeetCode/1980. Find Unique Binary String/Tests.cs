namespace LeetCode._1980._Find_Unique_Binary_String;

[TestFixture]
public class Tests
{
  [TestCase(new[] { "01", "10" }, "00")]
  [TestCase(new[] { "00", "01" }, "10")]
  [TestCase(new[] { "111", "011", "001" }, "000")]
  public void Test(string[] nums, string expected)
  {
    new Solution().FindDifferentBinaryString(nums).Should().Be(expected);
  }

  [TestCase(new[] { "01", "10" }, "11")]
  [TestCase(new[] { "00", "01" }, "10")]
  [TestCase(new[] { "111", "011", "001" }, "000")]
  public void Test_CantorDiagonalSolution(string[] nums, string expected)
  {
    new CantorDiagonalSolution().FindDifferentBinaryString(nums).Should().Be(expected);
  }
}
