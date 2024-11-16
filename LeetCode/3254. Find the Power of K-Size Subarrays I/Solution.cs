namespace LeetCode._3254._Find_the_Power_of_K_Size_Subarrays_I;

public class Solution
{
  public int[] ResultsArray(int[] nums, int k)
  {
    if (k == 1)
      return nums;
    var n = nums.Length;
    var ans = new int[n - k + 1];
    ans.AsSpan().Fill(-1);
    for (var i = 0; i < n - k + 1; i++)
    {
      for (var j = i + 1; j < i + k; j++)
      {
        if (nums[j] - nums[j - 1] != 1)
        {
          ans[i] = -1;
          break;
        }
        ans[i] = nums[j];
      }
    }
    return ans;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 1, 2, 3, 4, 3, 2, 5 }, 3, new[] { 3, 4, -1, -1, -1 })]
  [TestCase(new[] { 2, 2, 2, 2, 2 }, 4, new[] { -1, -1 })]
  [TestCase(new[] { 3, 2, 3, 2, 3, 2 }, 2, new[] { -1, 3, -1, 3, -1 })]
  [TestCase(new[] { 1 }, 1, new[] { 1 })]
  [TestCase(new[] { 1, 3, 4 }, 2, new[] { -1, 4 })]
  public void Test(int[] nums, int k, int[] expected)
  {
    new Solution().ResultsArray(nums, k).Should()
      .BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
