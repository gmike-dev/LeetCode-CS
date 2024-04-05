namespace LeetCode._215._Kth_Largest_Element_in_an_Array;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 3, 2, 1, 5, 6, 4 }, 2, 5)]
  [TestCase(new[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 4, 4)]
  public void Test(int[] nums, int k, int expected)
  {
    new Solution().FindKthLargest(nums, k).Should().Be(expected);
  }
}
