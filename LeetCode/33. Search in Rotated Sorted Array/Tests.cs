namespace LeetCode._33._Search_in_Rotated_Sorted_Array;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 4, 5, 6, 7, 0, 1, 2 }, 0, 4)]
  [TestCase(new[] { 4, 5, 6, 7, 0, 1, 2 }, 3, -1)]
  [TestCase(new[] { 1 }, 0, -1)]
  [TestCase(new[] { 1, 2, 3, 4, 5 }, 1, 0)]
  [TestCase(new[] { 5,1,3 }, 5, 0)]
  public void Test1(int[] nums, int target, int expected)
  {
    new Solution().Search(nums, target).Should().Be(expected);
  }
}
