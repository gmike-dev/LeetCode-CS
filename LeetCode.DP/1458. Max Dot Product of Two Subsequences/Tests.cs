namespace LeetCode.DP._1458._Max_Dot_Product_of_Two_Subsequences;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 2, 1, -2, 5 }, new[] { 3, 0, -6 }, 18)]
  [TestCase(new[] { 3, -2 }, new[] { 2, -6, 7 }, 21)]
  [TestCase(new[] { -1, -1 }, new[] { 1, 1 }, -1)]
  public void Test(int[] nums1, int[] nums2, int expected)
  {
    new Solution().MaxDotProduct(nums1, nums2).Should().Be(expected);
    new SolutionOptimizedDp().MaxDotProduct(nums1, nums2).Should().Be(expected);
    new SolutionUsingMemoization().MaxDotProduct(nums1, nums2).Should().Be(expected);
  }
}
