namespace LeetCode._287._Find_the_Duplicate_Number;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 1, 3, 4, 2, 2 }, 2)]
  [TestCase(new[] { 3, 1, 3, 4, 2 }, 3)]
  [TestCase(new[] { 1, 3, 4, 2, 1 }, 1)]
  [TestCase(new[] { 1, 1 }, 1)]
  [TestCase(new[] { 2, 2, 2, 2 }, 2)]
  [TestCase(new[] { 1, 2, 2, 3, 4, 5 }, 2)]
  [TestCase(new[] { 2, 5, 9, 6, 9, 3, 8, 9, 7, 1 }, 9)]
  [TestCase(new[] { 2, 3, 1, 1 }, 1)]
  public void Test(int[] nums, int expected)
  {
    new BinarySearchSolution().FindDuplicate(nums).Should().Be(expected);
    new LinearSolution().FindDuplicate(nums).Should().Be(expected);
  }
}
