namespace LeetCode._81._Search_in_Rotated_Sorted_Array_II;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 2, 5, 6, 0, 0, 1, 2 }, 0, true)]
  [TestCase(new[] { 2, 5, 6, 0, 0, 1, 2 }, 3, false)]
  public void Test1(int[] nums, int target, bool expected)
  {
    new Solution().Search(nums, target).Should().Be(expected);
  }
}
