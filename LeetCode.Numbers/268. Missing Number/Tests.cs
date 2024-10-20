namespace LeetCode.Numbers._268._Missing_Number;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 3, 0, 1 }, 2)]
  [TestCase(new[] { 0, 1 }, 2)]
  [TestCase(new[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 }, 8)]
  public void Test(int[] nums, int expected)
  {
    new XorOnePassSolution().MissingNumber(nums).Should().Be(expected);
    new XorTwoPassSolution().MissingNumber(nums).Should().Be(expected);
    new SumSolution().MissingNumber(nums).Should().Be(expected);
  }
}
